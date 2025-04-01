using Lib_entidades;
using System.Linq.Expressions;

namespace Lib_repositorios.Interfaces
{
    public interface ISucursalRepositorio
    {
        void Configurar(string string_conexion);
        List<Sucursal> Listar();
        List<Sucursal> Buscar(Expression<Func<Sucursal, bool>> condiciones);
        Sucursal Guardar(Sucursal entidad);
        Sucursal Modificar(Sucursal entidad);
        Sucursal Borrar(Sucursal entidad);
    }
}