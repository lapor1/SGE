using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;

public class SGESqlite
{
    public static void Inicializar()
    {
        using var context = new SGEContext();
        if (context.Database.EnsureCreated())
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Se creó base de datos");
        }
        else
        {
            Console.WriteLine("No se creó base de datos");
        }
    
    }

}
