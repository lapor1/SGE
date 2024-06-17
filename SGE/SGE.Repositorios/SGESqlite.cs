using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SGE.Aplicacion.Entidades;

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

    public static void AgregarUnosTramitesYExpedientes()
    {
        using var context = new SGEContext();
        
        context.Expedientes.Add(new Expediente() {Id = 4, Caratula = "qwerty", FechaHoraCreacion = DateTime.Now});
        context.Expedientes.Add(new Expediente() {Id = 5, Caratula = "wert", FechaHoraCreacion = DateTime.Now});
        context.Expedientes.Add(new Expediente() {Id = 6, Caratula = "qwerertyty", FechaHoraCreacion = DateTime.Now});

        context.Tramites.Add(new Tramite() {Id = 1, Contenido = "qwerertyty", FechaHoraCreacion = DateTime.Now});

        context.SaveChanges();

        Console.WriteLine("Se agregaron algunas tuplas a Expedientes y Tramites en la base de datos");
        
    }

    public static void CrearAdmin()
    {
        
    }

}
