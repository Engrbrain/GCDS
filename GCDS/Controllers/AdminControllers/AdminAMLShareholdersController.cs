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
    public class AdminAMLShareholdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAMLShareholders
        public ActionResult Index()
        {
            var aMLShareholder = db.AMLShareholder.Include(a => a.AMLCompanyProfile);
            return View(aMLShareholder.ToList());
        }

        // GET: AdminAMLShareholders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLShareholder aMLShareholder = db.AMLShareholder.Find(id);
            if (aMLShareholder == null)
            {
                return HttpNotFound();
            }
            return View(aMLShareholder);
        }

        // GET: AdminAMLShareholders/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminAMLShareholders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,NameOfShareholder,Address,Shareholding,Percentage,TimeStamp,Is_Deleted,NumberOfShareholdersWithLessThanFivePercent")] AMLShareholder aMLShareholder)
        {
            if (ModelState.IsValid)
            {
                db.AMLShareholder.Add(aMLShareholder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLShareholder.AMLCompanyProfileId);
            return View(aMLShareholder);
        }

        // GET: AdminAMLShareholders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLShareholder aMLShareholder = db.AMLShareholder.Find(id);
            if (aMLShareholder == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLShareholder.AMLCompanyProfileId);
            return View(aMLShareholder);
        }

        // POST: AdminAMLShareholders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,NameOfShareholder,Address,Shareholding,Percentage,TimeStamp,Is_Deleted,NumberOfShareholdersWithLessThanFivePercent")] AMLShareholder aMLShareholder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLShareholder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLShareholder.AMLCompanyProfileId);
            return View(aMLShareholder);
        }

        // GET: AdminAMLShareholders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLShareholder aMLShareholder = db.AMLShareholder.Find(id);
            if (aMLShareholder == null)
            {
                return HttpNotFound();
            }
            return View(aMLShareholder);
        }

        // POST: AdminAMLShareholders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLShareholder aMLShareholder = db.AMLShareholder.Find(id);
            db.AMLShareholder.Remove(aMLShareholder);
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
