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
    public class AdminCourtCaseJudgementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminCourtCaseJudgements
        public ActionResult Index()
        {
            var courtCaseJudgement = db.CourtCaseJudgement.Include(c => c.CourtCase);
            return View(courtCaseJudgement.ToList());
        }

        // GET: AdminCourtCaseJudgements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCaseJudgement courtCaseJudgement = db.CourtCaseJudgement.Find(id);
            if (courtCaseJudgement == null)
            {
                return HttpNotFound();
            }
            return View(courtCaseJudgement);
        }

        // GET: AdminCourtCaseJudgements/Create
        public ActionResult Create()
        {
            ViewBag.CourtCaseId = new SelectList(db.CourtCase, "Id", "SuitNumber");
            return View();
        }

        // POST: AdminCourtCaseJudgements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourtCaseId,JudgementTitle,JudgementDetails,Attachment,JudgementDate")] CourtCaseJudgement courtCaseJudgement)
        {
            if (ModelState.IsValid)
            {
                db.CourtCaseJudgement.Add(courtCaseJudgement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourtCaseId = new SelectList(db.CourtCase, "Id", "SuitNumber", courtCaseJudgement.CourtCaseId);
            return View(courtCaseJudgement);
        }

        // GET: AdminCourtCaseJudgements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCaseJudgement courtCaseJudgement = db.CourtCaseJudgement.Find(id);
            if (courtCaseJudgement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourtCaseId = new SelectList(db.CourtCase, "Id", "SuitNumber", courtCaseJudgement.CourtCaseId);
            return View(courtCaseJudgement);
        }

        // POST: AdminCourtCaseJudgements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourtCaseId,JudgementTitle,JudgementDetails,Attachment,JudgementDate")] CourtCaseJudgement courtCaseJudgement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtCaseJudgement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourtCaseId = new SelectList(db.CourtCase, "Id", "SuitNumber", courtCaseJudgement.CourtCaseId);
            return View(courtCaseJudgement);
        }

        // GET: AdminCourtCaseJudgements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtCaseJudgement courtCaseJudgement = db.CourtCaseJudgement.Find(id);
            if (courtCaseJudgement == null)
            {
                return HttpNotFound();
            }
            return View(courtCaseJudgement);
        }

        // POST: AdminCourtCaseJudgements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtCaseJudgement courtCaseJudgement = db.CourtCaseJudgement.Find(id);
            db.CourtCaseJudgement.Remove(courtCaseJudgement);
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
