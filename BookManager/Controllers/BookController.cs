using BookManager.Models;
using BookManager.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            var listBook = new BookDAO().listBook();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            var book = new BookDAO().getBookByID(id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book s)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var dao = new BookDAO().Insert(s);
                    if (dao)
                        return RedirectToAction("ListBook", "Book");
                    else
                        ModelState.AddModelError("", "Loi");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.ToString());
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var dao = new BookDAO().Detail(id);
            return View(dao);
        }

        [HttpPost]
        public ActionResult Edit(Book s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dao = new BookDAO().Update(s);
                    if (dao)
                        return RedirectToAction("ListBook", "Book");
                    else
                        ModelState.AddModelError("", "Loi");

                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Loi");
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var dao = new BookDAO().Detail(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            new BookDAO().Delete(id);
            return RedirectToAction("ListBook", "Book");
        }
    }
}