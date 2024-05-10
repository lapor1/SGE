namespace SGE.Repositorios;
using SGE.Aplicacion;

using System.Data.Common;
using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    readonly string _nombreArch = "expediente.txt";
    public void AgregarExpedienteAlta(Expediente expediente)
    {
        using var sw = new StreamWriter(_nombreArch, true); //agrega al final del archivo
        
        sw.WriteLine(expediente.IdExpediente);
        //sw.WriteLine(expediente.IdTramite);
        sw.WriteLine(expediente.Caratula);
        sw.WriteLine(expediente.FechaHoraCreacion);
        sw.WriteLine(expediente.FechaHoraModificacion);
        sw.WriteLine(expediente.IdUsuarioUM);
        sw.WriteLine(expediente.estadoExpediente);
    }

    public void EliminarExpedienteBaja(int id)     //mucha ineficiencia pero bueno
    {        
        var listaExpedientes = new List<Expediente>();
        listaExpedientes = ListarExpedientes();
        int i = 0;
        bool encontrado = false;
        while((listaExpedientes.Count > i) && (!encontrado)) {
            if (listaExpedientes[i].IdExpediente == id) {
                listaExpedientes.Remove(listaExpedientes[i]);
                encontrado = true;
            }
            i++;
        }
        SobreEscribirArchivo(listaExpedientes);        
    }

    public void ModificarExpediente(Expediente expediente)
    {
        var listaExpedientes = new List<Expediente>();
        listaExpedientes = ListarExpedientes();
        int i = 0;
        bool encontrado = false;
        while((listaExpedientes.Count > i) && (!encontrado)) {
            if (listaExpedientes[i].IdExpediente == expediente.IdExpediente) {
                //listaExpedientes[i].IdTramite = expediente.IdTramite;
                listaExpedientes[i].Caratula = expediente.Caratula;
                listaExpedientes[i].FechaHoraModificacion = expediente.FechaHoraModificacion;
                listaExpedientes[i].IdUsuarioUM = expediente.IdUsuarioUM;
                listaExpedientes[i].estadoExpediente = expediente.estadoExpediente;
                encontrado = true;
            }
            i++;
        }
        SobreEscribirArchivo(listaExpedientes);
    }

    public Expediente? GetExpediente(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var expediente = obtenerExpedienteDelRepositorio(sr); 
            if (expediente.IdExpediente == id) {
                return expediente;
            }
        }
        return null;
    }

    public void SobreEscribirArchivo(List<Expediente> listaExpedientes)
    {
        using var sw = new StreamWriter(_nombreArch, false); 

        for (int i = 0; i < listaExpedientes.Count; i++)
        {
            sw.WriteLine(listaExpedientes[i].IdExpediente);
            //sw.WriteLine(listaExpedientes[i].IdTramite);
            sw.WriteLine(listaExpedientes[i].Caratula);
            sw.WriteLine(listaExpedientes[i].FechaHoraCreacion);
            sw.WriteLine(listaExpedientes[i].FechaHoraModificacion);
            sw.WriteLine(listaExpedientes[i].IdUsuarioUM);
            sw.WriteLine(listaExpedientes[i].estadoExpediente);
        }
    }

    public Expediente obtenerExpedienteDelRepositorio(StreamReader sr) {
        var expediente = new Expediente();
        expediente.IdExpediente = int.Parse(sr.ReadLine() ?? "");
        //expediente.IdTramite = int.Parse(sr.ReadLine() ?? "");
        expediente.Caratula = sr.ReadLine() ?? "";
        expediente.FechaHoraCreacion = DateTime.Parse(sr.ReadLine() ?? "");
        expediente.FechaHoraModificacion = DateTime.Parse(sr.ReadLine() ?? "");
        expediente.IdUsuarioUM = int.Parse(sr.ReadLine() ?? "");
        expediente.estadoExpediente = (EstadoExpediente) Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "");
        return expediente;
    }

    public List<Expediente> ListarExpedientes()
    {
        var resultado = new List<Expediente>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var expediente = obtenerExpedienteDelRepositorio(sr); 
            resultado.Add(expediente);
        }
        return resultado;
    }

    public void ExpedienteConsultarPorId(out Expediente expediente, int id)
    {   
        var listaExpedientes = new List<Expediente>();
        listaExpedientes = ListarExpedientes();
        int i = 0;
        bool encontrado = false;
        while((listaExpedientes.Count > i) && (!encontrado)) {
            if (listaExpedientes[i].IdExpediente == id) {
                listaExpedientes.Remove(listaExpedientes[i]);
                encontrado = true;
            }
            else
            {
                i++;
            }
        }
        expediente = listaExpedientes[i];
        //return encontrado;
    }
}
