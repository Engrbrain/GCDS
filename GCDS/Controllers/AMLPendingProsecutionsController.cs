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
    public class AMLPendingProsecutionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AMLPendingProsecutions
        public ActionResult Index()
        {
            var aMLPendingProsecution = db.AMLPendingProsecution.Include(a => a.AMLCompanyProfile);
            return View(aMLPendingProsecution.ToList());
        }

        // GET: AMLPendingProsecutions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLPendingProsecution aMLPendingProsecution = db.AMLPendingProsecution.Find(id);
            if (aMLPendingProsecution == null)
            {
                return HttpNotFound();
            }
            return View(aMLPendingProsecution);
        }

        // GET: AMLPendingProsecutions/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: AMLPendingProsecutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,NameOfAccused,DesignationOfAccused,ProsecutionDescription,TimeStamp,Is_Deleted,NameOfProsecutor")] AMLPendingProsecution aMLPendingProsecution)
        {
            if (ModelState.IsValid)
            {
                db.AMLPendingProsecution.Add(aMLPendingProsecution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLPendingProsecution.AMLCompanyProfileId);
            return View(aMLPendingProsecution);
        }

        // GET: AMLPendingProsecutions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLPendingProsecution aMLPendingProsecution = db.AMLPendingProsecution.Find(id);
            if (aMLPendingProsecution == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLPendingProsecution.AMLCompanyProfileId);
            return View(aMLPendingProsecution);
        }

        // POST: AMLPendingProsecutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,NameOfAccused,DesignationOfAccused,ProsecutionDescription,TimeStamp,Is_Deleted,NameOfProsecutor")] AMLPendingProsecution aMLPendingProsecution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLPendingProsecution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", aMLPendingProsecution.AMLCompanyProfileId);
            return View(aMLPendingProsecution);
        }

        // GET: AMLPendingProsecutions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLPendingProsecution aMLPendingProsecution = db.AMLPendingProsecution.Find(id);
            if (aMLPendingProsecution == null)
            {
                return HttpNotFound();
            }
            return View(aMLPendingProsecution);
        }

        // POST: AMLPendingProsecutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLPendingProsecution aMLPendingProsecution = db.AMLPendingProsecution.Find(id);
            db.AMLPendingProsecution.Remove(aMLPendingProsecution);
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
