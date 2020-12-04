using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kp4.Models;
using kp4.DAO;
using System.Data.Entity;

namespace kp4.Controllers
{
    public class EntryController : Controller
    {

        private kp14Entities db = new kp14Entities();
        // GET: Entry
        public ActionResult Index()
        {
            return View(db.Entry.ToList());
        }
        public ActionResult ReturnCreate()
        {
            return RedirectToAction("Index");
        }
        // GET: Entry/Details/5
        public ActionResult Details(int id)
        {
            Entry entry = db.Entry.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);
        }

        // GET: Entry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entry/Create
        [HttpPost]
        public ActionResult Create(Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry.Add(entry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        // GET: Entry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entry/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Entry entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        // GET: Entry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entry/Delete/5
        [HttpPost]
        public ActionResult DeleteOne(int id)
        {
            db.Entry.Remove(db.Entry.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
