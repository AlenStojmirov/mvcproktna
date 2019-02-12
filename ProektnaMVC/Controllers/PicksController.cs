using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace ProektnaMVC.Models
{
    public class PicksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Picks
        public ActionResult Index()
        {
            return View(db.Picks.ToList());
        }

        // GET: Picks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pick pick = db.Picks.Find(id);
            if (pick == null)
            {
                return HttpNotFound();
            }
            return View(pick);
        }

        // GET: Picks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Picks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Data,Sport,Country,Game,Picks,Odds,Stake,Bookmaker,Result")] Pick pick)
        {
            if (ModelState.IsValid)
            {
                var tipster = db.Tipsters.Where(t => t.UserName == User.Identity.Name).FirstOrDefault();
                pick.TipsterId = tipster.Id;
                db.Picks.Add(pick);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pick);
        }

        // GET: Picks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pick pick = db.Picks.Find(id);
            if (pick == null)
            {
                return HttpNotFound();
            }
            return View(pick);
        }

        // POST: Picks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Data,Sport,Country,Game,Picks,Odds,Stake,Bookmaker,Result")] Pick pick)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pick).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pick);
        }
        [Authorize(Roles = "Admin")]
        // GET: Picks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pick pick = db.Picks.Find(id);
            if (pick == null)
            {
                return HttpNotFound();
            }
            return View(pick);
        }

        // POST: Picks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pick pick = db.Picks.Find(id);
            db.Picks.Remove(pick);
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
