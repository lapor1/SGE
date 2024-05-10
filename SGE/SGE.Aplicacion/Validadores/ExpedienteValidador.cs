namespace SGE.Aplicacion;

public class ExpedienteValidador
{

    //las validaciones solo validan no dan los mensajes de error
    //eso lo hace las excepciones
    public bool Validar(Expediente expediente, out string mensajeError)
    {
        mensajeError = "";
        if (expediente.IdUsuario <= 0)
        {
            //mensajeError = "El usuario es invalido.";

            throw new ValidacionException(mensajeError);       
        }
        else if (string.IsNullOrEmpty(expediente.Caratula))
        {
            //mensajeError = "La carátula de un expediente no puede estar vacía.";
            throw new ValidacionException(mensajeError);
        }
        return (mensajeError == "");
    }
}
