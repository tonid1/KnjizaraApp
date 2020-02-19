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
    public class GenresController : Controller
    {
        GenresRepo genresRepo;

        public GenresController()
        {
            genresRepo = new GenresRepo();
        }

        // GET: Genres
        public ActionResult Index()
        {
            return View(genresRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Genre());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genresRepo.Create(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var genre = genresRepo.GetById((int)id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genresRepo.Update(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var genre = genresRepo.GetById((int)id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            genresRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}