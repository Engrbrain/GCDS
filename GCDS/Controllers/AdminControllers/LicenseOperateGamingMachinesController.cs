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
    public class LicenseOperateGamingMachinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LicenseOperateGamingMachines
        public ActionResult Index()
        {
            var licenseOperateGamingMachine = db.LicenseOperateGamingMachine.Include(l => l.AMLCompanyProfile).Include(l => l.GamingEquipment);
            return View(licenseOperateGamingMachine.ToList());
        }

        // GET: LicenseOperateGamingMachines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseOperateGamingMachine licenseOperateGamingMachine = db.LicenseOperateGamingMachine.Find(id);
            if (licenseOperateGamingMachine == null)
            {
                return HttpNotFound();
            }
            return View(licenseOperateGamingMachine);
        }

        // GET: LicenseOperateGamingMachines/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName");
            return View();
        }

        // POST: LicenseOperateGamingMachines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GamingEquipmentId,AMLCompanyProfileId,FullNameOfApplicant,Address,Nationality,MakeOfMachine,SerialNumber,DateOfImportation,ParticularsOfImportLicense,CountryOfOrigin,CostOfMachine,AmountOfCustomDutyPaid,ReceiptNumberOfCustomDutyPaid,IncomeTaxClearanceCertificateNumber,NumberOfPreviousLicense,PreviousLicenseIssuedBy,FeePaidForPreviousLicense,DateOfExpiryForPreviousLicense,NameOfProposedPremisesForMachine,ProposedTown_CityForMachine,NameOfPresentPremisesForMAchine,PresentTown_CityForMachine,Is_ProposedLocationOwnedByApplicant,DescriptionOfAcquiringLocation,NumberOfPresentGamblingMachinesOwned,Is_TrueOwnerOfMachine,Signature,SignatureDate,TimeStamp,Is_Deleted")] LicenseOperateGamingMachine licenseOperateGamingMachine)
        {
            if (ModelState.IsValid)
            {
                db.LicenseOperateGamingMachine.Add(licenseOperateGamingMachine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", licenseOperateGamingMachine.AMLCompanyProfileId);
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName", licenseOperateGamingMachine.GamingEquipmentId);
            return View(licenseOperateGamingMachine);
        }

        // GET: LicenseOperateGamingMachines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseOperateGamingMachine licenseOperateGamingMachine = db.LicenseOperateGamingMachine.Find(id);
            if (licenseOperateGamingMachine == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", licenseOperateGamingMachine.AMLCompanyProfileId);
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName", licenseOperateGamingMachine.GamingEquipmentId);
            return View(licenseOperateGamingMachine);
        }

        // POST: LicenseOperateGamingMachines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GamingEquipmentId,AMLCompanyProfileId,FullNameOfApplicant,Address,Nationality,MakeOfMachine,SerialNumber,DateOfImportation,ParticularsOfImportLicense,CountryOfOrigin,CostOfMachine,AmountOfCustomDutyPaid,ReceiptNumberOfCustomDutyPaid,IncomeTaxClearanceCertificateNumber,NumberOfPreviousLicense,PreviousLicenseIssuedBy,FeePaidForPreviousLicense,DateOfExpiryForPreviousLicense,NameOfProposedPremisesForMachine,ProposedTown_CityForMachine,NameOfPresentPremisesForMAchine,PresentTown_CityForMachine,Is_ProposedLocationOwnedByApplicant,DescriptionOfAcquiringLocation,NumberOfPresentGamblingMachinesOwned,Is_TrueOwnerOfMachine,Signature,SignatureDate,TimeStamp,Is_Deleted")] LicenseOperateGamingMachine licenseOperateGamingMachine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenseOperateGamingMachine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", licenseOperateGamingMachine.AMLCompanyProfileId);
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName", licenseOperateGamingMachine.GamingEquipmentId);
            return View(licenseOperateGamingMachine);
        }

        // GET: LicenseOperateGamingMachines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseOperateGamingMachine licenseOperateGamingMachine = db.LicenseOperateGamingMachine.Find(id);
            if (licenseOperateGamingMachine == null)
            {
                return HttpNotFound();
            }
            return View(licenseOperateGamingMachine);
        }

        // POST: LicenseOperateGamingMachines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LicenseOperateGamingMachine licenseOperateGamingMachine = db.LicenseOperateGamingMachine.Find(id);
            db.LicenseOperateGamingMachine.Remove(licenseOperateGamingMachine);
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
