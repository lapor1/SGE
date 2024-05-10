namespace SGE.Aplicacion;

class RepositorioException
{
    // [ ]  La excepción RepositorioException debe ser lanzada cuando la entidad que 
    //se intenta eliminar, modificar o acceder no existe en el repositorio correspondiente.

    //aca hay que divir de alguna manera el manejo para que cuando se diga que no se cumple una
    //validacion, lo pueda decir dependiendo del motivo

    public RepositorioException (out string mensajeError) {
        
        mensajeError = $"El tramite no se puede modificar porque no existe en el repositorio";
        mensajeError = $"El tramite no se puede eliminar porque no existe en el respositorio";
        mensajeError = $"El tramite no se puede accder porque no existe en el respositorio ";

        mensajeError = $"El Expediente no se puede modificar porque no existe en el repositorio";
        mensajeError = $"El Expediente no se puede eliminar porque no existe en el respositorio";
        mensajeError = $"El Expediente no se puede accder porque no existe en el respositorio ";
    }
}
