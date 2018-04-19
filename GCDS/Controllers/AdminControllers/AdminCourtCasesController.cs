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
    public class AdminCourtCasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminCourtCases
        public ActionResult Index()
        {
            var courtCase = db.CourtCase.Include(c => c.AMLCompanyProfile);
            return View(courtCase.ToList());
        }

        // GET: AdminCourtCases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCase courtCase = db.CourtCase.Find(id);
            if (courtCase == null)
            {
                return HttpNotFound();
            }
            return View(courtCase);
        }

        // GET: AdminCourtCases/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminCourtCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SuitNumber,SuitTitle,SuitDescription,SuitDate,SolicitorID,AMLCompanyProfileID,CourtCaseStatus")] CourtCase courtCase)
        {
            if (ModelState.IsValid)
            {
                db.CourtCase.Add(courtCase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId", courtCase.AMLCompanyProfileID);
            return View(courtCase);
        }

        // GET: AdminCourtCases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCase courtCase = db.CourtCase.Find(id);
            if (courtCase == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId", courtCase.AMLCompanyProfileID);
            return View(courtCase);
        }

        // POST: AdminCourtCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SuitNumber,SuitTitle,SuitDescription,SuitDate,SolicitorID,AMLCompanyProfileID,CourtCaseStatus")] CourtCase courtCase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtCase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId", courtCase.AMLCompanyProfileID);
            return View(courtCase);
        }

        // GET: AdminCourtCases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCase courtCase = db.CourtCase.Find(id);
            if (courtCase == null)
            {
                return HttpNotFound();
            }
            return View(courtCase);
        }

        // POST: AdminCourtCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtCase courtCase = db.CourtCase.Find(id);
            db.CourtCase.Remove(courtCase);
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
