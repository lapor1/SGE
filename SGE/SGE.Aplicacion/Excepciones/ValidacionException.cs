namespace SGE.Aplicacion;

class ValidacionException(TramiteValidador validadorTramite, ExpedienteValidador validadorExpediente)
{
    public void ExcepcionUsuarioExpediente(Expediente expediente)
    {
        try
        {
            validadorExpediente.ValidarUseruarioExpediente(expediente);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ExcepcionCaratulaExpediente(Expediente expediente, string mensajeError)
    {
       try
        {
            validadorExpediente.ValidarCaratulaExpediente(expediente);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        } 
    }

    public void ExcepcionUsuarioTramite(Tramite tramite)
    {
        try
        {
            validadorTramite.ValidarUsuarioTramite(tramite);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ExcepcionContenidoTramite(Tramite tramite)
    {
        try
        {
            validadorTramite.ValidarContenidoTramite(tramite);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
