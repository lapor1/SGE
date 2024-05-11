namespace SGE.Aplicacion;

public class ValidacionException(TramiteValidador validadorTramite, ExpedienteValidador validadorExpediente)
{
    public void VerificarExpediente(Expediente expediente)
    {
        if (!validadorExpediente.Validar(expediente, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }   
    }
    public void VerificarTramite(Tramite tramite)
    {
        if (!validadorTramite.Validar(tramite, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
    }
}
