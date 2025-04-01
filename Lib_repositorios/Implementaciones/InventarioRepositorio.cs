using Lib_entidades;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_repositorios.Implementaciones
{
    public class InventarioRepositorio : IInventarioRepositorio
    {
        private Conexion? conexion = null;

        public InventarioRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Inventario> Listar()
        {
            return conexion!.Listar<Inventario>();
        }

        public List<Inventario> Buscar(Expression<Func<Inventario, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Inventario Guardar(Inventario entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Inventario Modificar(Inventario entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Inventario Borrar(Inventario entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}