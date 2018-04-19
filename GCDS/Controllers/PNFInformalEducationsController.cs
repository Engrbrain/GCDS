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
    public class PNFInformalEducationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PNFInformalEducations
        public ActionResult Index()
        {
            var pNFInformalEducation = db.PNFInformalEducation.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFInformalEducation.ToList());
        }

        // GET: PNFInformalEducations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFInformalEducation pNFInformalEducation = db.PNFInformalEducation.Find(id);
            if (pNFInformalEducation == null)
            {
                return HttpNotFound();
            }
            return View(pNFInformalEducation);
        }

        // GET: PNFInformalEducations/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: PNFInformalEducations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,NameOfTrainingCenter_Place,NameOfTrainer,AddressOfTrainer,SpecialisedSkills_TrainingAcquired,TimeStamp,Is_Deleted,DateAcquired")] PNFInformalEducation pNFInformalEducation)
        {
            if (ModelState.IsValid)
            {
                db.PNFInformalEducation.Add(pNFInformalEducation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFInformalEducation.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFInformalEducation.PNFPersonalDetailsId);
            return View(pNFInformalEducation);
        }

        // GET: PNFInformalEducations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFInformalEducation pNFInformalEducation = db.PNFInformalEducation.Find(id);
            if (pNFInformalEducation == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFInformalEducation.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFInformalEducation.PNFPersonalDetailsId);
            return View(pNFInformalEducation);
        }

        // POST: PNFInformalEducations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,NameOfTrainingCenter_Place,NameOfTrainer,AddressOfTrainer,SpecialisedSkills_TrainingAcquired,TimeStamp,Is_Deleted,DateAcquired")] PNFInformalEducation pNFInformalEducation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFInformalEducation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFInformalEducation.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFInformalEducation.PNFPersonalDetailsId);
            return View(pNFInformalEducation);
        }

        // GET: PNFInformalEducations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFInformalEducation pNFInformalEducation = db.PNFInformalEducation.Find(id);
            if (pNFInformalEducation == null)
            {
                return HttpNotFound();
            }
            return View(pNFInformalEducation);
        }

        // POST: PNFInformalEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFInformalEducation pNFInformalEducation = db.PNFInformalEducation.Find(id);
            db.PNFInformalEducation.Remove(pNFInformalEducation);
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
