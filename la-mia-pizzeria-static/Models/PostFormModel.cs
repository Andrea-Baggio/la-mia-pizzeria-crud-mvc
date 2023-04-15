namespace la_mia_pizzeria_static.Models
{
    public class PostFormModel
    {
        public Post Post { get; set; } = new Post();
        public IEnumerable<Categoria> Categorie { get; set; } = Enumerable.Empty<Categoria>();
    }
}
