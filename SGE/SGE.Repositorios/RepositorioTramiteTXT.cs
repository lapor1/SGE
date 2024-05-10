namespace SGE.Repositorios;
using SGE.Aplicacion;

using System.Data.Common;
using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly string _nombreArch = "tramite.txt";
    public void AgregarTramiteAlta(Tramite tramite)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(tramite.IdTramite);
        sw.WriteLine(tramite.IdExpediente);
        sw.WriteLine(tramite.TipoTramite);
        sw.WriteLine(tramite.Contenido);
        sw.WriteLine(tramite.FechaHoraCreacion);
        sw.WriteLine(tramite.FechaHoraModificacion);
        sw.WriteLine(tramite.IdUsuarioUM);
    }

    public void EliminarTramiteBaja(int id)     //mucha ineficiencia pero bueno
    {        
        var listaTramites = new List<Tramite>();
        listaTramites = ListarTramites();
        int i = 0;
        bool encontrado = false;
        while((listaTramites.Count > i) && (!encontrado)) {
            if (listaTramites[i].IdTramite == id) {
                listaTramites.Remove(listaTramites[i]);
                encontrado = true;
            }
            i++;
        }
        SobreEscribirArchivo(listaTramites);        
    }

    public void ModificarTramite(Tramite tramite)
    {
        var listaTramites = new List<Tramite>();
        listaTramites = ListarTramites();
        int i = 0;
        bool encontrado = false;
        while((listaTramites.Count > i) && (!encontrado)) {
            if (listaTramites[i].IdTramite == tramite.IdTramite) {
                listaTramites[i].IdExpediente = tramite.IdExpediente;
                listaTramites[i].TipoTramite = tramite.TipoTramite;
                listaTramites[i].Contenido = tramite.Contenido;
                listaTramites[i].FechaHoraModificacion = tramite.FechaHoraModificacion;
                listaTramites[i].IdUsuarioUM = tramite.IdUsuarioUM;
                encontrado = true;
            }
            i++;
        }
        SobreEscribirArchivo(listaTramites);
    }

    public Tramite? GetTramite(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var tramite = obtenerTramiteDelRepositorio(sr); 
            if (tramite.IdTramite == id) {
                return tramite;
            }
        }
        return null;
    }

    public void SobreEscribirArchivo(List<Tramite> listaTramites)
    {
        using var sw = new StreamWriter(_nombreArch, false); 

        for (int i = 0; i < listaTramites.Count; i++)
        {
            sw.WriteLine(listaTramites[i].IdTramite);
            sw.WriteLine(listaTramites[i].IdExpediente);
            sw.WriteLine(listaTramites[i].TipoTramite);
            sw.WriteLine(listaTramites[i].Contenido);
            sw.WriteLine(listaTramites[i].FechaHoraCreacion);
            sw.WriteLine(listaTramites[i].FechaHoraModificacion);
            sw.WriteLine(listaTramites[i].IdUsuarioUM);
        }
    }

    public Tramite obtenerTramiteDelRepositorio(StreamReader sr) {
        var tramite = new Tramite();
        tramite.IdTramite = int.Parse(sr.ReadLine() ?? "");
        tramite.IdExpediente = int.Parse(sr.ReadLine() ?? "");
        tramite.TipoTramite = (EtiquetaTramite) Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "");
        tramite.Contenido = sr.ReadLine() ?? "";
        tramite.FechaHoraCreacion = DateTime.Parse(sr.ReadLine() ?? "");
        tramite.FechaHoraModificacion = DateTime.Parse(sr.ReadLine() ?? "");
        tramite.IdUsuarioUM = int.Parse(sr.ReadLine() ?? "");
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

    public bool TramiteConsultarPorId(out Tramite tramite, int id)
    {   
        var listaTramites = new List<Tramite>();
        listaTramites = ListarTramites();
        int i = 0;
        bool encontrado = false;
        while((listaTramites.Count > i) && (!encontrado)) {
            if (listaTramites[i].IdExpediente == id) {
                listaTramites.Remove(listaTramites[i]);
                encontrado = true;
            }
            else
            {
                i++;
            }
        }
        tramite = listaTramites[i];
        return encontrado;
    }
}
