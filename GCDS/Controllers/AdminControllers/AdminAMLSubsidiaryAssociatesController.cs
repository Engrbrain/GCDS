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
    public class AdminAMLSubsidiaryAssociatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAMLSubsidiaryAssociates
        public ActionResult Index()
        {
            var aMLSubsidiaryAssociate = db.AMLSubsidiaryAssociate.Include(a => a.AMLCompanyProfile);
            return View(aMLSubsidiaryAssociate.ToList());
        }

        // GET: AdminAMLSubsidiaryAssociates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLSubsidiaryAssociate aMLSubsidiaryAssociate = db.AMLSubsidiaryAssociate.Find(id);
            if (aMLSubsidiaryAssociate == null)
            {
                return HttpNotFound();
            }
            return View(aMLSubsidiaryAssociate);
        }

        // GET: AdminAMLSubsidiaryAssociates/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminAMLSubsidiaryAssociates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,NameOfCompany,RegistrationNumber,PlaceOfIncorporation,NatureOfBusiness,TimeStamp,Is_Deleted,PercentageShareholding")] AMLSubsidiaryAssociate aMLSubsidiaryAssociate)
        {
            if (ModelState.IsValid)
            {
                db.AMLSubsidiaryAssociate.Add(aMLSubsidiaryAssociate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLSubsidiaryAssociate.AMLCompanyProfileId);
            return View(aMLSubsidiaryAssociate);
        }

        // GET: AdminAMLSubsidiaryAssociates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLSubsidiaryAssociate aMLSubsidiaryAssociate = db.AMLSubsidiaryAssociate.Find(id);
            if (aMLSubsidiaryAssociate == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLSubsidiaryAssociate.AMLCompanyProfileId);
            return View(aMLSubsidiaryAssociate);
        }

        // POST: AdminAMLSubsidiaryAssociates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,NameOfCompany,RegistrationNumber,PlaceOfIncorporation,NatureOfBusiness,TimeStamp,Is_Deleted,PercentageShareholding")] AMLSubsidiaryAssociate aMLSubsidiaryAssociate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLSubsidiaryAssociate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLSubsidiaryAssociate.AMLCompanyProfileId);
            return View(aMLSubsidiaryAssociate);
        }

        // GET: AdminAMLSubsidiaryAssociates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLSubsidiaryAssociate aMLSubsidiaryAssociate = db.AMLSubsidiaryAssociate.Find(id);
            if (aMLSubsidiaryAssociate == null)
            {
                return HttpNotFound();
            }
            return View(aMLSubsidiaryAssociate);
        }

        // POST: AdminAMLSubsidiaryAssociates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLSubsidiaryAssociate aMLSubsidiaryAssociate = db.AMLSubsidiaryAssociate.Find(id);
            db.AMLSubsidiaryAssociate.Remove(aMLSubsidiaryAssociate);
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
