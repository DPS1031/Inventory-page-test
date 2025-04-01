using Lib_entidades;
using System.Linq.Expressions;

namespace Lib_repositorios.Interfaces
{
    public interface IProveedorRepositorio
    {
        void Configurar(string string_conexion);
        List<Proveedor> Listar();
        List<Proveedor> Buscar(Expression<Func<Proveedor, bool>> condiciones);
        Proveedor Guardar(Proveedor entidad);
        Proveedor Modificar(Proveedor entidad);
        Proveedor Borrar(Proveedor entidad);
    }
}