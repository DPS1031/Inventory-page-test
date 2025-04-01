using Lib_entidades;

namespace Lib_presentaciones.Interfaces
{
    public interface IProductoPresentacion
    {
        Task<List<Producto>> Listar();
        Task<List<Producto>> Buscar(Producto entidad, string tipo);
        Task<Producto> Guardar(Producto entidad, string Usuario);
        Task<Producto> Modificar(Producto entidad, string Usuario);
        Task<Producto> Borrar(Producto entidad, string Usuario);
    }
}