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
    public class AdminExpenseHeadersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminExpenseHeaders
        public ActionResult Index()
        {
            var expenseHeader = db.ExpenseHeader.Include(e => e.AMLCompanyProfile);
            return View(expenseHeader.ToList());
        }

        // GET: AdminExpenseHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseHeader expenseHeader = db.ExpenseHeader.Find(id);
            if (expenseHeader == null)
            {
                return HttpNotFound();
            }
            return View(expenseHeader);
        }

        // GET: AdminExpenseHeaders/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminExpenseHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExpenseNumber,AMLCompanyProfileId,DocumentDate,HeaderText,ApprovedDate,ApprovedBy,ReviewedDate,ReviewedBy,ReviewComment,ApprovedComment,TimeStamp,Is_Deleted,Status")] ExpenseHeader expenseHeader)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseHeader.Add(expenseHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", expenseHeader.AMLCompanyProfileId);
            return View(expenseHeader);
        }

        // GET: AdminExpenseHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseHeader expenseHeader = db.ExpenseHeader.Find(id);
            if (expenseHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", expenseHeader.AMLCompanyProfileId);
            return View(expenseHeader);
        }

        // POST: AdminExpenseHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExpenseNumber,AMLCompanyProfileId,DocumentDate,HeaderText,ApprovedDate,ApprovedBy,ReviewedDate,ReviewedBy,ReviewComment,ApprovedComment,TimeStamp,Is_Deleted,Status")] ExpenseHeader expenseHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", expenseHeader.AMLCompanyProfileId);
            return View(expenseHeader);
        }

        // GET: AdminExpenseHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseHeader expenseHeader = db.ExpenseHeader.Find(id);
            if (expenseHeader == null)
            {
                return HttpNotFound();
            }
            return View(expenseHeader);
        }

        // POST: AdminExpenseHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseHeader expenseHeader = db.ExpenseHeader.Find(id);
            db.ExpenseHeader.Remove(expenseHeader);
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
