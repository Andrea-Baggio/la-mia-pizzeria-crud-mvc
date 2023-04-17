namespace la_mia_pizzeria_static.Models
{
    public class Condiment
    {
        public int Id { get; set; }
        public string CondimentName { get; set; } = string.Empty;

        public IEnumerable<Post>? Posts { get; set; }
    }
}
