namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    public bool Validar(Expediente expediente, out string mensajeError)
    {
        mensajeError = "";
        if (expediente.IdUsuario <= 0)
        {
            mensajeError = "El usuario es invalido.";
        }
        else if (string.IsNullOrEmpty(expediente.Caratula))
        {
            mensajeError = "La carátula de un expediente no puede estar vacía.";
        }
        return (mensajeError == "");
    }

}