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
    public class PNFAttachmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PNFAttachments
        public ActionResult Index()
        {
            var pNFAttachment = db.PNFAttachment.Include(p => p.AMLCompanyProfile).Include(p => p.PNFPersonalDetails);
            return View(pNFAttachment.ToList());
        }

        // GET: PNFAttachments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFAttachment pNFAttachment = db.PNFAttachment.Find(id);
            if (pNFAttachment == null)
            {
                return HttpNotFound();
            }
            return View(pNFAttachment);
        }

        // GET: PNFAttachments/Create
        public ActionResult Create()
        {
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId");
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname");
            return View();
        }

        // POST: PNFAttachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,AttachmentCategory,ReferenceNumber,FilePath,FileName,UploadedDate,TimeStamp,Is_Deleted,DocumentType")] PNFAttachment pNFAttachment)
        {
            if (ModelState.IsValid)
            {
                db.PNFAttachment.Add(pNFAttachment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFAttachment.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFAttachment.PNFPersonalDetailsId);
            return View(pNFAttachment);
        }

        // GET: PNFAttachments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFAttachment pNFAttachment = db.PNFAttachment.Find(id);
            if (pNFAttachment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFAttachment.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFAttachment.PNFPersonalDetailsId);
            return View(pNFAttachment);
        }

        // POST: PNFAttachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileId,PNFPersonalDetailsId,AttachmentCategory,ReferenceNumber,FilePath,FileName,UploadedDate,TimeStamp,Is_Deleted,DocumentType")] PNFAttachment pNFAttachment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pNFAttachment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AMLCompanyProfileId = new SelectList(db.AMLCompanyProfile, "Id", "UserId", pNFAttachment.AMLCompanyProfileId);
            ViewBag.PNFPersonalDetailsId = new SelectList(db.PNFPersonalDetails, "Id", "Surname", pNFAttachment.PNFPersonalDetailsId);
            return View(pNFAttachment);
        }

        // GET: PNFAttachments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PNFAttachment pNFAttachment = db.PNFAttachment.Find(id);
            if (pNFAttachment == null)
            {
                return HttpNotFound();
            }
            return View(pNFAttachment);
        }

        // POST: PNFAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PNFAttachment pNFAttachment = db.PNFAttachment.Find(id);
            db.PNFAttachment.Remove(pNFAttachment);
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
