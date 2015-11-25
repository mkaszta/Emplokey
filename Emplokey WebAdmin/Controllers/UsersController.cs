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
    public class UsersController : Controller
    {
        private DataClasses db = new DataClasses();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Type")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Type")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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

        public ActionResult Statistics(int? id)
        {
            List<StatisticsModel> stats = new List<StatisticsModel>();
            var logs = db.Logs.Where(x => x.ID_user == id && x.Time_logout != null);            

            List<DateTime> days = new List<DateTime>();
            foreach (var log in logs)
            {
                if (!days.Exists(x => x.Equals(log.Time_login.Date)))
                    days.Add(log.Time_login.Date);
            }            

            foreach (var day in days)
            {
                foreach (var log in logs)
                {           
                    if (log.Time_login >= day && log.Time_login < day.AddDays(1))
                    {
                        string pc = (from c in db.Computers
                                     where c.ID == log.ID_pc
                                     select c.PC_name).First();
                           
                        var seconds = (int)(log.Time_logout - log.Time_login).Value.TotalSeconds;
                        TimeSpan span = new TimeSpan(0, 0, 0, seconds);

                        var queryStats = from s in stats
                                         where s.date.Equals(day) && s.pcName == pc
                                         select s;

                        if (queryStats.Any())
                        {
                            queryStats.First().timeSpent = queryStats.First().timeSpent.Add(span);                            
                        }
                        else
                        {
                            stats.Add(new StatisticsModel
                            {
                                date = day,
                                pcName = pc,
                                timeSpent = span
                            });
                        }                     
                    }                             
                }
            }

            return View(stats);
        }
    }
}
