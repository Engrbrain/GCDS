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
    public class AMLCompanyLawyersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AMLCompanyLawyers
        public ActionResult Index()
        {
            var aMLCompanyLawyer = db.AMLCompanyLawyer.Include(a => a.AMLCompanyProfile);
            return View(aMLCompanyLawyer.ToList());
        }

        // GET: AMLCompanyLawyers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCompanyLawyer aMLCompanyLawyer = db.AMLCompanyLawyer.Find(id);
            if (aMLCompanyLawyer == null)
            {
                return HttpNotFound();
            }
            return View(aMLCompanyLawyer);
        }

        // GET: AMLCompanyLawyers/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AMLCompanyLawyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,NameOfLawyerOrLegalAdvisor,AddressOfLawyerOrLegalAdvisor,NameOfAccountant,AddressOfAccountant,NameOfConsultant,AddressOfConsultant,NameOfAuditor,TimeStamp,Is_Deleted,AddressOfAuditor")] AMLCompanyLawyer aMLCompanyLawyer)
        {
            if (ModelState.IsValid)
            {
                db.AMLCompanyLawyer.Add(aMLCompanyLawyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLCompanyLawyer.AMLCompanyProfileId);
            return View(aMLCompanyLawyer);
        }

        // GET: AMLCompanyLawyers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCompanyLawyer aMLCompanyLawyer = db.AMLCompanyLawyer.Find(id);
            if (aMLCompanyLawyer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLCompanyLawyer.AMLCompanyProfileId);
            return View(aMLCompanyLawyer);
        }

        // POST: AMLCompanyLawyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,NameOfLawyerOrLegalAdvisor,AddressOfLawyerOrLegalAdvisor,NameOfAccountant,AddressOfAccountant,NameOfConsultant,AddressOfConsultant,NameOfAuditor,TimeStamp,Is_Deleted,AddressOfAuditor")] AMLCompanyLawyer aMLCompanyLawyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLCompanyLawyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLCompanyLawyer.AMLCompanyProfileId);
            return View(aMLCompanyLawyer);
        }

        // GET: AMLCompanyLawyers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCompanyLawyer aMLCompanyLawyer = db.AMLCompanyLawyer.Find(id);
            if (aMLCompanyLawyer == null)
            {
                return HttpNotFound();
            }
            return View(aMLCompanyLawyer);
        }

        // POST: AMLCompanyLawyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLCompanyLawyer aMLCompanyLawyer = db.AMLCompanyLawyer.Find(id);
            db.AMLCompanyLawyer.Remove(aMLCompanyLawyer);
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
