using Lib_entidades;

namespace Lib_aplicaciones.Interfaces
{
    public interface I_InventarioAplicacion
    {
        void Configurar(string string_conexion);
        List<Inventario> Buscar(Inventario entidad, string tipo);
        List<Inventario> Listar();
        Inventario Guardar(Inventario entidad);
        Inventario Modificar(Inventario entidad);
        Inventario Borrar(Inventario entidad);
    }
}