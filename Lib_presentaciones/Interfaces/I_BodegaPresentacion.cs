using Lib_entidades;

namespace Lib_presentaciones.Interfaces
{
    public interface IBodegaPresentacion
    {
        Task<List<Bodega>> Listar();
        Task<List<Bodega>> Buscar(Bodega entidad, string tipo);
        Task<Bodega> Guardar(Bodega entidad);
        Task<Bodega> Modificar(Bodega entidad);
        Task<Bodega> Borrar(Bodega entidad);
    }
}