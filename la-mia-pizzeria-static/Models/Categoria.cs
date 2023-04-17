using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Inserire un nome valido")]
        [StringLength(50, ErrorMessage = "Il nome deve avere meno di 50 caratteri.")]
        public string NomeCategoria { get; set; } = string.Empty;

         public IEnumerable<Post>? Posts { get; set; }
    }
}
