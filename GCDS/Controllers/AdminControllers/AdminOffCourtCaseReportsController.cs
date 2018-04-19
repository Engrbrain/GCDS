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
    public class AdminOffCourtCaseReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminOffCourtCaseReports
        public ActionResult Index()
        {
            var offCourtCaseReport = db.OffCourtCaseReport.Include(o => o.OffCourtCase);
            return View(offCourtCaseReport.ToList());
        }

        // GET: AdminOffCourtCaseReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffCourtCaseReport offCourtCaseReport = db.OffCourtCaseReport.Find(id);
            if (offCourtCaseReport == null)
            {
                return HttpNotFound();
            }
            return View(offCourtCaseReport);
        }

        // GET: AdminOffCourtCaseReports/Create
        public ActionResult Create()
        {
            ViewBag.OffCourtCaseId = new SelectList(db.OffCourtCase, "Id", "LitigationReference");
            return View();
        }

        // POST: AdminOffCourtCaseReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OffCourtCaseId,ReportTitle,ReportDate,UserID,ReportAttachment,ReportDetails")] OffCourtCaseReport offCourtCaseReport)
        {
            if (ModelState.IsValid)
            {
                db.OffCourtCaseReport.Add(offCourtCaseReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OffCourtCaseId = new SelectList(db.OffCourtCase, "Id", "LitigationReference", offCourtCaseReport.OffCourtCaseId);
            return View(offCourtCaseReport);
        }

        // GET: AdminOffCourtCaseReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffCourtCaseReport offCourtCaseReport = db.OffCourtCaseReport.Find(id);
            if (offCourtCaseReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.OffCourtCaseId = new SelectList(db.OffCourtCase, "Id", "LitigationReference", offCourtCaseReport.OffCourtCaseId);
            return View(offCourtCaseReport);
        }

        // POST: AdminOffCourtCaseReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OffCourtCaseId,ReportTitle,ReportDate,UserID,ReportAttachment,ReportDetails")] OffCourtCaseReport offCourtCaseReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offCourtCaseReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OffCourtCaseId = new SelectList(db.OffCourtCase, "Id", "LitigationReference", offCourtCaseReport.OffCourtCaseId);
            return View(offCourtCaseReport);
        }

        // GET: AdminOffCourtCaseReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffCourtCaseReport offCourtCaseReport = db.OffCourtCaseReport.Find(id);
            if (offCourtCaseReport == null)
            {
                return HttpNotFound();
            }
            return View(offCourtCaseReport);
        }

        // POST: AdminOffCourtCaseReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OffCourtCaseReport offCourtCaseReport = db.OffCourtCaseReport.Find(id);
            db.OffCourtCaseReport.Remove(offCourtCaseReport);
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
