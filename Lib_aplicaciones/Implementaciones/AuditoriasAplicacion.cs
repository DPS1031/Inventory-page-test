using Lib_entidades;
using Lib_aplicaciones.Interfaces;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_aplicaciones.Implementaciones
{
    public class AuditoriasAplicacion : I_AuditoriasAplicacion
    {
        private IAuditoriasRepositorio? iRepositorio = null;

        public AuditoriasAplicacion(IAuditoriasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Auditorias Borrar(Auditorias entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public void Guardar(string Usuario, string Accion)
        {

             iRepositorio!.Guardar(Usuario, Accion);

        }

        public List<Auditorias> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Auditorias> Buscar(Auditorias entidad, string tipo)
        {
            Expression<Func<Auditorias, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "USUARIO": condiciones = x => x.Usuario!.Contains(entidad.Usuario!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Auditorias Modificar(Auditorias entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Auditorias Calcular(Auditorias entidad)
        {
            return entidad;
        }
    }
}