using System.Security.Cryptography;
using System.Text;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.Servicios;

public class ServicioHash : IServicioHash
{
    public string HashPassword(string password)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder result = new StringBuilder();
        foreach (byte b in bytes)
        {
            result.Append(b.ToString("x2"));
        }
        return result.ToString();
    }
}