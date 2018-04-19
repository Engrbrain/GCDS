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
    public class AdminImportGamingMachinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminImportGamingMachines
        public ActionResult Index()
        {
            var importGamingMachine = db.ImportGamingMachine.Include(i => i.AMLCompanyProfile).Include(i => i.GamingEquipment);
            return View(importGamingMachine.ToList());
        }

        // GET: AdminImportGamingMachines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportGamingMachine importGamingMachine = db.ImportGamingMachine.Find(id);
            if (importGamingMachine == null)
            {
                return HttpNotFound();
            }
            return View(importGamingMachine);
        }

        // GET: AdminImportGamingMachines/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName");
            return View();
        }

        // POST: AdminImportGamingMachines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GamingEquipmentId,AMLCompanyProfileId,FullNameOfApplicant,Address,Nationality,MakeOfMachine,SerialNumber,CountryOfOrigin,CostOfMachine,Is_MachineImportForResale,NameOfProposedPremisesForMachine,ProposedTown_CityForMachine,NameOfPresentPremisesForMAchine,PresentTown_CityForMachine,NumberOfPresentGamblingMachinesLicense,Is_TrueOwnerOfMachine,DateOfExpiryOfPresentLicense,Signature,ImportationDate,TimeStamp,Is_Deleted")] ImportGamingMachine importGamingMachine)
        {
            if (ModelState.IsValid)
            {
                db.ImportGamingMachine.Add(importGamingMachine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", importGamingMachine.AMLCompanyProfileId);
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName", importGamingMachine.GamingEquipmentId);
            return View(importGamingMachine);
        }

        // GET: AdminImportGamingMachines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportGamingMachine importGamingMachine = db.ImportGamingMachine.Find(id);
            if (importGamingMachine == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", importGamingMachine.AMLCompanyProfileId);
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName", importGamingMachine.GamingEquipmentId);
            return View(importGamingMachine);
        }

        // POST: AdminImportGamingMachines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GamingEquipmentId,AMLCompanyProfileId,FullNameOfApplicant,Address,Nationality,MakeOfMachine,SerialNumber,CountryOfOrigin,CostOfMachine,Is_MachineImportForResale,NameOfProposedPremisesForMachine,ProposedTown_CityForMachine,NameOfPresentPremisesForMAchine,PresentTown_CityForMachine,NumberOfPresentGamblingMachinesLicense,Is_TrueOwnerOfMachine,DateOfExpiryOfPresentLicense,Signature,ImportationDate,TimeStamp,Is_Deleted")] ImportGamingMachine importGamingMachine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(importGamingMachine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", importGamingMachine.AMLCompanyProfileId);
            ViewBag.GamingEquipmentId = new SelectList(db.GamingEquipment, "Id", "EquipmentName", importGamingMachine.GamingEquipmentId);
            return View(importGamingMachine);
        }

        // GET: AdminImportGamingMachines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImportGamingMachine importGamingMachine = db.ImportGamingMachine.Find(id);
            if (importGamingMachine == null)
            {
                return HttpNotFound();
            }
            return View(importGamingMachine);
        }

        // POST: AdminImportGamingMachines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImportGamingMachine importGamingMachine = db.ImportGamingMachine.Find(id);
            db.ImportGamingMachine.Remove(importGamingMachine);
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
