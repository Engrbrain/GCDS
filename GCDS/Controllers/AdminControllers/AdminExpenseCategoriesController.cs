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
    public class AdminExpenseCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminExpenseCategories
        public ActionResult Index()
        {
            return View(db.ExpenseCategory.ToList());
        }

        // GET: AdminExpenseCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expenseCategory = db.ExpenseCategory.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        // GET: AdminExpenseCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminExpenseCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TimeStamp,Is_Deleted,Description")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseCategory.Add(expenseCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseCategory);
        }

        // GET: AdminExpenseCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expenseCategory = db.ExpenseCategory.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        // POST: AdminExpenseCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TimeStamp,Is_Deleted,Description")] ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseCategory);
        }

        // GET: AdminExpenseCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCategory expenseCategory = db.ExpenseCategory.Find(id);
            if (expenseCategory == null)
            {
                return HttpNotFound();
            }
            return View(expenseCategory);
        }

        // POST: AdminExpenseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseCategory expenseCategory = db.ExpenseCategory.Find(id);
            db.ExpenseCategory.Remove(expenseCategory);
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
