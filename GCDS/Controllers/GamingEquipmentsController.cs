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
    public class GamingEquipmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GamingEquipments
        public ActionResult Index()
        {
            var gamingEquipment = db.GamingEquipment.Include(g => g.AMLCompanyProfile);
            return View(gamingEquipment.ToList());
        }

        // GET: GamingEquipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamingEquipment gamingEquipment = db.GamingEquipment.Find(id);
            if (gamingEquipment == null)
            {
                return HttpNotFound();
            }
            return View(gamingEquipment);
        }

        // GET: GamingEquipments/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: GamingEquipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MachineReference,DateOfAquisition,EquipmentName,EquipmentSerialNumber,PurposeOfEquipment,EquipmentManfacturer,EquipmentModel,EquipmentLocation,Region,CurrentStatus,AMLCompanyProfileId")] GamingEquipment gamingEquipment)
        {
            if (ModelState.IsValid)
            {
                db.GamingEquipment.Add(gamingEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", gamingEquipment.AMLCompanyProfileId);
            return View(gamingEquipment);
        }

        // GET: GamingEquipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamingEquipment gamingEquipment = db.GamingEquipment.Find(id);
            if (gamingEquipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", gamingEquipment.AMLCompanyProfileId);
            return View(gamingEquipment);
        }

        // POST: GamingEquipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MachineReference,DateOfAquisition,EquipmentName,EquipmentSerialNumber,PurposeOfEquipment,EquipmentManfacturer,EquipmentModel,EquipmentLocation,Region,CurrentStatus,AMLCompanyProfileId")] GamingEquipment gamingEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamingEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", gamingEquipment.AMLCompanyProfileId);
            return View(gamingEquipment);
        }

        // GET: GamingEquipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamingEquipment gamingEquipment = db.GamingEquipment.Find(id);
            if (gamingEquipment == null)
            {
                return HttpNotFound();
            }
            return View(gamingEquipment);
        }

        // POST: GamingEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GamingEquipment gamingEquipment = db.GamingEquipment.Find(id);
            db.GamingEquipment.Remove(gamingEquipment);
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
