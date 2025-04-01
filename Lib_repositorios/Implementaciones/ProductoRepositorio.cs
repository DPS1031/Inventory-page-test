using Lib_entidades;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_repositorios.Implementaciones
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private Conexion? conexion = null;

        public ProductoRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Producto> Listar()
        {
            return conexion!.Listar<Producto>();
        }

        public List<Producto> Buscar(Expression<Func<Producto, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Producto Guardar(Producto entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Producto Modificar(Producto entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Producto Borrar(Producto entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}