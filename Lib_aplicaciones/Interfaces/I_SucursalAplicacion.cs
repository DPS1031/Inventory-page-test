using Lib_entidades;

namespace Lib_aplicaciones.Interfaces
{
    public interface I_SucursalAplicacion
    {
        void Configurar(string string_conexion);
        List<Sucursal> Buscar(Sucursal entidad, string tipo);
        List<Sucursal> Listar();
        Sucursal Guardar(Sucursal entidad);
        Sucursal Modificar(Sucursal entidad);
        Sucursal Borrar(Sucursal entidad);
    }
}