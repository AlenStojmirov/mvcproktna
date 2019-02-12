using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProektnaMVC.Models;

namespace ProektnaMVC.Controllers
{
    public class TipstersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tipsters
        public ActionResult Index()
        {
            return View(db.Tipsters.ToList());
        }

        // GET: Tipsters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipster tipster = db.Tipsters.Find(id);
            if (tipster == null)
            {
                return HttpNotFound();
            }
            return View(tipster);
        }

        // GET: Tipsters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipsters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Country")] Tipster tipster)
        {
            if (ModelState.IsValid)
            {
                db.Tipsters.Add(tipster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipster);
        }

        // GET: Tipsters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipster tipster = db.Tipsters.Find(id);
            if (tipster == null)
            {
                return HttpNotFound();
            }
            return View(tipster);
        }

        // POST: Tipsters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Country")] Tipster tipster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipster);
        }

        // GET: Tipsters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipster tipster = db.Tipsters.Find(id);
            if (tipster == null)
            {
                return HttpNotFound();
            }
            return View(tipster);
        }

        // POST: Tipsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipster tipster = db.Tipsters.Find(id);
            db.Tipsters.Remove(tipster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
