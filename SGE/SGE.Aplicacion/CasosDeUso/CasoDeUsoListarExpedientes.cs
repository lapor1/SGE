using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoListarExpedientes(IExpedienteRepositorio repo)
{
    public List<Expediente> Ejecutar()
    {
        //devuelve la lista de los Expedientes
        return repo.ListarExpedientes();   
    }
}