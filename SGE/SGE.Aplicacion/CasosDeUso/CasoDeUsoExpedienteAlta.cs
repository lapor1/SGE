using System.Linq.Expressions;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion, ValidacionException exception)
{
    private static int id = 0;  // buscar en el repositorio el id maximo
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        //validador.ValidarUseruarioExpediente(expediente);
        //validador.ValidarCaratulaExpediente(expediente);
        
        /*  asi es como esta en la teoria
        if (!validador.Validar(expediente, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
        */

        try
        {
            exception.VerificarExpediente(expediente);

            if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
            {
                id++;
                expediente.IdExpediente = id;
                expediente.FechaHoraCreacion = DateTime.Now;
                expediente.FechaHoraModificacion = DateTime.Now;
                expediente.IdUsuarioUM = idUsuario;
                repo.AgregarExpedienteAlta( expediente );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}