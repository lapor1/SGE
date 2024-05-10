namespace SGE.Aplicacion;

public static class ExpedienteValidador
{

    public static void ValidarUser(Expediente expediente)
    {
        if (expediente.IdUsuarioUM <= 0) 
        {
            throw new Exception("Id de Usuario inválido");
        }
    }

    public static void ValidarCaratula(Expediente expediente)
    {
        if (string.IsNullOrEmpty(expediente.Caratula))
        {
            throw new Exception("La caratula esta Vacia!");
        }
    }

}
