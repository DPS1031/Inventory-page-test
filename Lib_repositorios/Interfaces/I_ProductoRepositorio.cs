using Lib_entidades;
using System.Linq.Expressions;

namespace Lib_repositorios.Interfaces
{
    public interface IProductoRepositorio
    {
        void Configurar(string string_conexion);
        List<Producto> Listar();
        List<Producto> Buscar(Expression<Func<Producto, bool>> condiciones);
        Producto Guardar(Producto entidad);
        Producto Modificar(Producto entidad);
        Producto Borrar(Producto entidad);
    }
}