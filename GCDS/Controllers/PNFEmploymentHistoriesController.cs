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
    public class PNFEmploymentHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PNFEmploymentHistories
        public ActionResult Index()
        {
            var pNFEmploymentHistory = db.PNFEmploymentHistory.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFEmploymentHistory.ToList());
        }

        // GET: PNFEmploymentHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFEmploymentHistory pNFEmploymentHistory = db.PNFEmploymentHistory.Find(id);
            if (pNFEmploymentHistory == null)
            {
                return HttpNotFound();
            }
            return View(pNFEmploymentHistory);
        }

        // GET: PNFEmploymentHistories/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: PNFEmploymentHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,OrganisationFullName,Is_Apprenticeship,Is_SelfEmployment,Is_UnEmployment,Is_NationalService,AddressOFOrganisation,TelephoneNumberOfOrganisation,EmploymentStartDate,EmploymentEndDate,Post,DutiesDescription,Is_SecurityService_Employee,BranchOfService_Unit,Rank_Position,ServiceNumber,DateOfEnlistment,PlaceOfEnlistment,DateOfLeaving,TimeStamp,Is_Deleted,ReasonsForLeaving")] PNFEmploymentHistory pNFEmploymentHistory)
        {
            if (ModelState.IsValid)
            {
                db.PNFEmploymentHistory.Add(pNFEmploymentHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFEmploymentHistory.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFEmploymentHistory.PNFPersonalDetailsId);
            return View(pNFEmploymentHistory);
        }

        // GET: PNFEmploymentHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFEmploymentHistory pNFEmploymentHistory = db.PNFEmploymentHistory.Find(id);
            if (pNFEmploymentHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFEmploymentHistory.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFEmploymentHistory.PNFPersonalDetailsId);
            return View(pNFEmploymentHistory);
        }

        // POST: PNFEmploymentHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,OrganisationFullName,Is_Apprenticeship,Is_SelfEmployment,Is_UnEmployment,Is_NationalService,AddressOFOrganisation,TelephoneNumberOfOrganisation,EmploymentStartDate,EmploymentEndDate,Post,DutiesDescription,Is_SecurityService_Employee,BranchOfService_Unit,Rank_Position,ServiceNumber,DateOfEnlistment,PlaceOfEnlistment,DateOfLeaving,TimeStamp,Is_Deleted,ReasonsForLeaving")] PNFEmploymentHistory pNFEmploymentHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFEmploymentHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFEmploymentHistory.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFEmploymentHistory.PNFPersonalDetailsId);
            return View(pNFEmploymentHistory);
        }

        // GET: PNFEmploymentHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFEmploymentHistory pNFEmploymentHistory = db.PNFEmploymentHistory.Find(id);
            if (pNFEmploymentHistory == null)
            {
                return HttpNotFound();
            }
            return View(pNFEmploymentHistory);
        }

        // POST: PNFEmploymentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFEmploymentHistory pNFEmploymentHistory = db.PNFEmploymentHistory.Find(id);
            db.PNFEmploymentHistory.Remove(pNFEmploymentHistory);
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
