﻿using System;
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
    public class ComputersController : Controller
    {
        private DataClasses db = new DataClasses();

        // GET: Computers
        public ActionResult Index()
        {
            return View(db.Computers.ToList());
        }

        // GET: Computers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computers computers = db.Computers.Find(id);
            if (computers == null)
            {
                return HttpNotFound();
            }
            return View(computers);
        }

        // GET: Computers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PC_name,Lock_status")] Computers computers)
        {
            if (ModelState.IsValid)
            {
                db.Computers.Add(computers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(computers);
        }

        // GET: Computers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computers computers = db.Computers.Find(id);
            if (computers == null)
            {
                return HttpNotFound();
            }
            return View(computers);
        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PC_name,Lock_status")] Computers computers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(computers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(computers);
        }

        // GET: Computers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Computers computers = db.Computers.Find(id);
            if (computers == null)
            {
                return HttpNotFound();
            }
            return View(computers);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Computers computers = db.Computers.Find(id);
            db.Computers.Remove(computers);
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
