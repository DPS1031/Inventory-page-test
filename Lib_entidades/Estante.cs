using System.ComponentModel.DataAnnotations;

namespace Lib_entidades
{
    public class Estante
    {
        [Key] public int Id { get; set; }
        public string? CodigoEstante { get; set; }
        public string? CodigoBodega { get; set; }
        public string? Nombre { get; set; }

        public bool Validar()
        {
            return true;

        }

    }
}
