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
    public class AdminOffCourtJudgementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminOffCourtJudgements
        public ActionResult Index()
        {
            var offCourtJudgement = db.OffCourtJudgement.Include(o => o.OffCourtCase);
            return View(offCourtJudgement.ToList());
        }

        // GET: AdminOffCourtJudgements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffCourtJudgement offCourtJudgement = db.OffCourtJudgement.Find(id);
            if (offCourtJudgement == null)
            {
                return HttpNotFound();
            }
            return View(offCourtJudgement);
        }

        // GET: AdminOffCourtJudgements/Create
        public ActionResult Create()
        {
            ViewBag.OffCourtCaseId = new SelectList(db.OffCourtCase, "Id", "LitigationReference");
            return View();
        }

        // POST: AdminOffCourtJudgements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OffCourtCaseId,JudgementTitle,JudgementDetails,Attachment,JudgementDate,LitigationStatus")] OffCourtJudgement offCourtJudgement)
        {
            if (ModelState.IsValid)
            {
                db.OffCourtJudgement.Add(offCourtJudgement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OffCourtCaseId = new SelectList(db.OffCourtCase, "Id", "LitigationReference", offCourtJudgement.OffCourtCaseId);
            return View(offCourtJudgement);
        }

        // GET: AdminOffCourtJudgements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffCourtJudgement offCourtJudgement = db.OffCourtJudgement.Find(id);
            if (offCourtJudgement == null)
            {
                return HttpNotFound();
            }
            ViewBag.OffCourtCaseId = new SelectList(db.OffCourtCase, "Id", "LitigationReference", offCourtJudgement.OffCourtCaseId);
            return View(offCourtJudgement);
        }

        // POST: AdminOffCourtJudgements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OffCourtCaseId,JudgementTitle,JudgementDetails,Attachment,JudgementDate,LitigationStatus")] OffCourtJudgement offCourtJudgement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offCourtJudgement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OffCourtCaseId = new SelectList(db.OffCourtCase, "Id", "LitigationReference", offCourtJudgement.OffCourtCaseId);
            return View(offCourtJudgement);
        }

        // GET: AdminOffCourtJudgements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffCourtJudgement offCourtJudgement = db.OffCourtJudgement.Find(id);
            if (offCourtJudgement == null)
            {
                return HttpNotFound();
            }
            return View(offCourtJudgement);
        }

        // POST: AdminOffCourtJudgements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OffCourtJudgement offCourtJudgement = db.OffCourtJudgement.Find(id);
            db.OffCourtJudgement.Remove(offCourtJudgement);
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
