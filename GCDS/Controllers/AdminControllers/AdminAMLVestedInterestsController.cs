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
    public class AdminAMLVestedInterestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAMLVestedInterests
        public ActionResult Index()
        {
            var aMLVestedInterest = db.AMLVestedInterest.Include(a => a.AMLCompanyProfile);
            return View(aMLVestedInterest.ToList());
        }

        // GET: AdminAMLVestedInterests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLVestedInterest aMLVestedInterest = db.AMLVestedInterest.Find(id);
            if (aMLVestedInterest == null)
            {
                return HttpNotFound();
            }
            return View(aMLVestedInterest);
        }

        // GET: AdminAMLVestedInterests/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminAMLVestedInterests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileID,Is_Interest_InPerson,Is_Interest_InCompany,InterestDescription,Is_Supporting_Company,Is_Supporting_Business,TimeStamp,Is_Deleted,SupportDescription")] AMLVestedInterest aMLVestedInterest)
        {
            if (ModelState.IsValid)
            {
                db.AMLVestedInterest.Add(aMLVestedInterest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLVestedInterest.AMLCompanyProfileID);
            return View(aMLVestedInterest);
        }

        // GET: AdminAMLVestedInterests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLVestedInterest aMLVestedInterest = db.AMLVestedInterest.Find(id);
            if (aMLVestedInterest == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLVestedInterest.AMLCompanyProfileID);
            return View(aMLVestedInterest);
        }

        // POST: AdminAMLVestedInterests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileID,Is_Interest_InPerson,Is_Interest_InCompany,InterestDescription,Is_Supporting_Company,Is_Supporting_Business,TimeStamp,Is_Deleted,SupportDescription")] AMLVestedInterest aMLVestedInterest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLVestedInterest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLVestedInterest.AMLCompanyProfileID);
            return View(aMLVestedInterest);
        }

        // GET: AdminAMLVestedInterests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLVestedInterest aMLVestedInterest = db.AMLVestedInterest.Find(id);
            if (aMLVestedInterest == null)
            {
                return HttpNotFound();
            }
            return View(aMLVestedInterest);
        }

        // POST: AdminAMLVestedInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLVestedInterest aMLVestedInterest = db.AMLVestedInterest.Find(id);
            db.AMLVestedInterest.Remove(aMLVestedInterest);
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
