﻿using Lib_entidades;

namespace Lib_presentaciones.Interfaces
{
    public interface IAuditoriasPresentacion
    {
        Task<List<Auditorias>> Listar();
        Task<List<Auditorias>> Buscar(Auditorias entidad, string tipo);
        Task<Auditorias> Guardar(Auditorias entidad);
        Task<Auditorias> Modificar(Auditorias entidad);
        Task<Auditorias> Borrar(Auditorias entidad);
    }
}