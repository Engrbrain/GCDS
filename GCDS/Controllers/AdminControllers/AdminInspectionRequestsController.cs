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
    public class AdminInspectionRequestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminInspectionRequest
        public ActionResult Index()
        {
            var InspectionRequest = db.InspectionRequest.Include(i => i.AMLCompanyProfile).Include(i => i.InspectionTeam).Include(i => i.User);
            return View(InspectionRequest.ToList());
        }

        // GET: AdminInspectionRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionRequest inspectionRequest = db.InspectionRequest.Find(id);
            if (inspectionRequest == null)
            {
                return HttpNotFound();
            }
            return View(inspectionRequest);
        }

        // GET: AdminInspectionRequest/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.InspectionTeamId = new SelectList(db.InspectionTeam, "Id", "TeamName");
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname");
            return View();
        }

        // POST: AdminInspectionRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,AMLCompanyProfileId,InspectionTeamId,InspectionReference,InspectionStartDate,InspectionEndDate,InspectionCategoryId,Justification,IsReviewed,IsApproved,ReviewComment,ApprovalComment,CreatedDate,ReviewedDate,ApprovedDate,ReviewedBy,ApprovedBy,InspectionOfficerID,TimeStamp,Is_Deleted")] InspectionRequest inspectionRequest)
        {
            if (ModelState.IsValid)
            {
                db.InspectionRequest.Add(inspectionRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", inspectionRequest.AMLCompanyProfileId);
            ViewBag.InspectionTeamId = new SelectList(db.InspectionTeam, "Id", "TeamName", inspectionRequest.InspectionTeamId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", inspectionRequest.UserId);
            return View(inspectionRequest);
        }

        // GET: AdminInspectionRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionRequest inspectionRequest = db.InspectionRequest.Find(id);
            if (inspectionRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", inspectionRequest.AMLCompanyProfileId);
            ViewBag.InspectionTeamId = new SelectList(db.InspectionTeam, "Id", "TeamName", inspectionRequest.InspectionTeamId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", inspectionRequest.UserId);
            return View(inspectionRequest);
        }

        // POST: AdminInspectionRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,AMLCompanyProfileId,InspectionTeamId,InspectionReference,InspectionStartDate,InspectionEndDate,InspectionCategoryId,Justification,IsReviewed,IsApproved,ReviewComment,ApprovalComment,CreatedDate,ReviewedDate,ApprovedDate,ReviewedBy,ApprovedBy,InspectionOfficerID,TimeStamp,Is_Deleted")] InspectionRequest inspectionRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", inspectionRequest.AMLCompanyProfileId);
            ViewBag.InspectionTeamId = new SelectList(db.InspectionTeam, "Id", "TeamName", inspectionRequest.InspectionTeamId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstname", inspectionRequest.UserId);
            return View(inspectionRequest);
        }

        // GET: AdminInspectionRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionRequest inspectionRequest = db.InspectionRequest.Find(id);
            if (inspectionRequest == null)
            {
                return HttpNotFound();
            }
            return View(inspectionRequest);
        }

        // POST: AdminInspectionRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InspectionRequest inspectionRequest = db.InspectionRequest.Find(id);
            db.InspectionRequest.Remove(inspectionRequest);
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
