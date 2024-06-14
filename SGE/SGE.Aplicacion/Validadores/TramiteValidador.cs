using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Validadores;

public class TramiteValidador
{
    public bool Validar(Tramite tramite, out string mensajeError)
    {
        mensajeError = "";
        //valida si el usuario es valido
        if (tramite.IdUsuarioUM <= 0) 
        {
            mensajeError = "No se puede agregar el Tramite al repositorio ya que Id de Usuario inválido.";
           // throw new Exception("No se puede agregar el Tramite al repositorio ya que Id de Usuario inválido.");
        }
        //valida si el contenido del expediente no esta vacio
        if (string.IsNullOrEmpty(tramite.Contenido))
        {
            mensajeError = "No se puede agregar el Tramite al repositorio ya que el Contenido esta Vacio.";
            //throw new Exception("No se puede agregar el Tramite al repositorio ya que el Contenido esta Vacio.");
        }
        return (mensajeError == "");
    }
}
