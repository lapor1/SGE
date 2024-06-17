using SGE.Aplicacion.Enumerativos;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Servicios;

public class ServicioAutorizacion(IUsuarioRepositorio repoU) : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso) {
        
        var usuarioConsultarId = new CasoDeUsoUsuarioConsultaPorId(repoU);
        Usuario? usuario = usuarioConsultarId.Ejecutar(IdUsuario);

        if (usuario != null)
        {
            return usuario.ListaPermisos.Exists(p => p == permiso);
        }
        else
        {
            return false;
        }
    }
}