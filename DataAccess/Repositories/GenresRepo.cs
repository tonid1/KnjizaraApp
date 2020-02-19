using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenresRepo
    {
        public List<Genre> GetAll()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Genres.ToList();
            }
        }

        public Genre GetById(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Genres.Find(id);
            }
        }

        public void Create(Genre genre)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Genres.Add(genre);
                db.SaveChanges();
            }
        }

        public void Update(Genre genre)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Genre genre = db.Genres.Find(id);
                db.Genres.Remove(genre);
                db.SaveChanges();
            }
        }
    }
}
