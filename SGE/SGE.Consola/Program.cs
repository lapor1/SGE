using SGE.Aplicacion;
using SGE.Repositorios;

var servicio = new ServicioAutorizacionProvisorio();
Console.WriteLine(servicio.PoseeElPermiso(1, Permiso.TramiteBaja) + "\n");
Console.WriteLine(servicio.PoseeElPermiso(0, Permiso.TramiteBaja) + "\n");

