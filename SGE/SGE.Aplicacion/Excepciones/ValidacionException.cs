namespace SGE.Aplicacion;

public class ValidacionException : Exception
{
    public ValidacionException() {}
    public ValidacionException(string message) : base(message) {}

    public ValidacionException(string message, Exception inner) : base(message, inner) {}
    
}

// Antes: 
/*
    public class ValidacionException(TramiteValidador validadorTramite, ExpedienteValidador validadorExpediente)
    {
        public void VerificarExpediente(Expediente expediente)
        {
            //la excepcion que da el mensaje de error de la caratula vacia 
            if (!validadorExpediente.Validar(expediente, out string mensajeError))
            {
                throw new Exception(mensajeError);
            }   
        }
        public void VerificarTramite(Tramite tramite)
        {
            //la excepcion que da el mensaje de error de el contenido vacio
            if (!validadorTramite.Validar(tramite, out string mensajeError))
            {
                throw new Exception(mensajeError);
            }
        }
    }

*/
