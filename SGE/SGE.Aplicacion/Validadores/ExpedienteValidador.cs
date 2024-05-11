namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    /*
    public void ValidarUseruarioExpediente(Expediente expediente)
    {
        if (expediente.IdUsuarioUM <= 0) 
        {
            ExcepcionUsuarioExpediente(expediente);
            //throw new Exception("Id de Usuario inválido");
        }
    }

    public void ValidarCaratulaExpediente(Expediente expediente)
    {
        if (string.IsNullOrEmpty(expediente.Caratula))
        {
            throw new Exception("La caratula esta Vacia!");
        }
    }
    */

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
