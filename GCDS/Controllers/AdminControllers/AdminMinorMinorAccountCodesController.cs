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
    public class AdminMinorMinorAccountCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminMinorMinorAccountCodes
        public ActionResult Index()
        {
            var minorMinorAccountCode = db.MinorMinorAccountCode.Include(m => m.MajorAccountCode).Include(m => m.MinorAccountCode);
            return View(minorMinorAccountCode.ToList());
        }

        // GET: AdminMinorMinorAccountCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinorMinorAccountCode minorMinorAccountCode = db.MinorMinorAccountCode.Find(id);
            if (minorMinorAccountCode == null)
            {
                return HttpNotFound();
            }
            return View(minorMinorAccountCode);
        }

        // GET: AdminMinorMinorAccountCodes/Create
        public ActionResult Create()
        {
            ViewBag.MajorAccountCodeId = new SelectList(db.MajorAccountCode, "Id", "Code");
            ViewBag.MinorAccountCodeId = new SelectList(db.MinorAccountCode, "Id", "Code");
            return View();
        }

        // POST: AdminMinorMinorAccountCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MajorAccountCodeId,MinorAccountCodeId,Code,Description,CreatedDate,CompleteCOA,AccountType,Is_Deleted")] MinorMinorAccountCode minorMinorAccountCode)
        {
            if (ModelState.IsValid)
            {
                db.MinorMinorAccountCode.Add(minorMinorAccountCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorAccountCodeId = new SelectList(db.MajorAccountCode, "Id", "Code", minorMinorAccountCode.MajorAccountCodeId);
            ViewBag.MinorAccountCodeId = new SelectList(db.MinorAccountCode, "Id", "Code", minorMinorAccountCode.MinorAccountCodeId);
            return View(minorMinorAccountCode);
        }

        // GET: AdminMinorMinorAccountCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinorMinorAccountCode minorMinorAccountCode = db.MinorMinorAccountCode.Find(id);
            if (minorMinorAccountCode == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorAccountCodeId = new SelectList(db.MajorAccountCode, "Id", "Code", minorMinorAccountCode.MajorAccountCodeId);
            ViewBag.MinorAccountCodeId = new SelectList(db.MinorAccountCode, "Id", "Code", minorMinorAccountCode.MinorAccountCodeId);
            return View(minorMinorAccountCode);
        }

        // POST: AdminMinorMinorAccountCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MajorAccountCodeId,MinorAccountCodeId,Code,Description,CreatedDate,CompleteCOA,AccountType,Is_Deleted")] MinorMinorAccountCode minorMinorAccountCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(minorMinorAccountCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorAccountCodeId = new SelectList(db.MajorAccountCode, "Id", "Code", minorMinorAccountCode.MajorAccountCodeId);
            ViewBag.MinorAccountCodeId = new SelectList(db.MinorAccountCode, "Id", "Code", minorMinorAccountCode.MinorAccountCodeId);
            return View(minorMinorAccountCode);
        }

        // GET: AdminMinorMinorAccountCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinorMinorAccountCode minorMinorAccountCode = db.MinorMinorAccountCode.Find(id);
            if (minorMinorAccountCode == null)
            {
                return HttpNotFound();
            }
            return View(minorMinorAccountCode);
        }

        // POST: AdminMinorMinorAccountCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MinorMinorAccountCode minorMinorAccountCode = db.MinorMinorAccountCode.Find(id);
            db.MinorMinorAccountCode.Remove(minorMinorAccountCode);
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
