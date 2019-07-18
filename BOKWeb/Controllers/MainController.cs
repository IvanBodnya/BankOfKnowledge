using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOKWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BOKWeb.Controllers
{
    public class MainController : Controller
    {
        private BOKWebContext _context;

        public MainController(BOKWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<PostingModel> postingModels = await Task.Run(() => _context.PostingModels.ToList());
            return View(postingModels);
        }

        public IActionResult CreatePost()
        {
            PostingModel postingModel = new PostingModel();
            return View(postingModel);
        }

        [HttpPost]
        [ActionName("CreatePost")]
        public async Task<IActionResult> CreatePosting([Bind("Title,Author,MinToRead,Description")] PostingModel postingModel)
        {
            postingModel.DateCreated = DateTime.Now;
            //postingModel.Id = await Task.Run(() => _context.PostingModels.ToList().Count) + 1;

            _context.PostingModels.Update(postingModel);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost([Bind("Id")] PostingModel postingModel)
        {
            PostingModel posting = await _context.PostingModels.FindAsync(postingModel.Id);
            _context.PostingModels.Remove(posting);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DisplayPost([Bind("Id")] PostingModel postingModel)
        {
            PostingModel posting = await _context.PostingModels.FindAsync(postingModel.Id);

            return View(posting);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost([Bind("Id")] PostingModel postingModel)
        {
            PostingModel posting = await _context.PostingModels.FindAsync(postingModel.Id);
            _context.Update(posting);

            return View(posting);
        }

        [HttpPost]
        public async Task<IActionResult> EditPosting([Bind("Id, Title, Author, MinToRead, Description")] PostingModel postingModel)
        {
            _context.Update(postingModel);
            postingModel.DateCreated = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}