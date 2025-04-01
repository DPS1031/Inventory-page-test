using Lib_entidades;
using System.Linq.Expressions;

namespace Lib_repositorios.Interfaces
{
    public interface IAuditoriasRepositorio
    {
        void Configurar(string string_conexion);
        List<Auditorias> Listar();
        List<Auditorias> Buscar(Expression<Func<Auditorias, bool>> condiciones);
        Auditorias Guardar(string Usuario, string Accion);
        Auditorias Modificar(Auditorias entidad);
        Auditorias Borrar(Auditorias entidad);
    }
}