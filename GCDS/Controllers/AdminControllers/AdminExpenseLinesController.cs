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
    public class AdminExpenseLinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminExpenseLines
        public ActionResult Index()
        {
            var expenseLine = db.ExpenseLine.Include(e => e.ExpenseCategory).Include(e => e.ExpenseHeader);
            return View(expenseLine.ToList());
        }

        // GET: AdminExpenseLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseLine expenseLine = db.ExpenseLine.Find(id);
            if (expenseLine == null)
            {
                return HttpNotFound();
            }
            return View(expenseLine);
        }

        // GET: AdminExpenseLines/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategory, "Id", "Name");
            ViewBag.ExpenseHeaderId = new SelectList(db.ExpenseHeader, "Id", "HeaderText");
            return View();
        }

        // POST: AdminExpenseLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InvoiceNumber,ExpenseHeaderId,ExpenseCategoryID,LineitemNumber,Narration,UnitPrice,Units,GrossAmount,Discount,Tax,NetAmount,TimeStamp,Is_Deleted")] ExpenseLine expenseLine)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseLine.Add(expenseLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategory, "Id", "Name", expenseLine.ExpenseCategoryID);
            ViewBag.ExpenseHeaderId = new SelectList(db.ExpenseHeader, "Id", "HeaderText", expenseLine.ExpenseHeaderId);
            return View(expenseLine);
        }

        // GET: AdminExpenseLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseLine expenseLine = db.ExpenseLine.Find(id);
            if (expenseLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategory, "Id", "Name", expenseLine.ExpenseCategoryID);
            ViewBag.ExpenseHeaderId = new SelectList(db.ExpenseHeader, "Id", "HeaderText", expenseLine.ExpenseHeaderId);
            return View(expenseLine);
        }

        // POST: AdminExpenseLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InvoiceNumber,ExpenseHeaderId,ExpenseCategoryID,LineitemNumber,Narration,UnitPrice,Units,GrossAmount,Discount,Tax,NetAmount,TimeStamp,Is_Deleted")] ExpenseLine expenseLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseCategoryID = new SelectList(db.ExpenseCategory, "Id", "Name", expenseLine.ExpenseCategoryID);
            ViewBag.ExpenseHeaderId = new SelectList(db.ExpenseHeader, "Id", "HeaderText", expenseLine.ExpenseHeaderId);
            return View(expenseLine);
        }

        // GET: AdminExpenseLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseLine expenseLine = db.ExpenseLine.Find(id);
            if (expenseLine == null)
            {
                return HttpNotFound();
            }
            return View(expenseLine);
        }

        // POST: AdminExpenseLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseLine expenseLine = db.ExpenseLine.Find(id);
            db.ExpenseLine.Remove(expenseLine);
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
