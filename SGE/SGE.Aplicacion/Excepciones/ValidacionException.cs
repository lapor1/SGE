namespace SGE.Aplicacion;

class ValidacionException
{
    // [ ]  La excepción ValidacionException debe ser lanzada cuando una entidad no cumple con los requisitos
    //      exigidos y, por lo tanto, no supera la validación establecida.

    //aca hay que divir de alguna manera el manejo para que cuando se diga que no se cumple una
    //validacion, lo pueda decir dependiendo del motivo
    
    public ValidacionException (out string mensajeError) {
        
        mensajeError = $"Id de Usuario invalido";
        mensajeError = $"Contenido vacio del tramite";
        mensajeError = $"La carátula de un expediente no puede estar vacía.";
    }
}
