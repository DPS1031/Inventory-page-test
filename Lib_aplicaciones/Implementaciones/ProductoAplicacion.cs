using Lib_entidades;
using Lib_aplicaciones.Interfaces;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_aplicaciones.Implementaciones
{
    public class ProductoAplicacion : I_ProductoAplicacion
    {
        private IProductoRepositorio? iRepositorio = null;

        public ProductoAplicacion(IProductoRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Producto Borrar(Producto entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Producto Guardar(Producto entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Producto> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Producto> Buscar(Producto entidad, string tipo)
        {
            Expression<Func<Producto, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Producto Modificar(Producto entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Producto Calcular(Producto entidad)
        {
            return entidad;
        }
    }
}