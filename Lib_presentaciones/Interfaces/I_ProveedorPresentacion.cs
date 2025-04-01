using Lib_entidades;

namespace Lib_presentaciones.Interfaces
{
    public interface IProveedorPresentacion
    {
        Task<List<Proveedor>> Listar();
        Task<List<Proveedor>> Buscar(Proveedor entidad, string tipo);
        Task<Proveedor> Guardar(Proveedor entidad);
        Task<Proveedor> Modificar(Proveedor entidad);
        Task<Proveedor> Borrar(Proveedor entidad);
    }
}