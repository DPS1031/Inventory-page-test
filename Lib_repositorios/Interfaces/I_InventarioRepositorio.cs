using Lib_entidades;
using System.Linq.Expressions;

namespace Lib_repositorios.Interfaces
{
    public interface IInventarioRepositorio
    {
        void Configurar(string string_conexion);
        List<Inventario> Listar();
        List<Inventario> Buscar(Expression<Func<Inventario, bool>> condiciones);
        Inventario Guardar(Inventario entidad);
        Inventario Modificar(Inventario entidad);
        Inventario Borrar(Inventario entidad);
    }
}