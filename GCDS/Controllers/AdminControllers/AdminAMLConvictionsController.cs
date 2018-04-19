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
    public class AdminAMLConvictionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAMLConvictions
        public ActionResult Index()
        {
            var aMLConviction = db.AMLConviction.Include(a => a.AMLCompanyProfile);
            return View(aMLConviction.ToList());
        }

        // GET: AdminAMLConvictions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLConviction aMLConviction = db.AMLConviction.Find(id);
            if (aMLConviction == null)
            {
                return HttpNotFound();
            }
            return View(aMLConviction);
        }

        // GET: AdminAMLConvictions/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminAMLConvictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,NameOfConvictor,DesignationOfConvictor,CourtConvicted,DateOfConviction,OffenceDescription,TimeStamp,Is_Deleted,PenaltyDescription")] AMLConviction aMLConviction)
        {
            if (ModelState.IsValid)
            {
                db.AMLConviction.Add(aMLConviction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLConviction.AMLCompanyProfileId);
            return View(aMLConviction);
        }

        // GET: AdminAMLConvictions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLConviction aMLConviction = db.AMLConviction.Find(id);
            if (aMLConviction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLConviction.AMLCompanyProfileId);
            return View(aMLConviction);
        }

        // POST: AdminAMLConvictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,NameOfConvictor,DesignationOfConvictor,CourtConvicted,DateOfConviction,OffenceDescription,TimeStamp,Is_Deleted,PenaltyDescription")] AMLConviction aMLConviction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLConviction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLConviction.AMLCompanyProfileId);
            return View(aMLConviction);
        }

        // GET: AdminAMLConvictions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLConviction aMLConviction = db.AMLConviction.Find(id);
            if (aMLConviction == null)
            {
                return HttpNotFound();
            }
            return View(aMLConviction);
        }

        // POST: AdminAMLConvictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLConviction aMLConviction = db.AMLConviction.Find(id);
            db.AMLConviction.Remove(aMLConviction);
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
