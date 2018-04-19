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
    public class AdminInspectionOfficersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminInspectionOfficers
        public ActionResult Index()
        {
            var inspectionOfficer = db.InspectionOfficer.Include(i => i.AMLCompanyProfile);
            return View(inspectionOfficer.ToList());
        }

        // GET: AdminInspectionOfficers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionOfficer inspectionOfficer = db.InspectionOfficer.Find(id);
            if (inspectionOfficer == null)
            {
                return HttpNotFound();
            }
            return View(inspectionOfficer);
        }

        // GET: AdminInspectionOfficers/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminInspectionOfficers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,InspectionOfficerName,InspectionReference,PhoneNumber,EmailAddress,Country,OfficeDesignation,Is_Active,TimeStamp,Is_Deleted,InspectionOfficerType")] InspectionOfficer inspectionOfficer)
        {
            if (ModelState.IsValid)
            {
                db.InspectionOfficer.Add(inspectionOfficer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", inspectionOfficer.AMLCompanyProfileId);
            return View(inspectionOfficer);
        }

        // GET: AdminInspectionOfficers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionOfficer inspectionOfficer = db.InspectionOfficer.Find(id);
            if (inspectionOfficer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", inspectionOfficer.AMLCompanyProfileId);
            return View(inspectionOfficer);
        }

        // POST: AdminInspectionOfficers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,InspectionOfficerName,InspectionReference,PhoneNumber,EmailAddress,Country,OfficeDesignation,Is_Active,TimeStamp,Is_Deleted,InspectionOfficerType")] InspectionOfficer inspectionOfficer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionOfficer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", inspectionOfficer.AMLCompanyProfileId);
            return View(inspectionOfficer);
        }

        // GET: AdminInspectionOfficers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionOfficer inspectionOfficer = db.InspectionOfficer.Find(id);
            if (inspectionOfficer == null)
            {
                return HttpNotFound();
            }
            return View(inspectionOfficer);
        }

        // POST: AdminInspectionOfficers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InspectionOfficer inspectionOfficer = db.InspectionOfficer.Find(id);
            db.InspectionOfficer.Remove(inspectionOfficer);
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
