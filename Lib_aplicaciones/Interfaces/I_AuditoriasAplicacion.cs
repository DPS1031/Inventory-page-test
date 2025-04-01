using Lib_entidades;

namespace Lib_aplicaciones.Interfaces
{
    public interface I_AuditoriasAplicacion
    {
        void Configurar(string string_conexion);
        List<Auditorias> Buscar(Auditorias entidad, string tipo);
        List<Auditorias> Listar();
        void Guardar(string Usuario, string Accion);
        Auditorias Modificar(Auditorias entidad);
        Auditorias Borrar(Auditorias entidad);
    }
}