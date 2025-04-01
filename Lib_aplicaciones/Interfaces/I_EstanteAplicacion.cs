using Lib_entidades;

namespace Lib_aplicaciones.Interfaces
{
    public interface I_EstanteAplicacion
    {
        void Configurar(string string_conexion);
        List<Estante> Buscar(Estante entidad, string tipo);
        List<Estante> Listar();
        Estante Guardar(Estante entidad);
        Estante Modificar(Estante entidad);
        Estante Borrar(Estante entidad);
    }
}