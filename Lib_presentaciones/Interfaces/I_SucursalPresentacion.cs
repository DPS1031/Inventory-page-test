using Lib_entidades;

namespace Lib_presentaciones.Interfaces
{
    public interface ISucursalPresentacion
    {
        Task<List<Sucursal>> Listar();
        Task<List<Sucursal>> Buscar(Sucursal entidad, string tipo);
        Task<Sucursal> Guardar(Sucursal entidad);
        Task<Sucursal> Modificar(Sucursal entidad);
        Task<Sucursal> Borrar(Sucursal entidad);
    }
}