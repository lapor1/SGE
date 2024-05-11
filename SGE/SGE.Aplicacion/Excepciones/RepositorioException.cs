using System.Diagnostics;

namespace SGE.Aplicacion;

public class RepositorioException
{
    public void BajaExpediente(bool encontrado)
    {
        if (!encontrado)
        {
            throw new Exception("monto demasiado grande");
        }
    }

    public void ModificacionExpediente(bool encontrado)
    {
        if (!encontrado)
        {
            throw new Exception("monto demasiado grande");
        }
    }

    public void ConsultarExpediente(Expediente expediente)
    {
        if (expediente == null)
        {
             throw new Exception("monto demasiado grande");
        }
    }

/*
    public RepositorioException (out string mensajeError) {
        
        mensajeError = $"El tramite no se puede modificar porque no existe en el repositorio";
        mensajeError = $"El tramite no se puede eliminar porque no existe en el respositorio";
        mensajeError = $"El tramite no se puede accder porque no existe en el respositorio ";

        mensajeError = $"El Expediente no se puede modificar porque no existe en el repositorio";
        mensajeError = $"El Expediente no se puede eliminar porque no existe en el respositorio";
        mensajeError = $"El Expediente no se puede accder porque no existe en el respositorio ";
    }
*/
}