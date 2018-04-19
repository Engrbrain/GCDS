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
    public class AdminMemosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminMemos
        public ActionResult Index()
        {
            var memo = db.Memo.Include(m => m.AMLCompanyProfile);
            return View(memo.ToList());
        }

        // GET: AdminMemos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.Memo.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // GET: AdminMemos/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminMemos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemoReference,MemoTitle,MemoDescription,MemoType,AMLCompanyProfileId")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                db.Memo.Add(memo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", memo.AMLCompanyProfileId);
            return View(memo);
        }

        // GET: AdminMemos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.Memo.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", memo.AMLCompanyProfileId);
            return View(memo);
        }

        // POST: AdminMemos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemoReference,MemoTitle,MemoDescription,MemoType,AMLCompanyProfileId")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", memo.AMLCompanyProfileId);
            return View(memo);
        }

        // GET: AdminMemos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.Memo.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // POST: AdminMemos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Memo memo = db.Memo.Find(id);
            db.Memo.Remove(memo);
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
