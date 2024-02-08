using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnet_mvc.Data;
using dotnet_mvc.Models;

namespace dotnet_mvc.Controllers
{
    public class PostController : Controller
    {
        private readonly MvcBlogContext _context;

        public PostController(MvcBlogContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index(string postAuthor, string searchString)
        {
            if (_context.Post == null)
            {
                return Problem("Entity set 'MvcBlogContext.Post'  is null.");
            }

            // Use LINQ to get list of author.
            IQueryable<string> authorQuery = from m in _context.Post
                                             orderby m.Author
                                             select m.Author;
            var posts = from p in _context.Post
                        select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(s => s.Heading!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(postAuthor))
            {
                posts = posts.Where(x => x.Author == postAuthor);
            }
            var postAuthorVM = new PostAuthorViewModel
            {
                Authors = new SelectList(await authorQuery.Distinct().ToListAsync()),
                Posts = await posts.ToListAsync()
            };
            return View(postAuthorVM);
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            ViewData["Title"] = post.Heading ?? "Not Found";
            return View(post);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Heading,PageTitle,Content,ShortDescription,FeaturedImageUrl,UrlHandle,PublishDate,Visible,BlogId")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Id = Guid.NewGuid();
                _context.Post.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Heading,PageTitle,Content,ShortDescription,FeaturedImageUrl,UrlHandle,PublishDate,Visible,BlogId")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Post.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(Guid id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
