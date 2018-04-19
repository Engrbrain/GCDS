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
    public class PNFPersonalDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PNFPersonalDetails
        public ActionResult Index()
        {
            var pNFPersonalDetails = db.PNFPersonalDetails.Include(p => p.AMLCompanyProfile);
            return View(pNFPersonalDetails.ToList());
        }

        // GET: PNFPersonalDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFPersonalDetails pNFPersonalDetails = db.PNFPersonalDetails.Find(id);
            if (pNFPersonalDetails == null)
            {
                return HttpNotFound();
            }
            return View(pNFPersonalDetails);
        }

        // GET: PNFPersonalDetails/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: PNFPersonalDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,Surname,FirstAndMiddleNames,PreviousNames,ReasonsForChangeOfName,DateOfBirth,PlaceOfBirth,Hometown,PresentNationality,PreviousNationality,PassportType,PassportNumber,DateOfPassportIssue,PlaceOfPassportIssue,PassportExpiryDate,PlacesTravelledTo,DateOfTravels,Hobbies,Occupation_Profession,FullNameOfFather,DateOfBirthOfFather,PlaceOfBirthOfFather,DateOfDeathOfFather,HometownOfFather,NationalityOfFather,OccupationOfFather,ResidentialAddressOfFather,PopularSpotsCloseToFathersResidence,FullNameOfMother,DateOfBirthOfMother,PlaceOfBirthOfMother,DateOfDeathOfMother,HometownOfMother,NationalityOfMother,OccupationOfMother,ResidentialAddressOfMother,PopularSpotsCloseToMothesResidence,BusinessAddressOfMother,NameOfProfessionalParties,NameOfSocialParties,NameOfPoliticalParties,NameOfCharitabledOrganizations,MaritalStatus,DateOfMarriage,PlaceOfMarriage,MarriageCertificateNumber,NameOfOneOfKeyWitness,AddressOfOneOfKeyWitness,FullNameOfFormerSpouse,PlaceOfBirthOfFormerSpouse,DateOfBirthOfFormerSpouse,BusinessAddressOfFormerSpouse,ResidentialAddressOfFormerSpouse,OccupationOfFormerSpouse,NamesOfChildrenWithPresentSpouse,AgesOfChildrenWithPresentSpouse,Is_Single,FullNameOfPresentGirlOrBoyfriend,ResidentialAddressOfPresentGirlOrBoyfriend,BusinessAddressOfPresentGirlOrBoyfriend,OccupationOfPresentGirlOrBoyfriend,FullNameOfFormerGirlOrBoyfriend,ResidentialAddressOfFormerGirlOrBoyfriend,BusinessAddressOfFormerGirlOrBoyfriend,OccupationOfFormerGirlOrBoyfriend,NamesOfChildren,TimeStamp,Is_Deleted,AgesOfChildren_For_Is_Single")] PNFPersonalDetails pNFPersonalDetails)
        {
            if (ModelState.IsValid)
            {
                db.PNFPersonalDetails.Add(pNFPersonalDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFPersonalDetails.AMLCompanyProfileId);
            return View(pNFPersonalDetails);
        }

        // GET: PNFPersonalDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFPersonalDetails pNFPersonalDetails = db.PNFPersonalDetails.Find(id);
            if (pNFPersonalDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFPersonalDetails.AMLCompanyProfileId);
            return View(pNFPersonalDetails);
        }

        // POST: PNFPersonalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,Surname,FirstAndMiddleNames,PreviousNames,ReasonsForChangeOfName,DateOfBirth,PlaceOfBirth,Hometown,PresentNationality,PreviousNationality,PassportType,PassportNumber,DateOfPassportIssue,PlaceOfPassportIssue,PassportExpiryDate,PlacesTravelledTo,DateOfTravels,Hobbies,Occupation_Profession,FullNameOfFather,DateOfBirthOfFather,PlaceOfBirthOfFather,DateOfDeathOfFather,HometownOfFather,NationalityOfFather,OccupationOfFather,ResidentialAddressOfFather,PopularSpotsCloseToFathersResidence,FullNameOfMother,DateOfBirthOfMother,PlaceOfBirthOfMother,DateOfDeathOfMother,HometownOfMother,NationalityOfMother,OccupationOfMother,ResidentialAddressOfMother,PopularSpotsCloseToMothesResidence,BusinessAddressOfMother,NameOfProfessionalParties,NameOfSocialParties,NameOfPoliticalParties,NameOfCharitabledOrganizations,MaritalStatus,DateOfMarriage,PlaceOfMarriage,MarriageCertificateNumber,NameOfOneOfKeyWitness,AddressOfOneOfKeyWitness,FullNameOfFormerSpouse,PlaceOfBirthOfFormerSpouse,DateOfBirthOfFormerSpouse,BusinessAddressOfFormerSpouse,ResidentialAddressOfFormerSpouse,OccupationOfFormerSpouse,NamesOfChildrenWithPresentSpouse,AgesOfChildrenWithPresentSpouse,Is_Single,FullNameOfPresentGirlOrBoyfriend,ResidentialAddressOfPresentGirlOrBoyfriend,BusinessAddressOfPresentGirlOrBoyfriend,OccupationOfPresentGirlOrBoyfriend,FullNameOfFormerGirlOrBoyfriend,ResidentialAddressOfFormerGirlOrBoyfriend,BusinessAddressOfFormerGirlOrBoyfriend,OccupationOfFormerGirlOrBoyfriend,NamesOfChildren,TimeStamp,Is_Deleted,AgesOfChildren_For_Is_Single")] PNFPersonalDetails pNFPersonalDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFPersonalDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFPersonalDetails.AMLCompanyProfileId);
            return View(pNFPersonalDetails);
        }

        // GET: PNFPersonalDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFPersonalDetails pNFPersonalDetails = db.PNFPersonalDetails.Find(id);
            if (pNFPersonalDetails == null)
            {
                return HttpNotFound();
            }
            return View(pNFPersonalDetails);
        }

        // POST: PNFPersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFPersonalDetails pNFPersonalDetails = db.PNFPersonalDetails.Find(id);
            db.PNFPersonalDetails.Remove(pNFPersonalDetails);
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
