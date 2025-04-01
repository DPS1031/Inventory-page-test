using Lib_entidades;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_repositorios.Implementaciones
{
    public class EstanteRepositorio : IEstanteRepositorio
    {
        private Conexion? conexion = null;

        public EstanteRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Estante> Listar()
        {
            return conexion!.Listar<Estante>();
        }

        public List<Estante> Buscar(Expression<Func<Estante, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Estante Guardar(Estante entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Estante Modificar(Estante entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Estante Borrar(Estante entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}