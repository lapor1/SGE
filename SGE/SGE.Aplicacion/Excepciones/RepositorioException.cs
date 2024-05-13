﻿using System.Diagnostics;

namespace SGE.Aplicacion;

//todas las excepciones para todos los casos de uso, tanto de alta, baja, modificacion y consulta
public class RepositorioException
{
    public void BajaExpediente(bool encontrado)
    {
        if (!encontrado)
        {
            throw new Exception("El Expediente no se puede eliminar porque no existe en el respositorio");
        }
    }

    public void ModificacionExpediente(bool encontrado)
    {
        if (!encontrado)
        {
            throw new Exception("El Expediente no se puede modificar porque no existe en el repositorio");
        }
    }

    public void ConsultarExpediente(Expediente expediente)
    {
        if (expediente == null)
        {
             throw new Exception("El Expediente no se puede acceder porque no existe en el respositorio");
        }
    }

    public void BajaTramite(bool encontrado)
    {
        if (!encontrado)
        {
            throw new Exception("El tramite no se puede eliminar porque no existe en el respositorio");
        }
    }

    public void ModificacionTramite(bool encontrado)
    {
        if (!encontrado)
        {
            throw new Exception("El tramite no se puede modificar porque no existe en el repositorio");
        }
    }

    public void ConsultarTramite(Tramite tramite)
    {
        if (tramite == null)
        {
             throw new Exception("El tramite no se puede acceder porque no existe en el respositorio");
        }
    }
}