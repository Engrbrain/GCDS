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
    public class AdminPNFExamsTakensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminPNFExamsTakens
        public ActionResult Index()
        {
            var pNFExamsTaken = db.PNFExamsTaken.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFExamsTaken.ToList());
        }

        // GET: AdminPNFExamsTakens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFExamsTaken pNFExamsTaken = db.PNFExamsTaken.Find(id);
            if (pNFExamsTaken == null)
            {
                return HttpNotFound();
            }
            return View(pNFExamsTaken);
        }

        // GET: AdminPNFExamsTakens/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: AdminPNFExamsTakens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,NameOfExam,NameOfExaminingAuthority_Board,ExamTitle,IndexNumber,ResultOfExam,PlaceOFExam,TimeStamp,Is_Deleted,DateOfExam")] PNFExamsTaken pNFExamsTaken)
        {
            if (ModelState.IsValid)
            {
                db.PNFExamsTaken.Add(pNFExamsTaken);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFExamsTaken.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFExamsTaken.PNFPersonalDetailsId);
            return View(pNFExamsTaken);
        }

        // GET: AdminPNFExamsTakens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFExamsTaken pNFExamsTaken = db.PNFExamsTaken.Find(id);
            if (pNFExamsTaken == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFExamsTaken.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFExamsTaken.PNFPersonalDetailsId);
            return View(pNFExamsTaken);
        }

        // POST: AdminPNFExamsTakens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,NameOfExam,NameOfExaminingAuthority_Board,ExamTitle,IndexNumber,ResultOfExam,PlaceOFExam,TimeStamp,Is_Deleted,DateOfExam")] PNFExamsTaken pNFExamsTaken)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFExamsTaken).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFExamsTaken.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFExamsTaken.PNFPersonalDetailsId);
            return View(pNFExamsTaken);
        }

        // GET: AdminPNFExamsTakens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFExamsTaken pNFExamsTaken = db.PNFExamsTaken.Find(id);
            if (pNFExamsTaken == null)
            {
                return HttpNotFound();
            }
            return View(pNFExamsTaken);
        }

        // POST: AdminPNFExamsTakens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFExamsTaken pNFExamsTaken = db.PNFExamsTaken.Find(id);
            db.PNFExamsTaken.Remove(pNFExamsTaken);
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
