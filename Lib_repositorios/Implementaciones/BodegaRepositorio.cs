using Lib_entidades;
using Lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace Lib_repositorios.Implementaciones
{
    public class BodegaRepositorio : IBodegaRepositorio
    {
        private Conexion? conexion = null;

        public BodegaRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Bodega> Listar()
        {
            return conexion!.Listar<Bodega>();
        }

        public List<Bodega> Buscar(Expression<Func<Bodega, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Bodega Guardar(Bodega entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Bodega Modificar(Bodega entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Bodega Borrar(Bodega entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}