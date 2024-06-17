using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Repositorios;

public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly string _nombreArch = "tramite.txt";
    public void AgregarTramiteAlta(Tramite tramite)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(tramite.Id);
        sw.WriteLine(tramite.IdExpediente);
        sw.WriteLine(tramite.TipoTramite);
        sw.WriteLine(tramite.Contenido);
        sw.WriteLine(tramite.FechaHoraCreacion);
        sw.WriteLine(tramite.FechaHoraModificacion);
        sw.WriteLine(tramite.IdUsuarioUM);
    }

    public bool EliminarTramiteBaja(int id)     //mucha ineficiencia pero bueno
    {        
        var listaTramites = new List<Tramite>();
        listaTramites = ListarTramites();
        int i = 0;
        bool encontrado = false;
        while((listaTramites.Count > i) && (!encontrado)) {
            if (listaTramites[i].Id == id) {
                listaTramites.Remove(listaTramites[i]);
                encontrado = true;
            }
            i++;
        }
        SobreEscribirArchivo(listaTramites);     
        return encontrado;   
    }

    public bool ModificarTramite(Tramite tramite)
    {
        var listaTramites = new List<Tramite>();
        listaTramites = ListarTramites();
        int i = 0;
        bool encontrado = false;
        while((listaTramites.Count > i) && (!encontrado)) {
            if (listaTramites[i].Id == tramite.Id) {
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
        return encontrado;
    }

    public Tramite? GetTramite(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var tramite = obtenerTramiteDelRepositorio(sr); 
            if (tramite.Id == id) {
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
            sw.WriteLine(listaTramites[i].Id);
            sw.WriteLine(listaTramites[i].IdExpediente);
            sw.WriteLine(listaTramites[i].TipoTramite);
            sw.WriteLine(listaTramites[i].Contenido);
            sw.WriteLine(listaTramites[i].FechaHoraCreacion);
            sw.WriteLine(listaTramites[i].FechaHoraModificacion);
            sw.WriteLine(listaTramites[i].IdUsuarioUM);
        }
    }

    private Tramite obtenerTramiteDelRepositorio(StreamReader sr) {
        var tramite = new Tramite();
        tramite.Id = int.Parse(sr.ReadLine() ?? "");
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
        using var sw = new StreamWriter(_nombreArch, true); //Por si intenta listar cuando no esta creado el archivo
        sw.Close();

        var resultado = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var tramite = obtenerTramiteDelRepositorio(sr); 
            resultado.Add(tramite);
        }
        return resultado;
    }

    public bool TramiteConsultarPorId(out Tramite? tramite, int id)
    {   
        var listaTramites = new List<Tramite>();
        listaTramites = ListarTramites();
        int i = 0;
        bool encontrado = false;
        while((listaTramites.Count > i) && (!encontrado)) {
            if (listaTramites[i].IdExpediente == id) {
                encontrado = true;
            }
            else
            {
                i++;
            }
        }
        if (encontrado) {
            tramite = listaTramites[i];
        }
        else {
            tramite = null;
        }
        return encontrado;
    }
}
