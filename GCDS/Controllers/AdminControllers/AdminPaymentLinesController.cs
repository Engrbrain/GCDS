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
    public class AdminPaymentLinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminPaymentLines
        public ActionResult Index()
        {
            var paymentLine = db.PaymentLine.Include(p => p.AMLCompanyProfile).Include(p => p.PaymentHeader);
            return View(paymentLine.ToList());
        }

        // GET: AdminPaymentLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentLine paymentLine = db.PaymentLine.Find(id);
            if (paymentLine == null)
            {
                return HttpNotFound();
            }
            return View(paymentLine);
        }

        // GET: AdminPaymentLines/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PaymentHeaderId = new SelectList(db.PaymentHeader, "Id", "PaymentType");
            return View();
        }

        // POST: AdminPaymentLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,PaymentHeaderId,PaymentDate,PaymentOption,AmountPaid,PaymentReference,TimeStamp,Is_Deleted,TotalPercentagePaid")] PaymentLine paymentLine)
        {
            if (ModelState.IsValid)
            {
                db.PaymentLine.Add(paymentLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", paymentLine.AMLCompanyProfileId);
            ViewBag.PaymentHeaderId = new SelectList(db.PaymentHeader, "Id", "PaymentType", paymentLine.PaymentHeaderId);
            return View(paymentLine);
        }

        // GET: AdminPaymentLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentLine paymentLine = db.PaymentLine.Find(id);
            if (paymentLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", paymentLine.AMLCompanyProfileId);
            ViewBag.PaymentHeaderId = new SelectList(db.PaymentHeader, "Id", "PaymentType", paymentLine.PaymentHeaderId);
            return View(paymentLine);
        }

        // POST: AdminPaymentLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,PaymentHeaderId,PaymentDate,PaymentOption,AmountPaid,PaymentReference,TimeStamp,Is_Deleted,TotalPercentagePaid")] PaymentLine paymentLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", paymentLine.AMLCompanyProfileId);
            ViewBag.PaymentHeaderId = new SelectList(db.PaymentHeader, "Id", "PaymentType", paymentLine.PaymentHeaderId);
            return View(paymentLine);
        }

        // GET: AdminPaymentLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentLine paymentLine = db.PaymentLine.Find(id);
            if (paymentLine == null)
            {
                return HttpNotFound();
            }
            return View(paymentLine);
        }

        // POST: AdminPaymentLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentLine paymentLine = db.PaymentLine.Find(id);
            db.PaymentLine.Remove(paymentLine);
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
