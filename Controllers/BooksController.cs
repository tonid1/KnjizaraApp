using DataAccess.Repositories;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Knjizara.Controllers
{
    public class BooksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        BooksRepo booksRepo;

        public BooksController()
        {
            booksRepo = new BooksRepo();
        }

        // GET: Books
        public ActionResult Index()
        {
            return View(booksRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");

            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                booksRepo.Create(book);
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", book.GenreId);
            return View(book);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = booksRepo.GetById((int)id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = booksRepo.GetById((int)id);

            if (book == null)
            {
                return HttpNotFound();
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", book.GenreId);

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Book book)
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", book.GenreId);

            if (ModelState.IsValid)
            {
                booksRepo.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = booksRepo.GetById((int)id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            booksRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}