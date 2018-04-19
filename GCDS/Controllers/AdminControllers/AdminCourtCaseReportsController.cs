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
    public class AdminCourtCaseReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminCourtCaseReports
        public ActionResult Index()
        {
            return View(db.CourtCaseReport.ToList());
        }

        // GET: AdminCourtCaseReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCaseReport courtCaseReport = db.CourtCaseReport.Find(id);
            if (courtCaseReport == null)
            {
                return HttpNotFound();
            }
            return View(courtCaseReport);
        }

        // GET: AdminCourtCaseReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCourtCaseReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourtCaseId,ReportTitle,ReportDate,ReportAttachment,ReportDetails")] CourtCaseReport courtCaseReport)
        {
            if (ModelState.IsValid)
            {
                db.CourtCaseReport.Add(courtCaseReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courtCaseReport);
        }

        // GET: AdminCourtCaseReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCaseReport courtCaseReport = db.CourtCaseReport.Find(id);
            if (courtCaseReport == null)
            {
                return HttpNotFound();
            }
            return View(courtCaseReport);
        }

        // POST: AdminCourtCaseReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourtCaseId,ReportTitle,ReportDate,ReportAttachment,ReportDetails")] CourtCaseReport courtCaseReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtCaseReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courtCaseReport);
        }

        // GET: AdminCourtCaseReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCaseReport courtCaseReport = db.CourtCaseReport.Find(id);
            if (courtCaseReport == null)
            {
                return HttpNotFound();
            }
            return View(courtCaseReport);
        }

        // POST: AdminCourtCaseReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtCaseReport courtCaseReport = db.CourtCaseReport.Find(id);
            db.CourtCaseReport.Remove(courtCaseReport);
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
