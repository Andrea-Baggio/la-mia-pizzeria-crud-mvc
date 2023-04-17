using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Condiment> Condiments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=la_mia_pizzeria_db;Integrated Security=True;Pooling=False;TrustServerCertificate=true");
        }

        public void Seed()
        {
            var postSeed = new Post[]
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

            if (!Posts.Any())
            {
                Posts.AddRange(postSeed);
            }

            if (!Categorie.Any())
            {
                var seed = new Categoria[]
                {
                    new Categoria
                    {
                        NomeCategoria = "Pizze classiche",
                        Posts = postSeed //mettendo il seed dei post fuori dall'if e scrivendo questa stringa faccio in modo che tutti post del seed vengano associati a questa categoria
                    },
                    new Categoria
                    {
                        NomeCategoria = "Pizze bianche" 
                    },
                    new Categoria
                    {
                        NomeCategoria = "Pizze vegetariane"
                    },
                    new Categoria
                    {
                        NomeCategoria = "Pizze di mare"
                    },
                    new Categoria
                    {
                        NomeCategoria = "Pizze gourmet"
                    }
                };
                Categorie.AddRange(seed);
            }

            if (!Condiments.Any())
            {
                var seed = new Condiment[]
                {
                    new Condiment
                    {
                        CondimentName = "Prosciutto",
                        Posts = postSeed 
                    },
                    new Condiment
                    {
                        CondimentName = "Ananas"
                    },
                    new Condiment
                    {
                        CondimentName = "Carciofini"
                    },
                    new Condiment
                    {
                        CondimentName = "Olive"
                    },
                    new Condiment
                    {
                        CondimentName = "Noci"
                    },
                    new Condiment
                    {
                        CondimentName = "Radicchio"
                    },
                    new Condiment
                    {
                        CondimentName = "Gorgonzola"
                    }
                };

                Condiments.AddRange(seed);
            }

            SaveChanges();
        }

    }
}
