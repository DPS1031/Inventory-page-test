using Lib_entidades;

namespace Lib_presentaciones.Interfaces
{
    public interface IEstantePresentacion
    {
        Task<List<Estante>> Listar();
        Task<List<Estante>> Buscar(Estante entidad, string tipo);
        Task<Estante> Guardar(Estante entidad);
        Task<Estante> Modificar(Estante entidad);
        Task<Estante> Borrar(Estante entidad);
    }
}