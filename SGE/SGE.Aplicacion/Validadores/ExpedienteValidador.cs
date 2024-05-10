namespace SGE.Aplicacion;

public class ExpedienteValidador
{

    public bool Validar(Expediente expediente, out string mensajeError)
    {
        try
        {
            ExcepcionUser("Usuario Invalido");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}
