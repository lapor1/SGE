using Microsoft.EntityFrameworkCore;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Servicios;
using System.Security.Cryptography;
using System.Text;

namespace SGE.Repositorios;

public class SGESqlite
{
    public static bool Inicializar()
    {
        bool creada = false;

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

            creada = true;
            Console.WriteLine("Se creó base de datos"); 
        }
        else
        {
            Console.WriteLine("No se creó base de datos");
        }
        return creada;
    
    }

    

}
