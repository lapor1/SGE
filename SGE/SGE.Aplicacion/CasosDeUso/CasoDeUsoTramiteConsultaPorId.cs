namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorId(ITramiteRepositorio repo)
{
    public Tramite? Ejecutar(int id)
    {
        // Consulta el trámite por su id en el repositorio y guarda si fue encontrado correctamente
        bool encontrado = repo.TramiteConsultarPorId(out Tramite? tramite, id);
        //try
        //{
            // Verifica si se encontró el trámite correctamente
            if (tramite == null){
                //excepcion.ConsultarTramite(tramite);
                throw new RepositorioException("El tramite no se puede acceder porque no existe en el respositorio");
            }
            else {
                // Devuelve el trámite consultado
                return tramite;
            }
            
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