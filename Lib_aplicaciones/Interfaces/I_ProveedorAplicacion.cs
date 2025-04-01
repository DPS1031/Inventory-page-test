using Lib_entidades;

namespace Lib_aplicaciones.Interfaces
{
    public interface I_ProveedorAplicacion
    {
        void Configurar(string string_conexion);
        List<Proveedor> Buscar(Proveedor entidad, string tipo);
        List<Proveedor> Listar();
        Proveedor Guardar(Proveedor entidad);
        Proveedor Modificar(Proveedor entidad);
        Proveedor Borrar(Proveedor entidad);
    }
}