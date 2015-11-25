using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emplokey_WebAdmin;

namespace Emplokey_WebAdmin.Controllers
{
    public class AuthsController : Controller
    {
        private DataClasses db = new DataClasses();

        // GET: Auths
        public ActionResult Index()
        {
            return View(db.Auths.ToList());
        }

        // GET: Auths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auths auths = db.Auths.Find(id);
            if (auths == null)
            {
                return HttpNotFound();
            }
            return View(auths);
        }

        // GET: Auths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_user,ID_pc,Auth_key,Device")] Auths auths)
        {
            if (ModelState.IsValid)
            {
                db.Auths.Add(auths);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auths);
        }

        // GET: Auths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auths auths = db.Auths.Find(id);
            if (auths == null)
            {
                return HttpNotFound();
            }
            return View(auths);
        }

        // POST: Auths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_user,ID_pc,Auth_key,Device")] Auths auths)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auths).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auths);
        }

        // GET: Auths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auths auths = db.Auths.Find(id);
            if (auths == null)
            {
                return HttpNotFound();
            }
            return View(auths);
        }

        // POST: Auths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auths auths = db.Auths.Find(id);
            db.Auths.Remove(auths);
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
