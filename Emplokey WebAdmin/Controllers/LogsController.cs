using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emplokey_WebAdmin;
using Emplokey_WebAdmin.Models;

namespace Emplokey_WebAdmin.Controllers
{
    public class LogsController : Controller
    {
        private DataClasses db = new DataClasses();

        // GET: Logs
        public ActionResult Index()
        {
            List<LogsViewModel> logsList = new List<LogsViewModel>();

            var queryLogs = from l in db.Logs
                            join u in db.Users on l.ID_user equals u.ID
                            join c in db.Computers on l.ID_pc equals c.ID
                            orderby l.Time_login descending
                            select new
                            {
                                u.Username,
                                c.PC_name,
                                l.Time_login,
                                l.Time_logout
                            };

            foreach (var item in queryLogs)
            {
                logsList.Add(new LogsViewModel
                {
                    Username = item.Username,
                    PcName = item.PC_name,
                    Time_login = item.Time_login,
                    Time_logout = item.Time_logout
                });
            }           

            return View(logsList);
        }

        // GET: Logs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logs logs = db.Logs.Find(id);
            if (logs == null)
            {
                return HttpNotFound();
            }
            return View(logs);
        }

        // GET: Logs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_user,ID_pc,Time_login,Time_logout")] Logs logs)
        {
            if (ModelState.IsValid)
            {
                db.Logs.Add(logs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logs);
        }

        // GET: Logs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logs logs = db.Logs.Find(id);
            if (logs == null)
            {
                return HttpNotFound();
            }
            return View(logs);
        }

        // POST: Logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_user,ID_pc,Time_login,Time_logout")] Logs logs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logs);
        }

        // GET: Logs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logs logs = db.Logs.Find(id);
            if (logs == null)
            {
                return HttpNotFound();
            }
            return View(logs);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logs logs = db.Logs.Find(id);
            db.Logs.Remove(logs);
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
