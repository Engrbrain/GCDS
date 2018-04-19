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
    public class PNFCompanyProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PNFCompanyProfiles
        public ActionResult Index()
        {
            var pNFCompanyProfile = db.PNFCompanyProfile.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFCompanyProfile.ToList());
        }

        // GET: PNFCompanyProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFCompanyProfile pNFCompanyProfile = db.PNFCompanyProfile.Find(id);
            if (pNFCompanyProfile == null)
            {
                return HttpNotFound();
            }
            return View(pNFCompanyProfile);
        }

        // GET: PNFCompanyProfiles/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: PNFCompanyProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,AMLCompanyProfileId,PNFPersonalDetailsId,NameOfCompany,BusinessAddressOfCompany,HouseNumberOfCompany,StreetNameOfCompany,TownOfCompany,PopularSpotCloseToCompany,DateOfIncorporation,RegistrationNumber,NumberOfInitialWorkForce,NameOfBankers,AddressOfBankers,NameOfAuditors,AddressOfAuditors,NameOfOtherCompanyDirectors,AddressofOtherCompanyDirectors,TimeStamp,Is_Deleted,ReasonsForEstablishingCompany")] PNFCompanyProfile pNFCompanyProfile)
        {
            if (ModelState.IsValid)
            {
                db.PNFCompanyProfile.Add(pNFCompanyProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFCompanyProfile.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFCompanyProfile.PNFPersonalDetailsId);
            return View(pNFCompanyProfile);
        }

        // GET: PNFCompanyProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFCompanyProfile pNFCompanyProfile = db.PNFCompanyProfile.Find(id);
            if (pNFCompanyProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFCompanyProfile.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFCompanyProfile.PNFPersonalDetailsId);
            return View(pNFCompanyProfile);
        }

        // POST: PNFCompanyProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,AMLCompanyProfileId,PNFPersonalDetailsId,NameOfCompany,BusinessAddressOfCompany,HouseNumberOfCompany,StreetNameOfCompany,TownOfCompany,PopularSpotCloseToCompany,DateOfIncorporation,RegistrationNumber,NumberOfInitialWorkForce,NameOfBankers,AddressOfBankers,NameOfAuditors,AddressOfAuditors,NameOfOtherCompanyDirectors,AddressofOtherCompanyDirectors,TimeStamp,Is_Deleted,ReasonsForEstablishingCompany")] PNFCompanyProfile pNFCompanyProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFCompanyProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFCompanyProfile.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFCompanyProfile.PNFPersonalDetailsId);
            return View(pNFCompanyProfile);
        }

        // GET: PNFCompanyProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFCompanyProfile pNFCompanyProfile = db.PNFCompanyProfile.Find(id);
            if (pNFCompanyProfile == null)
            {
                return HttpNotFound();
            }
            return View(pNFCompanyProfile);
        }

        // POST: PNFCompanyProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFCompanyProfile pNFCompanyProfile = db.PNFCompanyProfile.Find(id);
            db.PNFCompanyProfile.Remove(pNFCompanyProfile);
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
