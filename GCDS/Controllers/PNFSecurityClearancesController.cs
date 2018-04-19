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
    public class PNFSecurityClearancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PNFSecurityClearances
        public ActionResult Index()
        {
            var pNFSecurityClearance = db.PNFSecurityClearance.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFSecurityClearance.ToList());
        }

        // GET: PNFSecurityClearances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFSecurityClearance pNFSecurityClearance = db.PNFSecurityClearance.Find(id);
            if (pNFSecurityClearance == null)
            {
                return HttpNotFound();
            }
            return View(pNFSecurityClearance);
        }

        // GET: PNFSecurityClearances/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: PNFSecurityClearances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,Is_LawOffender,OffenseDescription,Comments_AdditionalInformation,Date,Is_Declared,Signature,TimeStamp,Is_Deleted")] PNFSecurityClearance pNFSecurityClearance)
        {
            if (ModelState.IsValid)
            {
                db.PNFSecurityClearance.Add(pNFSecurityClearance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFSecurityClearance.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFSecurityClearance.PNFPersonalDetailsId);
            return View(pNFSecurityClearance);
        }

        // GET: PNFSecurityClearances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFSecurityClearance pNFSecurityClearance = db.PNFSecurityClearance.Find(id);
            if (pNFSecurityClearance == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFSecurityClearance.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFSecurityClearance.PNFPersonalDetailsId);
            return View(pNFSecurityClearance);
        }

        // POST: PNFSecurityClearances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,Is_LawOffender,OffenseDescription,Comments_AdditionalInformation,Date,Is_Declared,Signature,TimeStamp,Is_Deleted")] PNFSecurityClearance pNFSecurityClearance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFSecurityClearance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFSecurityClearance.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFSecurityClearance.PNFPersonalDetailsId);
            return View(pNFSecurityClearance);
        }

        // GET: PNFSecurityClearances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFSecurityClearance pNFSecurityClearance = db.PNFSecurityClearance.Find(id);
            if (pNFSecurityClearance == null)
            {
                return HttpNotFound();
            }
            return View(pNFSecurityClearance);
        }

        // POST: PNFSecurityClearances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFSecurityClearance pNFSecurityClearance = db.PNFSecurityClearance.Find(id);
            db.PNFSecurityClearance.Remove(pNFSecurityClearance);
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
