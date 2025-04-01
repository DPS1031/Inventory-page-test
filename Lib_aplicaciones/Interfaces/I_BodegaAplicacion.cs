using Lib_entidades;

namespace Lib_aplicaciones.Interfaces
{
    public interface I_BodegaAplicacion
    {
        void Configurar(string string_conexion);
        List<Bodega> Buscar(Bodega entidad, string tipo);
        List<Bodega> Listar();
        Bodega Guardar(Bodega entidad);
        Bodega Modificar(Bodega entidad);
        Bodega Borrar(Bodega entidad);
    }
}