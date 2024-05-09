using System;
using System.Collections.Generic;

using SGE.Aplicacion;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Permiso> Permisos { get; set; }

    public Usuario(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
        Permisos = new List<Permiso>();
    }

    // Método para agregar un permiso al usuario
    public void AgregarPermiso(Permiso permiso)
    {
        Permisos.Add(permiso);
    }

    // Método para verificar si el usuario tiene un permiso específico
    public bool TienePermiso(Permiso permiso)
    {
        return Permisos.Contains(permiso);
    }
}