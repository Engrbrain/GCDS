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
    public class AdminAMLAgreementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAMLAgreement
        public ActionResult Index()
        {
            var AMLAgreement = db.AMLAgreement.Include(a => a.AMLCompanyProfile).Include(a => a.User);
            return View(AMLAgreement.ToList());
        }

        // GET: AdminAMLAgreement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLAgreement aMLAgreement = db.AMLAgreement.Find(id);
            if (aMLAgreement == null)
            {
                return HttpNotFound();
            }
            return View(aMLAgreement);
        }

        // GET: AdminAMLAgreement/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname");
            return View();
        }

        // POST: AdminAMLAgreement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,AMLCompanyProfileID,OwnershipDescription,OperationDescription,DevelopmentDescription,FacilitationDescription,TimeStamp,Is_Deleted,RightOrInterestDescription")] AMLAgreement aMLAgreement)
        {
            if (ModelState.IsValid)
            {
                db.AMLAgreement.Add(aMLAgreement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLAgreement.AMLCompanyProfileID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", aMLAgreement.UserId);
            return View(aMLAgreement);
        }

        // GET: AdminAMLAgreement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLAgreement aMLAgreement = db.AMLAgreement.Find(id);
            if (aMLAgreement == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLAgreement.AMLCompanyProfileID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", aMLAgreement.UserId);
            return View(aMLAgreement);
        }

        // POST: AdminAMLAgreement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,AMLCompanyProfileID,OwnershipDescription,OperationDescription,DevelopmentDescription,FacilitationDescription,TimeStamp,Is_Deleted,RightOrInterestDescription")] AMLAgreement aMLAgreement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLAgreement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileID = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLAgreement.AMLCompanyProfileID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", aMLAgreement.UserId);
            return View(aMLAgreement);
        }

        // GET: AdminAMLAgreement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLAgreement aMLAgreement = db.AMLAgreement.Find(id);
            if (aMLAgreement == null)
            {
                return HttpNotFound();
            }
            return View(aMLAgreement);
        }

        // POST: AdminAMLAgreement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLAgreement aMLAgreement = db.AMLAgreement.Find(id);
            db.AMLAgreement.Remove(aMLAgreement);
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
