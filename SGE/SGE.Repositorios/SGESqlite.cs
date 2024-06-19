using Microsoft.EntityFrameworkCore;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

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

    public static void AgregarUnosTramitesYExpedientes()
    {
        using var context = new SGEContext();
        
        context.Expedientes.Add(new Expediente() {Id = 4, Caratula = "qwerty", FechaHoraCreacion = DateTime.Now});
        context.Expedientes.Add(new Expediente() {Id = 5, Caratula = "wert", FechaHoraCreacion = DateTime.Now});
        context.Expedientes.Add(new Expediente() {Id = 6, Caratula = "qwerertyty", FechaHoraCreacion = DateTime.Now});

        context.Tramites.Add(new Tramite() {Id = 1, Contenido = "qwerertyty", FechaHoraCreacion = DateTime.Now});
        context.Tramites.Add(new Tramite() {Id = 2, Contenido = "Megadeath", FechaHoraCreacion = DateTime.Now});
        context.Tramites.Add(new Tramite() {Id = 3, Contenido = "poasfpasf", FechaHoraCreacion = DateTime.Now});
        context.Tramites.Add(new Tramite() {Id = 4, Contenido = "mcsnvoan", FechaHoraCreacion = DateTime.Now});

        context.SaveChanges();

        Console.WriteLine("Se agregaron algunas tuplas a Expedientes y Tramites en la base de datos");
        
    }

    private static string GetSHA256Hash(string input)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder result = new StringBuilder();
        foreach (byte b in bytes)
        {
            result.Append(b.ToString("x2"));
        }
        return result.ToString();
    }

    public static void CrearAdmin()
    {
        using var context = new SGEContext();
        
        List<Permiso> permisosAdmin = new List<Permiso>();

        foreach (Permiso p in Enum.GetValues(typeof(Permiso)))
        {
            permisosAdmin.Add(p);
        }

        string hashedPassword = GetSHA256Hash("1234");

        Usuario admin = new Usuario() {
            Id = 1,
            Nombre = "Admin",
            Apellido = "Admin",
            CorreoElectrónico = "Admin@gmail.com",
            Contraseña = hashedPassword,
            ListaPermisos = permisosAdmin
        };

         Console.WriteLine($"Password Hash: {hashedPassword}");

        context.Usuarios.Add(admin);
        context.SaveChanges();
    }

}
