using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion.CasosDeUso;

public abstract class CasosDeUso (IUsuarioRepositorio repoU)
{
    protected IUsuarioRepositorio Repositorio {get;} = repoU;
}