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
    public class AdminAMLLendersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAMLLenders
        public ActionResult Index()
        {
            var aMLLenders = db.AMLLenders.Include(a => a.AMLCompanyProfile);
            return View(aMLLenders.ToList());
        }

        // GET: AdminAMLLenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLLenders aMLLenders = db.AMLLenders.Find(id);
            if (aMLLenders == null)
            {
                return HttpNotFound();
            }
            return View(aMLLenders);
        }

        // GET: AdminAMLLenders/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminAMLLenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,Name,Address,Account_RefNumber,TypeOfFacility,AmountOfFacility,RepaymentPeriod,TimeStamp,Is_Deleted,RepaymentTerms")] AMLLenders aMLLenders)
        {
            if (ModelState.IsValid)
            {
                db.AMLLenders.Add(aMLLenders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLLenders.AMLCompanyProfileId);
            return View(aMLLenders);
        }

        // GET: AdminAMLLenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLLenders aMLLenders = db.AMLLenders.Find(id);
            if (aMLLenders == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLLenders.AMLCompanyProfileId);
            return View(aMLLenders);
        }

        // POST: AdminAMLLenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,Name,Address,Account_RefNumber,TypeOfFacility,AmountOfFacility,RepaymentPeriod,TimeStamp,Is_Deleted,RepaymentTerms")] AMLLenders aMLLenders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLLenders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLLenders.AMLCompanyProfileId);
            return View(aMLLenders);
        }

        // GET: AdminAMLLenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLLenders aMLLenders = db.AMLLenders.Find(id);
            if (aMLLenders == null)
            {
                return HttpNotFound();
            }
            return View(aMLLenders);
        }

        // POST: AdminAMLLenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLLenders aMLLenders = db.AMLLenders.Find(id);
            db.AMLLenders.Remove(aMLLenders);
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
