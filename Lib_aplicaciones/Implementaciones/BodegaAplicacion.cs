using Lib_entidades;
using Lib_aplicaciones.Interfaces;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_aplicaciones.Implementaciones
{
    public class BodegaAplicacion : I_BodegaAplicacion
    {
        private IBodegaRepositorio? iRepositorio = null;

        public BodegaAplicacion(IBodegaRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Bodega Borrar(Bodega entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Bodega Guardar(Bodega entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Bodega> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Bodega> Buscar(Bodega entidad, string tipo)
        {
            Expression<Func<Bodega, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Bodega Modificar(Bodega entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Bodega Calcular(Bodega entidad)
        {
            return entidad;
        }
    }
}