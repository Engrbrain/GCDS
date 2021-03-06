﻿using System;
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
    public class AdminAccountPayablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAccountPayables
        public ActionResult Index()
        {
            return View(db.AccountPayable.ToList());
        }

        // GET: AdminAccountPayables/Details/5
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

        // GET: AdminAccountPayables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAccountPayables/Create
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

        // GET: AdminAccountPayables/Edit/5
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

        // POST: AdminAccountPayables/Edit/5
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

        // GET: AdminAccountPayables/Delete/5
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

        // POST: AdminAccountPayables/Delete/5
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
