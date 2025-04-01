using Lib_entidades;
using Lib_aplicaciones.Interfaces;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_aplicaciones.Implementaciones
{
    public class EstanteAplicacion : I_EstanteAplicacion
    {
        private IEstanteRepositorio? iRepositorio = null;

        public EstanteAplicacion(IEstanteRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Estante Borrar(Estante entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Estante Guardar(Estante entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Estante> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Estante> Buscar(Estante entidad, string tipo)
        {
            Expression<Func<Estante, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Estante Modificar(Estante entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Estante Calcular(Estante entidad)
        {
            return entidad;
        }
    }
}