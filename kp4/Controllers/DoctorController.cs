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
    public class DoctorController : Controller
    {
        
        Doctor doctor = new Doctor();
        private kp14Entities db = new kp14Entities();
        // GET: Doctor
        public ActionResult Index()
        {
            return View(db.Doctor.ToList());
        }


        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            Doctor doctor = db.Doctor.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctor.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [Authorize(Roles = "Doctor,Admin")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
        [HttpPost]

        public ActionResult DeleteOne(int id)
        {
            db.Doctor.Remove(db.Doctor.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
