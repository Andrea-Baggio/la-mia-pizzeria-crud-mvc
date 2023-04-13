using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=la_mia_pizzeria_db;Integrated Security=True;Pooling=False;TrustServerCertificate=true");
        }

        public void Seed()
        {
            if (!Posts.Any())
            {
                var seed = new Post[]
                {
                    new Post
                    {
                        NomePizza = "Margherita",
                        Immagine = "https://picsum.photos/100",
                        Ingredienti = "Pomodoro, Mozzarella, Basilico",
                        Prezzo = 5.00m
                    },
                    new Post
                    {
                        NomePizza = "Marinara",
                        Immagine = "https://picsum.photos/100",
                        Ingredienti = "Pomodoro, Aglio, Origano",
                        Prezzo = 4.00m
                    }
                };

                Posts.AddRange(seed);

                SaveChanges();
            }
        }
    }
}
