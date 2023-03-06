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
      
       // Task AñadirLibro();

        // Task<IEnumerable<Autor>> Buscar(string nombre);
        Task<IEnumerable<AutorConLibro>> Buscar();
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
            return await connection.QueryAsync<AutorConLibro>(@"SELECT Nombre
                                                            FROM Autor
                                                             ");

        }


        public async Task AñadirLibro(Libro libro)
        {
            using var connection = new SqlConnection(connectionString);

            var autorId = await connection.QuerySingleAsync<int>(
      "INSERT INTO Autor (Nombre, Apellido) VALUES (@Nombre, @Apellido); SELECT SCOPE_IDENTITY();",
      new { Nombre = libro.Autor.Nombre, Apellido = libro.Autor.Apellido });

            var libroId = await connection.QuerySingleAsync<int>(
         "INSERT INTO Libros (Titulo, Sinopsis, n_paginas) VALUES (@Titulo, @Sinopsis, @n_paginas); SELECT SCOPE_IDENTITY();",
         new { Titulo = libro.Titulo, Sinopsis = libro.Sinopsis, n_paginas = libro.n_paginas });


            await connection.ExecuteAsync(
                "INSERT INTO AutorConlibro (autores_id, libros_ISBN) VALUES (@AutorId, @LibroId); ",
              new { AutorId = autorId, LibroId = libroId });
        }



    }
}
