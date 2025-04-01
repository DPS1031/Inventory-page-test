using Lib_entidades;
using System.Linq.Expressions;

namespace Lib_repositorios.Interfaces
{
    public interface IBodegaRepositorio
    {
        void Configurar(string string_conexion);
        List<Bodega> Listar();
        List<Bodega> Buscar(Expression<Func<Bodega, bool>> condiciones);
        Bodega Guardar(Bodega entidad);
        Bodega Modificar(Bodega entidad);
        Bodega Borrar(Bodega entidad);
    }
}