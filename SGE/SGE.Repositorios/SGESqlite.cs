using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

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
            
            context.Expedientes.Add(new Expediente() {Id = 4, IdExpediente = 20, Caratula = "qwerty", FechaHoraCreacion = DateTime.Now});
            context.Expedientes.Add(new Expediente() {Id = 5, IdExpediente = 21, Caratula = "wert", FechaHoraCreacion = DateTime.Now});
            context.Expedientes.Add(new Expediente() {Id = 6, IdExpediente = 22, Caratula = "qwerertyty", FechaHoraCreacion = DateTime.Now});

            context.Tramites.Add(new Tramite() {Id = 1, IdTramite = 4, IdExpediente = 20, TipoTramite = Aplicacion.Enumerativos.EtiquetaTramite.EscritoPresentado, Contenido = "qwerertyty", FechaHoraCreacion = DateTime.Now, FechaHoraModificacion = DateTime.Now});
            context.Tramites.Add(new Tramite() {Id = 2, IdTramite = 5, IdExpediente = 22, TipoTramite = Aplicacion.Enumerativos.EtiquetaTramite.Notificacion, Contenido = "algo de algo", FechaHoraCreacion = DateTime.Now, FechaHoraModificacion = DateTime.Now});

            context.Usuarios.Add(new Usuario() {IdUsuario = 1, Nombre = "Admin", Apellido = "Admin", CorreoElectrónico = "Admin@hotmail.com", Contraseña = "1234"});

            context.SaveChanges();


            Console.WriteLine("Se agregaron algunas tuplas a Expedientes y Tramites en la base de datos");
            
        }
        else
        {
            Console.WriteLine("No se creó base de datos");
        }
    
    }

}
