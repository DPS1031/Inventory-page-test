using System.ComponentModel.DataAnnotations;

namespace Lib_entidades
{
    public class Producto
    {
        [Key] public int Id { get; set; }
        public string? CodigoProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public bool Validar()
        {
            return true;

        }

    }
}
