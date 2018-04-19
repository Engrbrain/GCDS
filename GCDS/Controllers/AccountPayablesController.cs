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
    public class AccountPayablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccountPayables
        public ActionResult Index()
        {
            return View(db.AccountPayable.ToList());
        }

        // GET: AccountPayables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountPayable accountPayable = db.AccountPayable.Find(id);
            if (accountPayable == null)
            {
                return HttpNotFound();
            }
            return View(accountPayable);
        }

        // GET: AccountPayables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountPayables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,Address,PhoneNumber,EmailAddress,Country,Region,VendorFullName,VendorAddress,VendorGender,VendorEmailAddress,ServiceDescription")] AccountPayable accountPayable)
        {
            if (ModelState.IsValid)
            {
                db.AccountPayable.Add(accountPayable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountPayable);
        }

        // GET: AccountPayables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountPayable accountPayable = db.AccountPayable.Find(id);
            if (accountPayable == null)
            {
                return HttpNotFound();
            }
            return View(accountPayable);
        }

        // POST: AccountPayables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,Address,PhoneNumber,EmailAddress,Country,Region,VendorFullName,VendorAddress,VendorGender,VendorEmailAddress,ServiceDescription")] AccountPayable accountPayable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountPayable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountPayable);
        }

        // GET: AccountPayables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountPayable accountPayable = db.AccountPayable.Find(id);
            if (accountPayable == null)
            {
                return HttpNotFound();
            }
            return View(accountPayable);
        }

        // POST: AccountPayables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountPayable accountPayable = db.AccountPayable.Find(id);
            db.AccountPayable.Remove(accountPayable);
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
