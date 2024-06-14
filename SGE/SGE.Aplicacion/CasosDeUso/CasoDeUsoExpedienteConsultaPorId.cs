using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Excepciones;

namespace SGE.Aplicacion.CasosDeUso;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repo)
{
    public Expediente? Ejecutar(int id)
    {
        //try
        //{
            // Llama al método del repositorio para consultar un expediente por su id
            repo.ExpedienteConsultarPorId(out Expediente? expediente, id);
            // Verifica si el expediente consultado es válido

            if ( expediente == null )
            {
                //excepcion.ConsultarExpediente(expediente);
                throw new RepositorioException("El Expediente no se puede acceder porque no existe en el respositorio");
            }
    
            // Devuelve el expediente consultado
            return expediente;
        /*
        }
        catch (Exception ex)
        {
            Console.WriteLine( ex.Message );
        }
        // Si hay algún error, devuelve null
        return null;
        */
    }
}