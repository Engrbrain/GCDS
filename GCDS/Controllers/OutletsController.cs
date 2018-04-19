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
    public class OutletsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Outlets
        public ActionResult Index()
        {
            var outlet = db.Outlet.Include(o => o.AMLCompanyProfile);
            return View(outlet.ToList());
        }

        // GET: Outlets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outlet outlet = db.Outlet.Find(id);
            if (outlet == null)
            {
                return HttpNotFound();
            }
            return View(outlet);
        }

        // GET: Outlets/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            return View();
        }

        // POST: Outlets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,OutletTitle,HouseNumber,StreetName,City,Region,Telephone,ContactPerson,ContactPersonPhone,ContactPersonEmail,NumberOfMachines,OutletReference,Is_Approved,ApprovalComment,Is_Active")] Outlet outlet)
        {
            if (ModelState.IsValid)
            {
                db.Outlet.Add(outlet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", outlet.AMLCompanyProfileId);
            return View(outlet);
        }

        // GET: Outlets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outlet outlet = db.Outlet.Find(id);
            if (outlet == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", outlet.AMLCompanyProfileId);
            return View(outlet);
        }

        // POST: Outlets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,OutletTitle,HouseNumber,StreetName,City,Region,Telephone,ContactPerson,ContactPersonPhone,ContactPersonEmail,NumberOfMachines,OutletReference,Is_Approved,ApprovalComment,Is_Active")] Outlet outlet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outlet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", outlet.AMLCompanyProfileId);
            return View(outlet);
        }

        // GET: Outlets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outlet outlet = db.Outlet.Find(id);
            if (outlet == null)
            {
                return HttpNotFound();
            }
            return View(outlet);
        }

        // POST: Outlets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outlet outlet = db.Outlet.Find(id);
            db.Outlet.Remove(outlet);
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
