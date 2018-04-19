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
    public class InvoiceLinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvoiceLines
        public ActionResult Index()
        {
            var invoiceLine = db.InvoiceLine.Include(i => i.InvoiceHeader);
            return View(invoiceLine.ToList());
        }

        // GET: InvoiceLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLine invoiceLine = db.InvoiceLine.Find(id);
            if (invoiceLine == null)
            {
                return HttpNotFound();
            }
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Create
        public ActionResult Create()
        {
            ViewBag.InvoiceHeaderId = new SelectList(db.InvoiceHeader, "Id", "UserId");
            return View();
        }

        // POST: InvoiceLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InvoiceNumber,InvoiceHeaderId,LineitemNumber,Narration,PaymentCateroryID,UnitPrice,Units,GrossAmount,Discount,Tax,TimeStamp,Is_Deleted,NetAmount")] InvoiceLine invoiceLine)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceLine.Add(invoiceLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvoiceHeaderId = new SelectList(db.InvoiceHeader, "Id", "UserId", invoiceLine.InvoiceHeaderId);
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLine invoiceLine = db.InvoiceLine.Find(id);
            if (invoiceLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceHeaderId = new SelectList(db.InvoiceHeader, "Id", "UserId", invoiceLine.InvoiceHeaderId);
            return View(invoiceLine);
        }

        // POST: InvoiceLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InvoiceNumber,InvoiceHeaderId,LineitemNumber,Narration,PaymentCateroryID,UnitPrice,Units,GrossAmount,Discount,Tax,TimeStamp,Is_Deleted,NetAmount")] InvoiceLine invoiceLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvoiceHeaderId = new SelectList(db.InvoiceHeader, "Id", "UserId", invoiceLine.InvoiceHeaderId);
            return View(invoiceLine);
        }

        // GET: InvoiceLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLine invoiceLine = db.InvoiceLine.Find(id);
            if (invoiceLine == null)
            {
                return HttpNotFound();
            }
            return View(invoiceLine);
        }

        // POST: InvoiceLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceLine invoiceLine = db.InvoiceLine.Find(id);
            db.InvoiceLine.Remove(invoiceLine);
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
