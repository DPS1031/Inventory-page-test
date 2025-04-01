using Lib_entidades;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_repositorios.Implementaciones
{
    public class SucursalRepositorio : ISucursalRepositorio
    {
        private Conexion? conexion = null;

        public SucursalRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Sucursal> Listar()
        {
            return conexion!.Listar<Sucursal>();
        }

        public List<Sucursal> Buscar(Expression<Func<Sucursal, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Sucursal Guardar(Sucursal entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Sucursal Modificar(Sucursal entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Sucursal Borrar(Sucursal entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}