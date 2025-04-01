using Lib_entidades;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_repositorios.Implementaciones
{
    public class AuditoriasRepositorio : IAuditoriasRepositorio
    {
        private Conexion? conexion = null;

        public AuditoriasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Auditorias> Listar()
        {
            return conexion!.Listar<Auditorias>();
        }

        public List<Auditorias> Buscar(Expression<Func<Auditorias, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Auditorias Guardar(string Usuario, string Accion)
        {
            Auditorias entidad = new Auditorias();
            entidad.Accion = Accion;
            entidad.Usuario = Usuario;
            entidad.Fecha = DateTime.Now;
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Auditorias Modificar(Auditorias entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Auditorias Borrar(Auditorias entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}