namespace Lib_comunicaciones.Interfaces
{
    public interface IProductoComunicacion
    {
        Task<Dictionary<string, object>> Listar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Buscar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Guardar(Dictionary<string, object> datos, string Usuario);
        Task<Dictionary<string, object>> Modificar(Dictionary<string, object> datos, string Usuario);
        Task<Dictionary<string, object>> Borrar(Dictionary<string, object> datos, string Usuario);
    }
}