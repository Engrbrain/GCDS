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
    public class AMLHoldingCompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AMLHoldingCompanies
        public ActionResult Index()
        {
            var aMLHoldingCompany = db.AMLHoldingCompany.Include(a => a.AMLCompanyProfile);
            return View(aMLHoldingCompany.ToList());
        }

        // GET: AMLHoldingCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLHoldingCompany aMLHoldingCompany = db.AMLHoldingCompany.Find(id);
            if (aMLHoldingCompany == null)
            {
                return HttpNotFound();
            }
            return View(aMLHoldingCompany);
        }

        // GET: AMLHoldingCompanies/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AMLHoldingCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,NameOfCompany,RegistrationNumber,PlaceOfIncorporation,NatureOfBusiness,RelationshipToCompany,TimeStamp,Is_Deleted,PercentageHolding")] AMLHoldingCompany aMLHoldingCompany)
        {
            if (ModelState.IsValid)
            {
                db.AMLHoldingCompany.Add(aMLHoldingCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLHoldingCompany.AMLCompanyProfileId);
            return View(aMLHoldingCompany);
        }

        // GET: AMLHoldingCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLHoldingCompany aMLHoldingCompany = db.AMLHoldingCompany.Find(id);
            if (aMLHoldingCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLHoldingCompany.AMLCompanyProfileId);
            return View(aMLHoldingCompany);
        }

        // POST: AMLHoldingCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,NameOfCompany,RegistrationNumber,PlaceOfIncorporation,NatureOfBusiness,RelationshipToCompany,TimeStamp,Is_Deleted,PercentageHolding")] AMLHoldingCompany aMLHoldingCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLHoldingCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLHoldingCompany.AMLCompanyProfileId);
            return View(aMLHoldingCompany);
        }

        // GET: AMLHoldingCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLHoldingCompany aMLHoldingCompany = db.AMLHoldingCompany.Find(id);
            if (aMLHoldingCompany == null)
            {
                return HttpNotFound();
            }
            return View(aMLHoldingCompany);
        }

        // POST: AMLHoldingCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLHoldingCompany aMLHoldingCompany = db.AMLHoldingCompany.Find(id);
            db.AMLHoldingCompany.Remove(aMLHoldingCompany);
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
