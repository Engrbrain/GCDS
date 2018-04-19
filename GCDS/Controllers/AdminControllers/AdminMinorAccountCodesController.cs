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
    public class AdminMinorAccountCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminMinorAccountCodes
        public ActionResult Index()
        {
            var minorAccountCode = db.MinorAccountCode.Include(m => m.MajorAccountCode);
            return View(minorAccountCode.ToList());
        }

        // GET: AdminMinorAccountCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinorAccountCode minorAccountCode = db.MinorAccountCode.Find(id);
            if (minorAccountCode == null)
            {
                return HttpNotFound();
            }
            return View(minorAccountCode);
        }

        // GET: AdminMinorAccountCodes/Create
        public ActionResult Create()
        {
            ViewBag.MajorAccountCodeId = new SelectList(db.MajorAccountCode, "Id", "Code");
            return View();
        }

        // POST: AdminMinorAccountCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MajorAccountCodeId,Code,Description,CreatedDate,CompleteCOA,Is_Deleted")] MinorAccountCode minorAccountCode)
        {
            if (ModelState.IsValid)
            {
                db.MinorAccountCode.Add(minorAccountCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorAccountCodeId = new SelectList(db.MajorAccountCode, "Id", "Code", minorAccountCode.MajorAccountCodeId);
            return View(minorAccountCode);
        }

        // GET: AdminMinorAccountCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinorAccountCode minorAccountCode = db.MinorAccountCode.Find(id);
            if (minorAccountCode == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorAccountCodeId = new SelectList(db.MajorAccountCode, "Id", "Code", minorAccountCode.MajorAccountCodeId);
            return View(minorAccountCode);
        }

        // POST: AdminMinorAccountCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MajorAccountCodeId,Code,Description,CreatedDate,CompleteCOA,Is_Deleted")] MinorAccountCode minorAccountCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(minorAccountCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorAccountCodeId = new SelectList(db.MajorAccountCode, "Id", "Code", minorAccountCode.MajorAccountCodeId);
            return View(minorAccountCode);
        }

        // GET: AdminMinorAccountCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinorAccountCode minorAccountCode = db.MinorAccountCode.Find(id);
            if (minorAccountCode == null)
            {
                return HttpNotFound();
            }
            return View(minorAccountCode);
        }

        // POST: AdminMinorAccountCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MinorAccountCode minorAccountCode = db.MinorAccountCode.Find(id);
            db.MinorAccountCode.Remove(minorAccountCode);
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
