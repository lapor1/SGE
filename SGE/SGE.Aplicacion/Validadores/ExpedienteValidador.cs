namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    public bool Validar(Expediente expediente, out string mensajeError)
    {
        mensajeError = "";
        //valida si el usuario es valido
        if (expediente.IdUsuarioUM <= 0) 
        {
            throw new Exception("Id de Usuario inválido");
        }
        //valida si la caratula del expediente no esta vacio
        if (string.IsNullOrEmpty(expediente.Caratula))
        {
            throw new Exception("La caratula esta Vacia!");
        }
        return (mensajeError == "");
    }
}
