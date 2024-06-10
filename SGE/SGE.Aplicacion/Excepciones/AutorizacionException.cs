namespace SGE.Aplicacion;

public class AutorizacionException : Exception  // Notar que ahora hereda de "Exception"
{
    public AutorizacionException() {}

    public AutorizacionException(string? message) : base(message) {}

    public AutorizacionException(string? message, Exception? innerException) : base(message, innerException) {}
}