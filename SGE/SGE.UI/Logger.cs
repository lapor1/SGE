namespace SGE.UI;

public class Logger
{
    public int IdUsuario { get; set; } = 0;
    public string? Nombre { get; set; } = "";
    public bool Logueado { get; set; } = false;
    public bool PermisoLectura { get; set; } = false;
}
