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
    public class AdminChartOfAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminChartOfAccounts
        public ActionResult Index()
        {
            return View(db.ChartOfAccount.ToList());
        }

        // GET: AdminChartOfAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChartOfAccount chartOfAccount = db.ChartOfAccount.Find(id);
            if (chartOfAccount == null)
            {
                return HttpNotFound();
            }
            return View(chartOfAccount);
        }

        // GET: AdminChartOfAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminChartOfAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GLAccount,Description,DateCreated,Is_Deleted")] ChartOfAccount chartOfAccount)
        {
            if (ModelState.IsValid)
            {
                db.ChartOfAccount.Add(chartOfAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chartOfAccount);
        }

        // GET: AdminChartOfAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChartOfAccount chartOfAccount = db.ChartOfAccount.Find(id);
            if (chartOfAccount == null)
            {
                return HttpNotFound();
            }
            return View(chartOfAccount);
        }

        // POST: AdminChartOfAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GLAccount,Description,DateCreated,Is_Deleted")] ChartOfAccount chartOfAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chartOfAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chartOfAccount);
        }

        // GET: AdminChartOfAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChartOfAccount chartOfAccount = db.ChartOfAccount.Find(id);
            if (chartOfAccount == null)
            {
                return HttpNotFound();
            }
            return View(chartOfAccount);
        }

        // POST: AdminChartOfAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChartOfAccount chartOfAccount = db.ChartOfAccount.Find(id);
            db.ChartOfAccount.Remove(chartOfAccount);
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
