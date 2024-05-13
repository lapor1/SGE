using System.Linq.Expressions;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion, ValidacionException exception)
{
    private static int id = 0;  // buscar en el repositorio el id maximo

    //El 
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        try
        {
            // Verifica el expediente utilizando el método VerificarExpediente del objeto exception
            exception.VerificarExpediente(expediente);

            // Verifica si el usuario tiene el permiso necesario para dar de alta un expediente
            if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
            {
                id++; //incrementa el id
                expediente.IdExpediente = id; //Asigna el nuevo id al expediente
                expediente.FechaHoraCreacion = DateTime.Now; // Establece la fecha y hora de creación del expediente como la fecha y hora actuales
                expediente.FechaHoraModificacion = DateTime.Now; // Establece la fecha y hora de modificación del expediente como la fecha y hora actuales
                expediente.IdUsuarioUM = idUsuario;// Asigna el id del usuario que realiza la modificación al expediente
                repo.AgregarExpedienteAlta( expediente );// Agrega el expediente al repositorio llamando al método AgregarExpedienteAlta del objeto repo
            }
        }
        //Manejo de excepciones
        catch (Exception ex)
        {
            // Imprime el mensaje de la excepción en la consola
            Console.WriteLine(ex.Message);
        }
    }
}