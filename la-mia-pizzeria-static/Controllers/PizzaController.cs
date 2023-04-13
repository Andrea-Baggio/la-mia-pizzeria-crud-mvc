using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using var ctx = new PizzaContext();
            var posts = ctx.Posts.ToArray();

            return View(posts);
        }

        public IActionResult Detail(int id)
        {
            using var ctx = new PizzaContext();
            var post = ctx.Posts.SingleOrDefault(p => p.Id == id);

            if (post is null)
            {
                return View("NotFound", "Post not found.");
            }

            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(Post post)
		{
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            
            using var ctx = new PizzaContext();

            ctx.Posts.Add(post);
            ctx.SaveChanges();

            return RedirectToAction("Index");
		}

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
