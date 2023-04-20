using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class PostFormModel
    {
        public Post Post { get; set; } = new Post();
		public IEnumerable<Categoria> Categorie { get; set; } = Enumerable.Empty<Categoria>();

        public IEnumerable<SelectListItem> Condiments { get; set; } = Enumerable.Empty<SelectListItem>();
        public List<string> SelectedCondiments { get; set; } = new();

    }
}
