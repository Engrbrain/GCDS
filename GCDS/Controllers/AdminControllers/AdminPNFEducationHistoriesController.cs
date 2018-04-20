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
    public class AdminPNFEducationHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminPNFEducationHistories
        public ActionResult Index()
        {
            var pNFEducationHistory = db.PNFEducationHistory.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFEducationHistory.ToList());
        }

        // GET: AdminPNFEducationHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFEducationHistory pNFEducationHistory = db.PNFEducationHistory.Find(id);
            if (pNFEducationHistory == null)
            {
                return HttpNotFound();
            }
            return View(pNFEducationHistory);
        }

        // GET: AdminPNFEducationHistories/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: AdminPNFEducationHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,AMLCompanyProfileId,PNFPersonalDetailsId,NameOfSeniorSecondarySchool,AddressOfSeniorSecondarySchool,DateBeganSeniorSecondarySchool,DateCompletedSeniorSecondarySchool,QualificationAchievedFromSeniorSecondarySchool,GradesAchievedFromSeniorSecondarySchool,NameOfCollege,AddressOfCollege,DateBeganCollege,DateCompletedCollege,QualificationAchievedFromCollege,GradesAchievedFromCollege,NameOfHigher_Prof_VocInstitution,Is_FullTimeStudy,Is_PartTimeStudy,AddressOfHigher_Prof_VocInstitution,DateAttendedHigher_Prof_VocInstitution,SubjectsStudiedAtHigher_Prof_VocInstitution,DegreeTitleFromHigher_Prof_VocInstitution,GradesAchievedFromHigher_Prof_VocInstitution,TimeStamp,Is_Deleted,QualificationAchievedFromHigher_Prof_VocInstitution")] PNFEducationHistory pNFEducationHistory)
        {
            if (ModelState.IsValid)
            {
                db.PNFEducationHistory.Add(pNFEducationHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFEducationHistory.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFEducationHistory.PNFPersonalDetailsId);
            return View(pNFEducationHistory);
        }

        // GET: AdminPNFEducationHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFEducationHistory pNFEducationHistory = db.PNFEducationHistory.Find(id);
            if (pNFEducationHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFEducationHistory.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFEducationHistory.PNFPersonalDetailsId);
            return View(pNFEducationHistory);
        }

        // POST: AdminPNFEducationHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,AMLCompanyProfileId,PNFPersonalDetailsId,NameOfSeniorSecondarySchool,AddressOfSeniorSecondarySchool,DateBeganSeniorSecondarySchool,DateCompletedSeniorSecondarySchool,QualificationAchievedFromSeniorSecondarySchool,GradesAchievedFromSeniorSecondarySchool,NameOfCollege,AddressOfCollege,DateBeganCollege,DateCompletedCollege,QualificationAchievedFromCollege,GradesAchievedFromCollege,NameOfHigher_Prof_VocInstitution,Is_FullTimeStudy,Is_PartTimeStudy,AddressOfHigher_Prof_VocInstitution,DateAttendedHigher_Prof_VocInstitution,SubjectsStudiedAtHigher_Prof_VocInstitution,DegreeTitleFromHigher_Prof_VocInstitution,GradesAchievedFromHigher_Prof_VocInstitution,TimeStamp,Is_Deleted,QualificationAchievedFromHigher_Prof_VocInstitution")] PNFEducationHistory pNFEducationHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFEducationHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFEducationHistory.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFEducationHistory.PNFPersonalDetailsId);
            return View(pNFEducationHistory);
        }

        // GET: AdminPNFEducationHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFEducationHistory pNFEducationHistory = db.PNFEducationHistory.Find(id);
            if (pNFEducationHistory == null)
            {
                return HttpNotFound();
            }
            return View(pNFEducationHistory);
        }

        // POST: AdminPNFEducationHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFEducationHistory pNFEducationHistory = db.PNFEducationHistory.Find(id);
            db.PNFEducationHistory.Remove(pNFEducationHistory);
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
