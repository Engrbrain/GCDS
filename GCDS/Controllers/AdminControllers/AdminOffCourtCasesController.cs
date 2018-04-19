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
    public class AdminOffCourtCasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminOffCourtCases
        public ActionResult Index()
        {
            var offCourtCase = db.OffCourtCase.Include(o => o.AMLCompanyProfile);
            return View(offCourtCase.ToList());
        }

        // GET: AdminOffCourtCases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffCourtCase offCourtCase = db.OffCourtCase.Find(id);
            if (offCourtCase == null)
            {
                return HttpNotFound();
            }
            return View(offCourtCase);
        }

        // GET: AdminOffCourtCases/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminOffCourtCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LitigationReference,CaseTitle,CaseDescription,AMLCompanyProfileId,LitigationDate,LitigationStatus")] OffCourtCase offCourtCase)
        {
            if (ModelState.IsValid)
            {
                db.OffCourtCase.Add(offCourtCase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", offCourtCase.AMLCompanyProfileId);
            return View(offCourtCase);
        }

        // GET: AdminOffCourtCases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffCourtCase offCourtCase = db.OffCourtCase.Find(id);
            if (offCourtCase == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", offCourtCase.AMLCompanyProfileId);
            return View(offCourtCase);
        }

        // POST: AdminOffCourtCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LitigationReference,CaseTitle,CaseDescription,AMLCompanyProfileId,LitigationDate,LitigationStatus")] OffCourtCase offCourtCase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offCourtCase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", offCourtCase.AMLCompanyProfileId);
            return View(offCourtCase);
        }

        // GET: AdminOffCourtCases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffCourtCase offCourtCase = db.OffCourtCase.Find(id);
            if (offCourtCase == null)
            {
                return HttpNotFound();
            }
            return View(offCourtCase);
        }

        // POST: AdminOffCourtCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OffCourtCase offCourtCase = db.OffCourtCase.Find(id);
            db.OffCourtCase.Remove(offCourtCase);
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
