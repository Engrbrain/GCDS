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
    public class AMLPendingCivilActionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AMLPendingCivilActions
        public ActionResult Index()
        {
            var aMLPendingCivilAction = db.AMLPendingCivilAction.Include(a => a.AMLCompanyProfile);
            return View(aMLPendingCivilAction.ToList());
        }

        // GET: AMLPendingCivilActions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLPendingCivilAction aMLPendingCivilAction = db.AMLPendingCivilAction.Find(id);
            if (aMLPendingCivilAction == null)
            {
                return HttpNotFound();
            }
            return View(aMLPendingCivilAction);
        }

        // GET: AMLPendingCivilActions/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AMLPendingCivilActions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,CivilActionDescription,CivilActionDate,TimeStamp,Is_Deleted,AmountOwed")] AMLPendingCivilAction aMLPendingCivilAction)
        {
            if (ModelState.IsValid)
            {
                db.AMLPendingCivilAction.Add(aMLPendingCivilAction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLPendingCivilAction.AMLCompanyProfileId);
            return View(aMLPendingCivilAction);
        }

        // GET: AMLPendingCivilActions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLPendingCivilAction aMLPendingCivilAction = db.AMLPendingCivilAction.Find(id);
            if (aMLPendingCivilAction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLPendingCivilAction.AMLCompanyProfileId);
            return View(aMLPendingCivilAction);
        }

        // POST: AMLPendingCivilActions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,CivilActionDescription,CivilActionDate,TimeStamp,Is_Deleted,AmountOwed")] AMLPendingCivilAction aMLPendingCivilAction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLPendingCivilAction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLPendingCivilAction.AMLCompanyProfileId);
            return View(aMLPendingCivilAction);
        }

        // GET: AMLPendingCivilActions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLPendingCivilAction aMLPendingCivilAction = db.AMLPendingCivilAction.Find(id);
            if (aMLPendingCivilAction == null)
            {
                return HttpNotFound();
            }
            return View(aMLPendingCivilAction);
        }

        // POST: AMLPendingCivilActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLPendingCivilAction aMLPendingCivilAction = db.AMLPendingCivilAction.Find(id);
            db.AMLPendingCivilAction.Remove(aMLPendingCivilAction);
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
