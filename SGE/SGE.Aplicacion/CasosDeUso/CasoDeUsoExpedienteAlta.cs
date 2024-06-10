using System.Linq.Expressions;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion, ExpedienteValidador validador)
{
    // Inicializa identificador en 0
    private static int id = 0;

    private void IniciarId()
    {
        var listExpediente = new CasoDeUsoListarExpedientes(repo);
        List<Expediente> expedientes = listExpediente.Ejecutar();
        if (expedientes.Count > 0){
            id = expedientes[expedientes.Count - 1].IdExpediente + 1;
        }
    }

    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        
        expediente.IdUsuarioUM = idUsuario;// Asigna el id del usuario que realiza la modificación al expediente
        
        // Verifica el expediente utilizando el método VerificarExpediente del objeto excepcion
        if (!validador.Validar(expediente, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        else {
            // Verifica si el usuario tiene el permiso necesario para dar de alta un expediente
            if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
            {
                if (id == 0){
                    IniciarId();   //lee del repositorio cual es el ultimo IdExpediente para que no se sobre-escriba
                } else {
                    id++;   //incrementa el Id del expediente
                }
                expediente.IdExpediente = id; //Asigna el nuevo id al expediente
                expediente.FechaHoraCreacion = DateTime.Now; // Establece la fecha y hora de creación del expediente como la fecha y hora actuales
                expediente.FechaHoraModificacion = DateTime.Now; // Establece la fecha y hora de modificación del expediente como la fecha y hora actuales
                repo.AgregarExpedienteAlta( expediente );// Agrega el expediente al repositorio llamando al método AgregarExpedienteAlta del objeto repo
            }
            else
            {
                throw new AutorizacionException("El usuario no cuenta con los permisos adecuados para ejecutar esta accion");
            }
        }

    }
}