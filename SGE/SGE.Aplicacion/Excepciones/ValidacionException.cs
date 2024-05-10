namespace SGE.Aplicacion;

class ValidacionException
{
    // [ ]  La excepción ValidacionException debe ser lanzada cuando una entidad no cumple con los requisitos
    //      exigidos y, por lo tanto, no supera la validación establecida.

    public void ExcepcionUser(Expediente expediente, string mensajeError)
    {
        try
        {
            ExpedienteValidador.Validar(expediente, mensajeError);
        }
        catch (UsuarioNuloException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void ExcepcionCaratula(Expediente expediente, string mensajeError)
    {
       try
        {
            ExpedienteValidador.Validar(expediente, mensajeError);
        }
        catch (UsuarioNuloException ex)
        {
            Console.WriteLine(ex.Message);
        } 
    }
}
