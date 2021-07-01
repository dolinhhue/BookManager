using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManager.Models.DAO
{
    public class BookDAO
    {
        BookManagerContex db = null;
        public BookDAO()
        {
            db = new BookManagerContex();
        }
        public List<Book> listBook()
        {
            return db.Books.ToList();
        }
        public Book getBookByID(int id)
        {
            return db.Books.SingleOrDefault(p => p.ID == id);
        }
        public bool Insert(Book s)
        {
            try
            {
                db.Books.Add(s);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Book s)
        {
            try
            {
                var dao = db.Books.Find(s.ID);
                dao.Author = s.Author;
                dao.Title = s.Title;
                dao.Description = s.Description;
                if (s.Images != null)
                    dao.Images = s.Images;
                dao.Price = s.Price;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public Book Detail(int id)
        {
            return db.Books.Find(id);
        }
        public bool Delete(int ma)
        {
            try
            {
                var dao = db.Books.Find(ma);
                db.Books.Remove(dao);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}