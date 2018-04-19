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
    public class AdminPaymentHeadersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminPaymentHeaders
        public ActionResult Index()
        {
            var paymentHeader = db.PaymentHeader.Include(p => p.AMLCompanyProfile);
            return View(paymentHeader.ToList());
        }

        // GET: AdminPaymentHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentHeader paymentHeader = db.PaymentHeader.Find(id);
            if (paymentHeader == null)
            {
                return HttpNotFound();
            }
            return View(paymentHeader);
        }

        // GET: AdminPaymentHeaders/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminPaymentHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,InvoiceNumber,LineitemNumber,AmountDue,AmountPaid,TimeStamp,Is_Deleted,PaymentType,TotalPercentagePaid")] PaymentHeader paymentHeader)
        {
            if (ModelState.IsValid)
            {
                db.PaymentHeader.Add(paymentHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", paymentHeader.AMLCompanyProfileId);
            return View(paymentHeader);
        }

        // GET: AdminPaymentHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentHeader paymentHeader = db.PaymentHeader.Find(id);
            if (paymentHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", paymentHeader.AMLCompanyProfileId);
            return View(paymentHeader);
        }

        // POST: AdminPaymentHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,InvoiceNumber,LineitemNumber,AmountDue,AmountPaid,TimeStamp,Is_Deleted,PaymentType,TotalPercentagePaid")] PaymentHeader paymentHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", paymentHeader.AMLCompanyProfileId);
            return View(paymentHeader);
        }

        // GET: AdminPaymentHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentHeader paymentHeader = db.PaymentHeader.Find(id);
            if (paymentHeader == null)
            {
                return HttpNotFound();
            }
            return View(paymentHeader);
        }

        // POST: AdminPaymentHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentHeader paymentHeader = db.PaymentHeader.Find(id);
            db.PaymentHeader.Remove(paymentHeader);
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
