namespace SGE.Aplicacion;

public abstract class CasosDeUso (IUsuarioRepositorio repoU)
{
    protected IUsuarioRepositorio Repositorio {get;} = repoU;
}