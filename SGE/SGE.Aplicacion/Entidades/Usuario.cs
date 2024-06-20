using SGE.Aplicacion.Enumerativos;
using System.Security.Cryptography;
using System.Text;

namespace SGE.Aplicacion.Entidades;

public class Usuario
{
    
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? CorreoElectronico { get; set; }
    public string? Contraseña { get; set; }
    public List<Permiso> ListaPermisos { get; set; } = new List<Permiso>();

    public void SetPassword(string password)
    {
        Contraseña = GetSHA256Hash(password);
    }

    public string? GetPassword()
    {
        return Contraseña;
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
    
}
