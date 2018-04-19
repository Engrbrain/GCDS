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
    public class AdminInspectionTeamMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminInspectionTeamMembers
        public ActionResult Index()
        {
            var inspectionTeamMembers = db.InspectionTeamMembers.Include(i => i.InspectionOfficer);
            return View(inspectionTeamMembers.ToList());
        }

        // GET: AdminInspectionTeamMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionTeamMembers inspectionTeamMembers = db.InspectionTeamMembers.Find(id);
            if (inspectionTeamMembers == null)
            {
                return HttpNotFound();
            }
            return View(inspectionTeamMembers);
        }

        // GET: AdminInspectionTeamMembers/Create
        public ActionResult Create()
        {
            ViewBag.InspectionOfficerId = new SelectList(db.InspectionOfficer, "Id", "InspectionOfficerName");
            return View();
        }

        // POST: AdminInspectionTeamMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InspectionTeamId,InspectionOfficerId,DateAdded,Is_Deleted,TimeStamp")] InspectionTeamMembers inspectionTeamMembers)
        {
            if (ModelState.IsValid)
            {
                db.InspectionTeamMembers.Add(inspectionTeamMembers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InspectionOfficerId = new SelectList(db.InspectionOfficer, "Id", "InspectionOfficerName", inspectionTeamMembers.InspectionOfficerId);
            return View(inspectionTeamMembers);
        }

        // GET: AdminInspectionTeamMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionTeamMembers inspectionTeamMembers = db.InspectionTeamMembers.Find(id);
            if (inspectionTeamMembers == null)
            {
                return HttpNotFound();
            }
            ViewBag.InspectionOfficerId = new SelectList(db.InspectionOfficer, "Id", "InspectionOfficerName", inspectionTeamMembers.InspectionOfficerId);
            return View(inspectionTeamMembers);
        }

        // POST: AdminInspectionTeamMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InspectionTeamId,InspectionOfficerId,DateAdded,Is_Deleted,TimeStamp")] InspectionTeamMembers inspectionTeamMembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionTeamMembers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InspectionOfficerId = new SelectList(db.InspectionOfficer, "Id", "InspectionOfficerName", inspectionTeamMembers.InspectionOfficerId);
            return View(inspectionTeamMembers);
        }

        // GET: AdminInspectionTeamMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionTeamMembers inspectionTeamMembers = db.InspectionTeamMembers.Find(id);
            if (inspectionTeamMembers == null)
            {
                return HttpNotFound();
            }
            return View(inspectionTeamMembers);
        }

        // POST: AdminInspectionTeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InspectionTeamMembers inspectionTeamMembers = db.InspectionTeamMembers.Find(id);
            db.InspectionTeamMembers.Remove(inspectionTeamMembers);
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
