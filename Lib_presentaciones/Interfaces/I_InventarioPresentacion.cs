using Lib_entidades;

namespace Lib_presentaciones.Interfaces
{
    public interface IInventarioPresentacion
    {
        Task<List<Inventario>> Listar();
        Task<List<Inventario>> Buscar(Inventario entidad, string tipo);
        Task<Inventario> Guardar(Inventario entidad);
        Task<Inventario> Modificar(Inventario entidad);
        Task<Inventario> Borrar(Inventario entidad);
    }
}