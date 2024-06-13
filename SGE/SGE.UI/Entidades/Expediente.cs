namespace SGE.UI.Entidades;

public class Expediente
{   
    public int Id { get; set;}
    public string? Caratula { get; set;}

    public static List<Expediente> GetLista()
    {
        return new List<Expediente>() {
            new Expediente() { Id = 0, Caratula = "sas"}
        };
    }
}
