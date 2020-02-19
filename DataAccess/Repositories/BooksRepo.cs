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
    public class BooksRepo
    {
        public List<Book> GetAll()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Books.Include(x => x.Genre).ToList();
            }
        }

        public Book GetById(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Books.Find(id);
            }
        }

        public void Create(Book book)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public void Update(Book book)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Book book = db.Books.Find(id);
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
    }
}
