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
    public class AdminAMLCertificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAMLCertifications
        public ActionResult Index()
        {
            var aMLCertification = db.AMLCertification.Include(a => a.AMLCompanyProfile);
            return View(aMLCertification.ToList());
        }

        // GET: AdminAMLCertifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCertification aMLCertification = db.AMLCertification.Find(id);
            if (aMLCertification == null)
            {
                return HttpNotFound();
            }
            return View(aMLCertification);
        }

        // GET: AdminAMLCertifications/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminAMLCertifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,CertificateName,Signature,CertificationDate,NameOfApplicant,PositionToBeHeld,TimeStamp,Is_Deleted")] AMLCertification aMLCertification)
        {
            if (ModelState.IsValid)
            {
                db.AMLCertification.Add(aMLCertification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLCertification.AMLCompanyProfileId);
            return View(aMLCertification);
        }

        // GET: AdminAMLCertifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCertification aMLCertification = db.AMLCertification.Find(id);
            if (aMLCertification == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLCertification.AMLCompanyProfileId);
            return View(aMLCertification);
        }

        // POST: AdminAMLCertifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,CertificateName,Signature,CertificationDate,NameOfApplicant,PositionToBeHeld,TimeStamp,Is_Deleted")] AMLCertification aMLCertification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLCertification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLCertification.AMLCompanyProfileId);
            return View(aMLCertification);
        }

        // GET: AdminAMLCertifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCertification aMLCertification = db.AMLCertification.Find(id);
            if (aMLCertification == null)
            {
                return HttpNotFound();
            }
            return View(aMLCertification);
        }

        // POST: AdminAMLCertifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLCertification aMLCertification = db.AMLCertification.Find(id);
            db.AMLCertification.Remove(aMLCertification);
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
