using SGE.Aplicacion;
using SGE.Repositorios;



var excepcion = new AutorizacionException();
var servicio = new ServicioAutorizacionProvisorio(excepcion);
Console.WriteLine(servicio.PoseeElPermiso(1, Permiso.TramiteBaja) + "\n");
Console.WriteLine(servicio.PoseeElPermiso(0, Permiso.TramiteBaja) + "\n");


