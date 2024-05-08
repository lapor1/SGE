namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador)
{
    public void Ejecutar(Tramite tramite)
    {
        if (!validador.Validar(tramite, out string mensajeError))
        {
            throw new Exception(mensajeError);
        }
        repo.AgregarTramiteAlta( tramite );
    }
}