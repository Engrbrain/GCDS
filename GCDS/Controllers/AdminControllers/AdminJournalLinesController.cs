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
    public class AdminJournalLinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminJournalLines
        public ActionResult Index()
        {
            var journalLine = db.JournalLine.Include(j => j.JournalHeader);
            return View(journalLine.ToList());
        }

        // GET: AdminJournalLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalLine journalLine = db.JournalLine.Find(id);
            if (journalLine == null)
            {
                return HttpNotFound();
            }
            return View(journalLine);
        }

        // GET: AdminJournalLines/Create
        public ActionResult Create()
        {
            ViewBag.JournalHeaderId = new SelectList(db.JournalHeader, "Id", "JournalNumber");
            return View();
        }

        // POST: AdminJournalLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JournalHeaderId,JournalNumber,LineItemNumber,GLAccount,Narration,CreditAmount,DebitAmount")] JournalLine journalLine)
        {
            if (ModelState.IsValid)
            {
                db.JournalLine.Add(journalLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JournalHeaderId = new SelectList(db.JournalHeader, "Id", "JournalNumber", journalLine.JournalHeaderId);
            return View(journalLine);
        }

        // GET: AdminJournalLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalLine journalLine = db.JournalLine.Find(id);
            if (journalLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.JournalHeaderId = new SelectList(db.JournalHeader, "Id", "JournalNumber", journalLine.JournalHeaderId);
            return View(journalLine);
        }

        // POST: AdminJournalLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JournalHeaderId,JournalNumber,LineItemNumber,GLAccount,Narration,CreditAmount,DebitAmount")] JournalLine journalLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(journalLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JournalHeaderId = new SelectList(db.JournalHeader, "Id", "JournalNumber", journalLine.JournalHeaderId);
            return View(journalLine);
        }

        // GET: AdminJournalLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalLine journalLine = db.JournalLine.Find(id);
            if (journalLine == null)
            {
                return HttpNotFound();
            }
            return View(journalLine);
        }

        // POST: AdminJournalLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JournalLine journalLine = db.JournalLine.Find(id);
            db.JournalLine.Remove(journalLine);
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
