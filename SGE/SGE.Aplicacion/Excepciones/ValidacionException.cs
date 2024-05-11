namespace SGE.Aplicacion;

class ValidacionException
{
    // [ ]  La excepción ValidacionException debe ser lanzada cuando una entidad no cumple con los requisitos
    //      exigidos y, por lo tanto, no supera la validación establecida.

    public void ExcepcionUser(Expediente expediente)
    {
        try
        {
            ExpedienteValidador.ValidarUser(expediente);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ExcepcionCaratula(Expediente expediente, string mensajeError)
    {
       try
        {
            ExpedienteValidador.ValidarCaratula(expediente);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        } 
    }

    public void ExcepcionUsuario(Tramite tramite)
    {
        try
        {
            TramiteValidador.ValidarUsuarioTramite(tramite);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ExcepcionContenido(Tramite tramite)
    {
        try
        {
            TramiteValidador.ValidarContenido(tramite);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
