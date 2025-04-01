using Lib_entidades;
using System.Linq.Expressions;

namespace Lib_repositorios.Interfaces
{
    public interface IEstanteRepositorio
    {
        void Configurar(string string_conexion);
        List<Estante> Listar();
        List<Estante> Buscar(Expression<Func<Estante, bool>> condiciones);
        Estante Guardar(Estante entidad);
        Estante Modificar(Estante entidad);
        Estante Borrar(Estante entidad);
    }
}