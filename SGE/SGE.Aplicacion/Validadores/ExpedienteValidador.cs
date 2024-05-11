namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    public bool Validar(Expediente expediente, out string mensajeError)
    {
        mensajeError = "";
        if (expediente.IdUsuarioUM <= 0) 
        {
            throw new Exception("Id de Usuario inválido");
        }
        if (string.IsNullOrEmpty(expediente.Caratula))
        {
            throw new Exception("La caratula esta Vacia!");
        }
        return (mensajeError == "");
    }
}
