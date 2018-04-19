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
    public class AdminAMLCivilActionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminAMLCivilActions
        public ActionResult Index()
        {
            var aMLCivilAction = db.AMLCivilAction.Include(a => a.AMLCompanyProfile);
            return View(aMLCivilAction.ToList());
        }

        // GET: AdminAMLCivilActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCivilAction aMLCivilAction = db.AMLCivilAction.Find(id);
            if (aMLCivilAction == null)
            {
                return HttpNotFound();
            }
            return View(aMLCivilAction);
        }

        // GET: AdminAMLCivilActions/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AdminAMLCivilActions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,CivilActionDescription,CivilActionDate,TimeStamp,Is_Deleted,AmountOwed")] AMLCivilAction aMLCivilAction)
        {
            if (ModelState.IsValid)
            {
                db.AMLCivilAction.Add(aMLCivilAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLCivilAction.AMLCompanyProfileId);
            return View(aMLCivilAction);
        }

        // GET: AdminAMLCivilActions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCivilAction aMLCivilAction = db.AMLCivilAction.Find(id);
            if (aMLCivilAction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLCivilAction.AMLCompanyProfileId);
            return View(aMLCivilAction);
        }

        // POST: AdminAMLCivilActions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,CivilActionDescription,CivilActionDate,TimeStamp,Is_Deleted,AmountOwed")] AMLCivilAction aMLCivilAction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLCivilAction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLCivilAction.AMLCompanyProfileId);
            return View(aMLCivilAction);
        }

        // GET: AdminAMLCivilActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLCivilAction aMLCivilAction = db.AMLCivilAction.Find(id);
            if (aMLCivilAction == null)
            {
                return HttpNotFound();
            }
            return View(aMLCivilAction);
        }

        // POST: AdminAMLCivilActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLCivilAction aMLCivilAction = db.AMLCivilAction.Find(id);
            db.AMLCivilAction.Remove(aMLCivilAction);
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
