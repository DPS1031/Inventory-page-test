using System.ComponentModel.DataAnnotations;

namespace Lib_entidades
{
    public class Sucursal
    {
        [Key] public int Id { get; set; }
        public string? CodigoSucursal { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }

        public bool Validar()
        {
            return true;

        }

    }
}
