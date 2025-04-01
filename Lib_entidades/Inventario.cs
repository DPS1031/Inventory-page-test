using System.ComponentModel.DataAnnotations;

namespace Lib_entidades
{
    public class Inventario
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoBodega { get; set; }
        public string? CodigoEstante { get; set; }
        public string? CodigoProducto { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Estado { get; set; }


        public bool Validar()
        {
                    return true;
            
        }
    }
}
