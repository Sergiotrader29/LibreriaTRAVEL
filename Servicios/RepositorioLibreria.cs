using Dapper;
using Library.Models;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace Library.Servicios
{
    public interface IrepositorioLibreria
    {
        Task AñadirLibro(Libro libro);
        Task<IEnumerable<AutorConLibro>> Buscar();
       
     
        Task<IEnumerable<AutorConLibro>> BuscarAutor(Autor autor);
    }    
    public class RepositorioLibreria: IrepositorioLibreria
    {
        private readonly string connectionString;
        public RepositorioLibreria(IConfiguration configuration)//aceder al conection string
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<AutorConLibro>> Buscar()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<AutorConLibro>
               (@" SELECT  Autor.Nombre,Autor.Apellido,Libros.Titulo,Libros.n_paginas,Libros.Sinopsis,
        Editoriales.Editorial,Editoriales.Sede
            from AutorConLibro
            join Autor on AutorConLibro.autores_id = Autor.Id
            join Libros on AutorConLibro.libros_ISBN = Libros.ISBN
			join Editoriales on Libros.Editoriales_ID = Editoriales.Id; ");

        }

        public async Task<IEnumerable<AutorConLibro>> BuscarAutor(Autor autor)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<AutorConLibro>
               (@" SELECT  Autor.Nombre,Autor.Apellido,Libros.Titulo,Libros.n_paginas,Libros.Sinopsis,
        Editoriales.Editorial,Editoriales.Sede,AutorConLibro.autores_id
            from AutorConLibro
            join Autor on AutorConLibro.autores_id = Autor.Id
            join Libros on AutorConLibro.libros_ISBN = Libros.ISBN
			join Editoriales on Libros.Editoriales_ID = Editoriales.Id
            where Autor.Nombre= @NombreAutor", new { NombreAutor = autor.Nombre });

        }



        public async Task AñadirLibro(Libro libro)
        {
            using var connection = new SqlConnection(connectionString);

            var autorId = await connection.QuerySingleAsync<int>(
      "INSERT INTO Autor (Nombre, Apellido) VALUES (@Nombre, @Apellido); SELECT SCOPE_IDENTITY();",
      new { Nombre = libro.Autor.Nombre, Apellido = libro.Autor.Apellido });

            var Editoriales_ID = await connection.QuerySingleAsync<int>(
     "INSERT INTO Editoriales(Editorial, Sede) VALUES (@Editorial, @Sede);SELECT SCOPE_IDENTITY();",
     new { Editorial = libro.editoriales.NombreEditorial, Sede = libro.editoriales.Sede });

            var libroId = await connection.QuerySingleAsync<int>(
         "INSERT INTO Libros (Titulo, Sinopsis, n_paginas,Editoriales_ID) VALUES (@Titulo, @Sinopsis, @n_paginas,@Editoriales_ID); SELECT SCOPE_IDENTITY();",
         new { Titulo = libro.Titulo, Sinopsis = libro.Sinopsis, n_paginas = libro.n_paginas, Editoriales_ID = Editoriales_ID });

          
            await connection.ExecuteAsync(
                "INSERT INTO AutorConlibro (autores_id, libros_ISBN) VALUES (@AutorId, @LibroId); ",
              new { AutorId = autorId, LibroId = libroId });

          
        }



    }
}
