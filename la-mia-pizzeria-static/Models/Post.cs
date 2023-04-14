using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Post
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Inserire un nome valido")]
		[StringLength(50, ErrorMessage = "Il nome deve avere meno di 50 caratteri.")]
		public string NomePizza { get; set; } = string.Empty;
        public string Immagine { get; set; } = string.Empty;

        [Required(ErrorMessage = "Inserire una descrizione valida")]
		[StringLength(150, ErrorMessage = "La descrizione deve avere meno di 150 caratteri.")]
		public string Ingredienti { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Il valore deve essere maggiore o uguale a 1")]
        public decimal Prezzo { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
