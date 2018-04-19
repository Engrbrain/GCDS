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
    public class AdminInspectionReportCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminInspectionReportCategories
        public ActionResult Index()
        {
            return View(db.InspectionReportCategory.ToList());
        }

        // GET: AdminInspectionReportCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionReportCategory inspectionReportCategory = db.InspectionReportCategory.Find(id);
            if (inspectionReportCategory == null)
            {
                return HttpNotFound();
            }
            return View(inspectionReportCategory);
        }

        // GET: AdminInspectionReportCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminInspectionReportCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TimeStamp,Is_Deleted,Description")] InspectionReportCategory inspectionReportCategory)
        {
            if (ModelState.IsValid)
            {
                db.InspectionReportCategory.Add(inspectionReportCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inspectionReportCategory);
        }

        // GET: AdminInspectionReportCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionReportCategory inspectionReportCategory = db.InspectionReportCategory.Find(id);
            if (inspectionReportCategory == null)
            {
                return HttpNotFound();
            }
            return View(inspectionReportCategory);
        }

        // POST: AdminInspectionReportCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TimeStamp,Is_Deleted,Description")] InspectionReportCategory inspectionReportCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionReportCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inspectionReportCategory);
        }

        // GET: AdminInspectionReportCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionReportCategory inspectionReportCategory = db.InspectionReportCategory.Find(id);
            if (inspectionReportCategory == null)
            {
                return HttpNotFound();
            }
            return View(inspectionReportCategory);
        }

        // POST: AdminInspectionReportCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InspectionReportCategory inspectionReportCategory = db.InspectionReportCategory.Find(id);
            db.InspectionReportCategory.Remove(inspectionReportCategory);
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
