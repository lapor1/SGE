namespace SGE.Repositorios;

using System.Data.Common;
using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;
using SGE.Aplicacion;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
    private static int id = 0;
    readonly string _nombreArch = "tramite.txt";
    public void AgregarTramiteAlta(Tramite tramite)
    {
        id++;
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(id);
        sw.WriteLine(tramite.IdExpediente);
        sw.WriteLine(tramite.TipoTramite);
        sw.WriteLine(tramite.Contenido);
        sw.WriteLine(DateTime.Now);
        sw.WriteLine(DateTime.Now);
        sw.WriteLine(tramite.IdUsuarioModificacion == null ? 0 : tramite.IdUsuarioModificacion);
    }

    public bool EliminarTramiteBaja(int id)
    {
        bool eliminated = false;
        
        using var sr = new StreamReader(_nombreArch);
        while ((!sr.EndOfStream) && (!eliminated))
        {
            var tramite = obtenerTramiteDelRepositorio(sr);
            if (tramite.IdTramite == id) {    
                // eliminar tramite
                tramite.IdTramite = 0;      
                eliminated = true;
            }
        }

        return eliminated;
    }

    private Tramite obtenerTramiteDelRepositorio(StreamReader sr) {
        var tramite = new Tramite();
        tramite.IdTramite = int.Parse(sr.ReadLine() ?? "");
        tramite.IdExpediente = int.Parse(sr.ReadLine() ?? "");
        tramite.TipoTramite = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "");
        tramite.Contenido = sr.ReadLine() ?? "";
        tramite.FechaHoraCreacion = DateTime.Parse(sr.ReadLine() ?? "");
        tramite.FechaHoraModificacion = DateTime.Parse(sr.ReadLine() ?? "");
        tramite.IdUsuarioModificacion = int.Parse(sr.ReadLine() ?? "");
        return tramite;
    }

    public List<Tramite> ListarTramites()
    {
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var tramite = obtenerTramiteDelRepositorio(sr); 
            resultado.Add(tramite);
        }
        return resultado;
    }
}
