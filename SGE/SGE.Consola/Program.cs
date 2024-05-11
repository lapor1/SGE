using SGE.Aplicacion;
using SGE.Repositorios;

/*
var servicio = new ServicioAutorizacionProvisorio();
Console.WriteLine(servicio.PoseeElPermiso(1, Permiso.TramiteBaja) + "\n");
Console.WriteLine(servicio.PoseeElPermiso(0, Permiso.TramiteBaja) + "\n");
*/

int i = 0;

try
{
    DividirExcepcion(i);
    i = 1/i;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("fin");

void DividirExcepcion (int i)
{
    if (i == 0)
    {
        throw new Exception("no se puede dividir por cero");
    }
}