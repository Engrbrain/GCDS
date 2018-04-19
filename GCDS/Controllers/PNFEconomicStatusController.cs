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
    public class PNFEconomicStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PNFEconomicStatus
        public ActionResult Index()
        {
            var pNFEconomicStatus = db.PNFEconomicStatus.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFEconomicStatus.ToList());
        }

        // GET: PNFEconomicStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFEconomicStatus pNFEconomicStatus = db.PNFEconomicStatus.Find(id);
            if (pNFEconomicStatus == null)
            {
                return HttpNotFound();
            }
            return View(pNFEconomicStatus);
        }

        // GET: PNFEconomicStatus/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: PNFEconomicStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,AMLCompanyProfileId,PNFPersonalDetailsId,Is_AssetOwner,AssetParticulars_Description,LocationOfAsset,DescriptionOfObtainingAsset,TaxCertificateNumberOfAsset,TimeStamp,Is_Deleted,IssueDateOfTaxCertificateOfAsset")] PNFEconomicStatus pNFEconomicStatus)
        {
            if (ModelState.IsValid)
            {
                db.PNFEconomicStatus.Add(pNFEconomicStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFEconomicStatus.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFEconomicStatus.PNFPersonalDetailsId);
            return View(pNFEconomicStatus);
        }

        // GET: PNFEconomicStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFEconomicStatus pNFEconomicStatus = db.PNFEconomicStatus.Find(id);
            if (pNFEconomicStatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFEconomicStatus.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFEconomicStatus.PNFPersonalDetailsId);
            return View(pNFEconomicStatus);
        }

        // POST: PNFEconomicStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,AMLCompanyProfileId,PNFPersonalDetailsId,Is_AssetOwner,AssetParticulars_Description,LocationOfAsset,DescriptionOfObtainingAsset,TaxCertificateNumberOfAsset,TimeStamp,Is_Deleted,IssueDateOfTaxCertificateOfAsset")] PNFEconomicStatus pNFEconomicStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFEconomicStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFEconomicStatus.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFEconomicStatus.PNFPersonalDetailsId);
            return View(pNFEconomicStatus);
        }

        // GET: PNFEconomicStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFEconomicStatus pNFEconomicStatus = db.PNFEconomicStatus.Find(id);
            if (pNFEconomicStatus == null)
            {
                return HttpNotFound();
            }
            return View(pNFEconomicStatus);
        }

        // POST: PNFEconomicStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFEconomicStatus pNFEconomicStatus = db.PNFEconomicStatus.Find(id);
            db.PNFEconomicStatus.Remove(pNFEconomicStatus);
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
