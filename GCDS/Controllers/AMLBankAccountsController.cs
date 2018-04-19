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
    public class AMLBankAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AMLBankAccounts
        public ActionResult Index()
        {
            var aMLBankAccount = db.AMLBankAccount.Include(a => a.AMLCompanyProfile);
            return View(aMLBankAccount.ToList());
        }

        // GET: AMLBankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLBankAccount aMLBankAccount = db.AMLBankAccount.Find(id);
            if (aMLBankAccount == null)
            {
                return HttpNotFound();
            }
            return View(aMLBankAccount);
        }

        // GET: AMLBankAccounts/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AMLBankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,NameOfBank,AccountNumber,AccountName,Address,ContactNames,TimeStamp,Is_Deleted,Is_ForeignAccount")] AMLBankAccount aMLBankAccount)
        {
            if (ModelState.IsValid)
            {
                db.AMLBankAccount.Add(aMLBankAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLBankAccount.AMLCompanyProfileId);
            return View(aMLBankAccount);
        }

        // GET: AMLBankAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLBankAccount aMLBankAccount = db.AMLBankAccount.Find(id);
            if (aMLBankAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLBankAccount.AMLCompanyProfileId);
            return View(aMLBankAccount);
        }

        // POST: AMLBankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,NameOfBank,AccountNumber,AccountName,Address,ContactNames,TimeStamp,Is_Deleted,Is_ForeignAccount")] AMLBankAccount aMLBankAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLBankAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLBankAccount.AMLCompanyProfileId);
            return View(aMLBankAccount);
        }

        // GET: AMLBankAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLBankAccount aMLBankAccount = db.AMLBankAccount.Find(id);
            if (aMLBankAccount == null)
            {
                return HttpNotFound();
            }
            return View(aMLBankAccount);
        }

        // POST: AMLBankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLBankAccount aMLBankAccount = db.AMLBankAccount.Find(id);
            db.AMLBankAccount.Remove(aMLBankAccount);
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
