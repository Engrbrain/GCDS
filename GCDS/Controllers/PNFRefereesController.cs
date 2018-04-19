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
    public class PNFRefereesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PNFReferees
        public ActionResult Index()
        {
            var pNFReferees = db.PNFReferees.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFReferees.ToList());
        }

        // GET: PNFReferees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFReferees pNFReferees = db.PNFReferees.Find(id);
            if (pNFReferees == null)
            {
                return HttpNotFound();
            }
            return View(pNFReferees);
        }

        // GET: PNFReferees/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: PNFReferees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,FullNameOfAssociate,BusinessAddressOfAssociate,PopularSpotCloseToResidenceOfAssociate,ResidentialAddressOfAssociate,Is_Student,HallOfResidenceOfStudentAssociate,CurrentDesignationOfAssociate,FullNameOfCharacterReferee,BusinessAddressOfChararcterReferee,ResidentialAddressOfChararcterReferee,PopularSpotCloseToResidenceOfChararcterReferee,TelephoneNumberOfCharacterReferee,EmailAddressOfCharacterReferee,TimeStamp,Is_Deleted,CurrentDesignationOfCharacterReferee")] PNFReferees pNFReferees)
        {
            if (ModelState.IsValid)
            {
                db.PNFReferees.Add(pNFReferees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFReferees.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFReferees.PNFPersonalDetailsId);
            return View(pNFReferees);
        }

        // GET: PNFReferees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFReferees pNFReferees = db.PNFReferees.Find(id);
            if (pNFReferees == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFReferees.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFReferees.PNFPersonalDetailsId);
            return View(pNFReferees);
        }

        // POST: PNFReferees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,FullNameOfAssociate,BusinessAddressOfAssociate,PopularSpotCloseToResidenceOfAssociate,ResidentialAddressOfAssociate,Is_Student,HallOfResidenceOfStudentAssociate,CurrentDesignationOfAssociate,FullNameOfCharacterReferee,BusinessAddressOfChararcterReferee,ResidentialAddressOfChararcterReferee,PopularSpotCloseToResidenceOfChararcterReferee,TelephoneNumberOfCharacterReferee,EmailAddressOfCharacterReferee,TimeStamp,Is_Deleted,CurrentDesignationOfCharacterReferee")] PNFReferees pNFReferees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFReferees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFReferees.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFReferees.PNFPersonalDetailsId);
            return View(pNFReferees);
        }

        // GET: PNFReferees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFReferees pNFReferees = db.PNFReferees.Find(id);
            if (pNFReferees == null)
            {
                return HttpNotFound();
            }
            return View(pNFReferees);
        }

        // POST: PNFReferees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFReferees pNFReferees = db.PNFReferees.Find(id);
            db.PNFReferees.Remove(pNFReferees);
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
