namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion)
{
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        // Verifica si el usuario tiene el permiso necesario para modificar un expediente
        if (autorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion))
        {
            // Actualiza la fecha y hora de modificación del expediente
            expediente.FechaHoraModificacion = DateTime.Now;
            // Asigna el id del usuario que modifica el expediente
            expediente.IdUsuarioUM = idUsuario;
             // Intenta modificar el expediente en el repositorio y guarda si fue encontrado y modificado correctamente
            bool encontrado = repo.ModificarExpediente( expediente );
            
            if (!encontrado)
            {
                throw new Exception("El Expediente no se puede modificar porque no existe en el repositorio");
            }

/*
            try
            {
                excepcion.ModificacionExpediente(encontrado);
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
            */
        }
    }
}