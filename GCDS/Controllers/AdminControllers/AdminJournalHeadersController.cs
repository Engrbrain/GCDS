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
    public class AdminJournalHeadersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminJournalHeaders
        public ActionResult Index()
        {
            var journalHeader = db.JournalHeader.Include(j => j.AMLCompanyProfile);
            return View(journalHeader.ToList());
        }

        // GET: AdminJournalHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalHeader journalHeader = db.JournalHeader.Find(id);
            if (journalHeader == null)
            {
                return HttpNotFound();
            }
            return View(journalHeader);
        }

        // GET: AdminJournalHeaders/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminJournalHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,JournalNumber,JournalType,JournalText,JournalDate,SourceDocumentReference,Period,FiscalYear,CreatedBy,ReviewedDate,ReviewedBy,ReviewedComment,ApprovedDate,ApprovedBy,ApprovedComment")] JournalHeader journalHeader)
        {
            if (ModelState.IsValid)
            {
                db.JournalHeader.Add(journalHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", journalHeader.AMLCompanyProfileId);
            return View(journalHeader);
        }

        // GET: AdminJournalHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalHeader journalHeader = db.JournalHeader.Find(id);
            if (journalHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", journalHeader.AMLCompanyProfileId);
            return View(journalHeader);
        }

        // POST: AdminJournalHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,JournalNumber,JournalType,JournalText,JournalDate,SourceDocumentReference,Period,FiscalYear,CreatedBy,ReviewedDate,ReviewedBy,ReviewedComment,ApprovedDate,ApprovedBy,ApprovedComment")] JournalHeader journalHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journalHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", journalHeader.AMLCompanyProfileId);
            return View(journalHeader);
        }

        // GET: AdminJournalHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalHeader journalHeader = db.JournalHeader.Find(id);
            if (journalHeader == null)
            {
                return HttpNotFound();
            }
            return View(journalHeader);
        }

        // POST: AdminJournalHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JournalHeader journalHeader = db.JournalHeader.Find(id);
            db.JournalHeader.Remove(journalHeader);
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
