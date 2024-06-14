using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Validadores;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Excepciones;
using SGE.Aplicacion.Enumerativos;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion autorizacion, ExpedienteValidador validador)
{
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        // Verifica si el tramite es valido
        if (validador.Validar(expediente, out string mensajeError)) {
        
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
            }

        }
        else {
            throw new ValidacionException(mensajeError);
        }
    }
}