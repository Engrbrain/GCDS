using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GCDS.Models;

namespace GCDS.Controllers.AdminControllers
{
    public class AdminInspectionTeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminInspectionTeams
        public ActionResult Index()
        {
            return View(db.InspectionTeam.ToList());
        }

        // GET: AdminInspectionTeams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionTeam inspectionTeam = db.InspectionTeam.Find(id);
            if (inspectionTeam == null)
            {
                return HttpNotFound();
            }
            return View(inspectionTeam);
        }

        // GET: AdminInspectionTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminInspectionTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamName,Description,Is_Deleted,TimeStamp")] InspectionTeam inspectionTeam)
        {
            if (ModelState.IsValid)
            {
                db.InspectionTeam.Add(inspectionTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inspectionTeam);
        }

        // GET: AdminInspectionTeams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionTeam inspectionTeam = db.InspectionTeam.Find(id);
            if (inspectionTeam == null)
            {
                return HttpNotFound();
            }
            return View(inspectionTeam);
        }

        // POST: AdminInspectionTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamName,Description,Is_Deleted,TimeStamp")] InspectionTeam inspectionTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionTeam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inspectionTeam);
        }

        // GET: AdminInspectionTeams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionTeam inspectionTeam = db.InspectionTeam.Find(id);
            if (inspectionTeam == null)
            {
                return HttpNotFound();
            }
            return View(inspectionTeam);
        }

        // POST: AdminInspectionTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InspectionTeam inspectionTeam = db.InspectionTeam.Find(id);
            db.InspectionTeam.Remove(inspectionTeam);
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
