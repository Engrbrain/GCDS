using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GCDS.Models;

namespace GCDS.Controllers
{
    public class InvoiceHeaderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvoiceHeader
        public ActionResult Index()
        {
            var InvoiceHeader = db.InvoiceHeader.Include(i => i.AMLCompanyProfile).Include(i => i.User);
            return View(InvoiceHeader.ToList());
        }

        // GET: InvoiceHeader/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceHeader invoiceHeader = db.InvoiceHeader.Find(id);
            if (invoiceHeader == null)
            {
                return HttpNotFound();
            }
            return View(invoiceHeader);
        }

        // GET: InvoiceHeader/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname");
            return View();
        }

        // POST: InvoiceHeader/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InvoiceNumber,AMLCompanyProfileId,UserId,DocumentDate,HeaderText,ApprovedDate,ApprovedBy,ReviewedDate,ReviewedBy,ReviewComment,TimeStamp,Is_Deleted,ApprovedComment")] InvoiceHeader invoiceHeader)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceHeader.Add(invoiceHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", invoiceHeader.AMLCompanyProfileId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", invoiceHeader.UserId);
            return View(invoiceHeader);
        }

        // GET: InvoiceHeader/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceHeader invoiceHeader = db.InvoiceHeader.Find(id);
            if (invoiceHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", invoiceHeader.AMLCompanyProfileId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", invoiceHeader.UserId);
            return View(invoiceHeader);
        }

        // POST: InvoiceHeader/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InvoiceNumber,AMLCompanyProfileId,UserId,DocumentDate,HeaderText,ApprovedDate,ApprovedBy,ReviewedDate,ReviewedBy,ReviewComment,TimeStamp,Is_Deleted,ApprovedComment")] InvoiceHeader invoiceHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", invoiceHeader.AMLCompanyProfileId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", invoiceHeader.UserId);
            return View(invoiceHeader);
        }

        // GET: InvoiceHeader/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceHeader invoiceHeader = db.InvoiceHeader.Find(id);
            if (invoiceHeader == null)
            {
                return HttpNotFound();
            }
            return View(invoiceHeader);
        }

        // POST: InvoiceHeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceHeader invoiceHeader = db.InvoiceHeader.Find(id);
            db.InvoiceHeader.Remove(invoiceHeader);
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
