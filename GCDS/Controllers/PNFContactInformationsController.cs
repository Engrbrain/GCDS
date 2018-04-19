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
    public class PNFContactInformationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PNFContactInformations
        public ActionResult Index()
        {
            var pNFContactInformation = db.PNFContactInformation.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFContactInformation.ToList());
        }

        // GET: PNFContactInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFContactInformation pNFContactInformation = db.PNFContactInformation.Find(id);
            if (pNFContactInformation == null)
            {
                return HttpNotFound();
            }
            return View(pNFContactInformation);
        }

        // GET: PNFContactInformations/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: PNFContactInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,AMLCompanyProfileId,PNFPersonalDetailsId,CurrentResidentialAddress,HouseNumber,Street,Suburb,Town,District,State,Region,PopularSpotsOrPersonalityNearResidence,HomeNumber,MobileNumber,FaxNumber,EmailAddress,CorrespondenceAddress,PreviousResidenceAddress,PreviousHouseNumber,PreviousStreet,PreviousTown,PreviousDistrict,PreviousRegion,HomeTownAddress,HomeTownHouseNumber,HomeTownStreet,HomeTownName,HomeTownDistrict,HomeTownRegion,EmploymentAddress,BusinessName,BusinessStreetName,BusinessTown,BusinessState,BusinessRegion,AnyClosePopularSpotToBusiness,EmployersTelephoneNumber,EmployersFaxNumber,TimeStamp,Is_Deleted,EmployesEmailAddress")] PNFContactInformation pNFContactInformation)
        {
            if (ModelState.IsValid)
            {
                db.PNFContactInformation.Add(pNFContactInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFContactInformation.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFContactInformation.PNFPersonalDetailsId);
            return View(pNFContactInformation);
        }

        // GET: PNFContactInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFContactInformation pNFContactInformation = db.PNFContactInformation.Find(id);
            if (pNFContactInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFContactInformation.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFContactInformation.PNFPersonalDetailsId);
            return View(pNFContactInformation);
        }

        // POST: PNFContactInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,AMLCompanyProfileId,PNFPersonalDetailsId,CurrentResidentialAddress,HouseNumber,Street,Suburb,Town,District,State,Region,PopularSpotsOrPersonalityNearResidence,HomeNumber,MobileNumber,FaxNumber,EmailAddress,CorrespondenceAddress,PreviousResidenceAddress,PreviousHouseNumber,PreviousStreet,PreviousTown,PreviousDistrict,PreviousRegion,HomeTownAddress,HomeTownHouseNumber,HomeTownStreet,HomeTownName,HomeTownDistrict,HomeTownRegion,EmploymentAddress,BusinessName,BusinessStreetName,BusinessTown,BusinessState,BusinessRegion,AnyClosePopularSpotToBusiness,EmployersTelephoneNumber,EmployersFaxNumber,TimeStamp,Is_Deleted,EmployesEmailAddress")] PNFContactInformation pNFContactInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFContactInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFContactInformation.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFContactInformation.PNFPersonalDetailsId);
            return View(pNFContactInformation);
        }

        // GET: PNFContactInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFContactInformation pNFContactInformation = db.PNFContactInformation.Find(id);
            if (pNFContactInformation == null)
            {
                return HttpNotFound();
            }
            return View(pNFContactInformation);
        }

        // POST: PNFContactInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFContactInformation pNFContactInformation = db.PNFContactInformation.Find(id);
            db.PNFContactInformation.Remove(pNFContactInformation);
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
