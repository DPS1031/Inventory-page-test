using System.ComponentModel.DataAnnotations;

namespace Lib_entidades
{
    public class Proveedor
    {
        [Key] public int Id { get; set; }
        public string? CodigoProveedor { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Contacto { get; set; }

        public bool Validar()
        {
            return true;

        }

    }
}
