using System.ComponentModel.DataAnnotations;

namespace Lib_entidades
{
    public class Auditorias
    {
        [Key] public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Accion { get; set; }
        public DateTime? Fecha { get; set; }

        public bool Validar()
        {
            return true;
            
        }
    }
}
