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
    public class AdminConsentToSellGamingMachinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminConsentToSellGamingMachines
        public ActionResult Index()
        {
            var consentToSellGamingMachines = db.ConsentToSellGamingMachines.Include(c => c.AMLCompanyProfile).Include(c => c.GamingEquipment);
            return View(consentToSellGamingMachines.ToList());
        }

        // GET: AdminConsentToSellGamingMachines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsentToSellGamingMachines consentToSellGamingMachines = db.ConsentToSellGamingMachines.Find(id);
            if (consentToSellGamingMachines == null)
            {
                return HttpNotFound();
            }
            return View(consentToSellGamingMachines);
        }

        // GET: AdminConsentToSellGamingMachines/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName");
            return View();
        }

        // POST: AdminConsentToSellGamingMachines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GamingEquipmentId,AMLCompanyProfileId,FullNameOfApplicant,Address,Nationality,MakeOfMachine,SerialNumber,NatureOfProposedTransaction,NatureOfProposedBuyer_Hirer_Consignee,AddressOfProposedBuyer_Hirer_Consignee,NationalityOfProposedBuyer_Hirer_Consignee,NameOfProposedPremisesForMachine,ProposedTown_CityForMachine,NameOfPresentPremisesForMAchine,PresentTown_CityForMachine,NumberOfPresentGamblingMachinesLicense,Is_TrueOwnerOfMachine,DateOfExpiryOfPresentLicense,SignatureOfApplicant,ConsentDate,TimeStamp,Is_Deleted")] ConsentToSellGamingMachines consentToSellGamingMachines)
        {
            if (ModelState.IsValid)
            {
                db.ConsentToSellGamingMachines.Add(consentToSellGamingMachines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", consentToSellGamingMachines.AMLCompanyProfileId);
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName", consentToSellGamingMachines.GamingEquipmentId);
            return View(consentToSellGamingMachines);
        }

        // GET: AdminConsentToSellGamingMachines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsentToSellGamingMachines consentToSellGamingMachines = db.ConsentToSellGamingMachines.Find(id);
            if (consentToSellGamingMachines == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", consentToSellGamingMachines.AMLCompanyProfileId);
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName", consentToSellGamingMachines.GamingEquipmentId);
            return View(consentToSellGamingMachines);
        }

        // POST: AdminConsentToSellGamingMachines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GamingEquipmentId,AMLCompanyProfileId,FullNameOfApplicant,Address,Nationality,MakeOfMachine,SerialNumber,NatureOfProposedTransaction,NatureOfProposedBuyer_Hirer_Consignee,AddressOfProposedBuyer_Hirer_Consignee,NationalityOfProposedBuyer_Hirer_Consignee,NameOfProposedPremisesForMachine,ProposedTown_CityForMachine,NameOfPresentPremisesForMAchine,PresentTown_CityForMachine,NumberOfPresentGamblingMachinesLicense,Is_TrueOwnerOfMachine,DateOfExpiryOfPresentLicense,SignatureOfApplicant,ConsentDate,TimeStamp,Is_Deleted")] ConsentToSellGamingMachines consentToSellGamingMachines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consentToSellGamingMachines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", consentToSellGamingMachines.AMLCompanyProfileId);
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName", consentToSellGamingMachines.GamingEquipmentId);
            return View(consentToSellGamingMachines);
        }

        // GET: AdminConsentToSellGamingMachines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsentToSellGamingMachines consentToSellGamingMachines = db.ConsentToSellGamingMachines.Find(id);
            if (consentToSellGamingMachines == null)
            {
                return HttpNotFound();
            }
            return View(consentToSellGamingMachines);
        }

        // POST: AdminConsentToSellGamingMachines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConsentToSellGamingMachines consentToSellGamingMachines = db.ConsentToSellGamingMachines.Find(id);
            db.ConsentToSellGamingMachines.Remove(consentToSellGamingMachines);
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
