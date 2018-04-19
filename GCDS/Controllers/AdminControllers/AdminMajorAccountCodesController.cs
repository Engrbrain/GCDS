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
    public class AdminMajorAccountCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminMajorAccountCodes
        public ActionResult Index()
        {
            return View(db.MajorAccountCode.ToList());
        }

        // GET: AdminMajorAccountCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorAccountCode majorAccountCode = db.MajorAccountCode.Find(id);
            if (majorAccountCode == null)
            {
                return HttpNotFound();
            }
            return View(majorAccountCode);
        }

        // GET: AdminMajorAccountCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminMajorAccountCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Description,CreatedDate,CompleteCOA,Is_Deleted")] MajorAccountCode majorAccountCode)
        {
            if (ModelState.IsValid)
            {
                db.MajorAccountCode.Add(majorAccountCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(majorAccountCode);
        }

        // GET: AdminMajorAccountCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorAccountCode majorAccountCode = db.MajorAccountCode.Find(id);
            if (majorAccountCode == null)
            {
                return HttpNotFound();
            }
            return View(majorAccountCode);
        }

        // POST: AdminMajorAccountCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Description,CreatedDate,CompleteCOA,Is_Deleted")] MajorAccountCode majorAccountCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(majorAccountCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(majorAccountCode);
        }

        // GET: AdminMajorAccountCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MajorAccountCode majorAccountCode = db.MajorAccountCode.Find(id);
            if (majorAccountCode == null)
            {
                return HttpNotFound();
            }
            return View(majorAccountCode);
        }

        // POST: AdminMajorAccountCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MajorAccountCode majorAccountCode = db.MajorAccountCode.Find(id);
            db.MajorAccountCode.Remove(majorAccountCode);
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
