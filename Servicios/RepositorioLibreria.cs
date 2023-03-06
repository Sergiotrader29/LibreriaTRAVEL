using Dapper;
using Library.Models;
using System.Data.SqlClient;

namespace Library.Servicios
{
    public interface IrepositorioLibreria
    {
        Task<IEnumerable<Autor>> Obtener(string nombre);
    }
    public class RepositorioLibreria: IrepositorioLibreria
    {
        private readonly string connectionString;
        public RepositorioLibreria(IConfiguration configuration)//aceder al conection string
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<Autor>> Obtener(string nombre)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Autor>(@"SELECT Id, Nombre, Apellido
                                                            FROM Autor
                                                            WHERE Nombre = '@Nombre'
                                                            ORDER BY Orden", new { nombre });
        }

    }
}
