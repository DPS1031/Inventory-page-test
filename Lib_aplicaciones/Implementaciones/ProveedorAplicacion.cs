using Lib_entidades;
using Lib_aplicaciones.Interfaces;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_aplicaciones.Implementaciones
{
    public class ProveedorAplicacion : I_ProveedorAplicacion
    {
        private IProveedorRepositorio? iRepositorio = null;

        public ProveedorAplicacion(IProveedorRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Proveedor Borrar(Proveedor entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Proveedor Guardar(Proveedor entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Proveedor> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Proveedor> Buscar(Proveedor entidad, string tipo)
        {
            Expression<Func<Proveedor, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Proveedor Modificar(Proveedor entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Proveedor Calcular(Proveedor entidad)
        {
            return entidad;
        }
    }
}