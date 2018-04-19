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
    public class AdminAMLCompanyProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAMLCompanyProfile
        public ActionResult Index()
        {
            var AMLCompanyProfile = db.AMLCompanyProfile.Include(a => a.User);
            return View(AMLCompanyProfile.ToList());
        }

        // GET: AdminAMLCompanyProfile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCompanyProfile aMLCompanyProfile = db.AMLCompanyProfile.Find(id);
            if (aMLCompanyProfile == null)
            {
                return HttpNotFound();
            }
            return View(aMLCompanyProfile);
        }

        // GET: AdminAMLCompanyProfile/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname");
            return View();
        }

        // POST: AdminAMLCompanyProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Name,Address,PreviousName,PhysicalAddress,PostalAddress,TelephoneNumber,FacsimileNumber,DateOfIncorporationOfCompany,PlaceOfIncorporationOfCompany,TimeStamp,Is_Deleted,CompanyRegistrationNumber")] AMLCompanyProfile aMLCompanyProfile)
        {
            if (ModelState.IsValid)
            {
                db.AMLCompanyProfile.Add(aMLCompanyProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", aMLCompanyProfile.UserId);
            return View(aMLCompanyProfile);
        }

        // GET: AdminAMLCompanyProfile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCompanyProfile aMLCompanyProfile = db.AMLCompanyProfile.Find(id);
            if (aMLCompanyProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", aMLCompanyProfile.UserId);
            return View(aMLCompanyProfile);
        }

        // POST: AdminAMLCompanyProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Name,Address,PreviousName,PhysicalAddress,PostalAddress,TelephoneNumber,FacsimileNumber,DateOfIncorporationOfCompany,PlaceOfIncorporationOfCompany,TimeStamp,Is_Deleted,CompanyRegistrationNumber")] AMLCompanyProfile aMLCompanyProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLCompanyProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", aMLCompanyProfile.UserId);
            return View(aMLCompanyProfile);
        }

        // GET: AdminAMLCompanyProfile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCompanyProfile aMLCompanyProfile = db.AMLCompanyProfile.Find(id);
            if (aMLCompanyProfile == null)
            {
                return HttpNotFound();
            }
            return View(aMLCompanyProfile);
        }

        // POST: AdminAMLCompanyProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLCompanyProfile aMLCompanyProfile = db.AMLCompanyProfile.Find(id);
            db.AMLCompanyProfile.Remove(aMLCompanyProfile);
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
