using Lib_entidades;

namespace Lib_aplicaciones.Interfaces
{
    public interface I_ProductoAplicacion
    {
        void Configurar(string string_conexion);
        List<Producto> Buscar(Producto entidad, string tipo);
        List<Producto> Listar();
        Producto Guardar(Producto entidad);
        Producto Modificar(Producto entidad);
        Producto Borrar(Producto entidad);
    }
}