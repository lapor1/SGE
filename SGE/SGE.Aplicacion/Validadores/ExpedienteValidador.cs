namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    public bool Validar(Expediente expediente, out string mensajeError)
    {
        mensajeError = "";
        //valida si el usuario es valido
        if (expediente.IdUsuarioUM <= 0) 
        {
            throw new Exception("No se puede agregar el Expediente al repositorio ya que Id de Usuario inválido.");
        }
        //valida si la caratula del expediente no esta vacio
        if (string.IsNullOrEmpty(expediente.Caratula))
        {
            throw new Exception("No se puede agregar el Expediente al repositorio ya que la Caratula esta Vacia.");
        }
        return (mensajeError == "");
    }
}
