namespace SGE.Repositorios;

using Microsoft.Win32.SafeHandles;
using SGE.Aplicacion;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly string _nombreArch = "tramite.txt";
    public void AgregarTramiteAlta(Tramite tramite)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(tramite.IdTramite);
        sw.WriteLine(tramite.Contenido);
    }

    public List<Tramite> ListarTramites()
    {
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var tramite = new Tramite();
            tramite.IdTramite = int.Parse(sr.ReadLine() ?? "");
            tramite.Contenido = sr.ReadLine() ?? "";
            resultado.Add(tramite);
        }
        return resultado;
    }
}
