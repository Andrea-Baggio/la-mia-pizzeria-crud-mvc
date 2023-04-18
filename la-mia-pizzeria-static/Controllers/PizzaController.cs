using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using var ctx = new PizzaContext();
            var posts = ctx.Posts.Include(p => p.Categoria).ToArray();

            return View(posts);
        }

        public IActionResult Detail(int id)
        {
            using var ctx = new PizzaContext();
            var post = ctx.Posts
                .Include(p => p.Categoria)
			    .Include(p => p.Condiments)
                .SingleOrDefault(p => p.Id == id);


			if (post is null)
            {
                return View("NotFound", "Post not found.");
            }

            return View(post);
        }

        public IActionResult Create()
        {
            using var ctx = new PizzaContext();
            var formModel = new PostFormModel
            {
                Categorie = ctx.Categorie.ToArray(),
                Condiments = ctx.Condiments.Select(c => new SelectListItem(c.CondimentName, c.Id.ToString())).ToArray()
            };

            return View(formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(PostFormModel form)
		{
            using var ctx = new PizzaContext();

            if (!ModelState.IsValid)
            {
                form.Categorie = ctx.Categorie.ToArray();
                form.Condiments = ctx.Condiments.Select(c => new SelectListItem(c.CondimentName, c.Id.ToString())).ToArray();

                return View(form);
            }

            form.Post.Condiments = form.SelectedCondiments.Select( sc => ctx.Condiments.First(c => c.Id == sc.Id));

			ctx.Posts.Add(form.Post);
            ctx.SaveChanges();

            return RedirectToAction("Index");
		}

        public IActionResult Update(int id)
        {
            using var ctx = new PizzaContext();
            var post = ctx.Posts.Include(p => p.Condiments).FirstOrDefault(p => p.Id == id); 

            if (post is null)
            {
                return View("NotFound");
            }

            var formModel = new PostFormModel
            {
                Post = post,
				Categorie = ctx.Categorie.ToArray(),
				Condiments = ctx.Condiments.ToArray().Select(c => new SelectListItem(
                    c.CondimentName, 
                    c.Id.ToString(), 
                    post.Condiments!.Any(_c => _c.Id == _c.Id))).ToArray()
			};

            return View(formModel);
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(int id, PostFormModel form) 
		{
			using var ctx = new PizzaContext();

			if (!ModelState.IsValid)
			{
				form.Categorie = ctx.Categorie.ToArray();
				form.Condiments = ctx.Condiments.Select(c => new SelectListItem(c.CondimentName, c.Id.ToString())).ToArray();

				return View(form); 
			}

            var postToUpdate = ctx.Posts.FirstOrDefault(p => p.Id == id);

            if (postToUpdate is null)
            {
                return View("NotFound");
            }

            postToUpdate.NomePizza = form.Post.NomePizza;
			postToUpdate.Immagine = form.Post.Immagine;
			postToUpdate.Ingredienti = form.Post.Ingredienti;
			postToUpdate.CategoriaId = form.Post.CategoriaId;
			postToUpdate.Prezzo = form.Post.Prezzo;

            form.Post.Condiments = form.SelectedCondiments.Select(sc => ctx.Condiments.First(c => c.Id == sc.Id));

			ctx.SaveChanges();

            return RedirectToAction("Index");
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id) 
        {
			using var ctx = new PizzaContext();
			var postToDelete = ctx.Posts.FirstOrDefault(p => p.Id == id);

            if(postToDelete == null)
            {
                return View("NotFound");
            }

            ctx.Posts.Remove(postToDelete);
            ctx.SaveChanges();
            return RedirectToAction("Index");
		}

		public IActionResult Privacy()
        {
            return View();
        }
    }
}
