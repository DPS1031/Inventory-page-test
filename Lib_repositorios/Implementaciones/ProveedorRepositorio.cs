using Lib_entidades;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_repositorios.Implementaciones
{
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private Conexion? conexion = null;

        public ProveedorRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Proveedor> Listar()
        {
            return conexion!.Listar<Proveedor>();
        }

        public List<Proveedor> Buscar(Expression<Func<Proveedor, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Proveedor Guardar(Proveedor entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Proveedor Modificar(Proveedor entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Proveedor Borrar(Proveedor entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}