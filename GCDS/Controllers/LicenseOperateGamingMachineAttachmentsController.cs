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
    public class LicenseOperateGamingMachineAttachmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ImportGamingMachineAttachments
        public ActionResult Index()
        {
            return View(db.ImportGamingMachineAttachments.ToList());
        }

        // GET: ImportGamingMachineAttachments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseOperateGamingMachineAttachment importGamingMachineAttachment = db.ImportGamingMachineAttachments.Find(id);
            if (importGamingMachineAttachment == null)
            {
                return HttpNotFound();
            }
            return View(importGamingMachineAttachment);
        }

        // GET: ImportGamingMachineAttachments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImportGamingMachineAttachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileID,UserID,AttachmentCategory,ReferenceNumber,FilePath,FileName,UploadedDate,TimeStamp,Is_Deleted,DocumentType")] LicenseOperateGamingMachineAttachment importGamingMachineAttachment)
        {
            if (ModelState.IsValid)
            {
                db.ImportGamingMachineAttachments.Add(importGamingMachineAttachment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(importGamingMachineAttachment);
        }

        // GET: ImportGamingMachineAttachments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseOperateGamingMachineAttachment importGamingMachineAttachment = db.ImportGamingMachineAttachments.Find(id);
            if (importGamingMachineAttachment == null)
            {
                return HttpNotFound();
            }
            return View(importGamingMachineAttachment);
        }

        // POST: ImportGamingMachineAttachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileID,UserID,AttachmentCategory,ReferenceNumber,FilePath,FileName,UploadedDate,TimeStamp,Is_Deleted,DocumentType")] LicenseOperateGamingMachineAttachment importGamingMachineAttachment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(importGamingMachineAttachment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(importGamingMachineAttachment);
        }

        // GET: ImportGamingMachineAttachments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseOperateGamingMachineAttachment importGamingMachineAttachment = db.ImportGamingMachineAttachments.Find(id);
            if (importGamingMachineAttachment == null)
            {
                return HttpNotFound();
            }
            return View(importGamingMachineAttachment);
        }

        // POST: ImportGamingMachineAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LicenseOperateGamingMachineAttachment importGamingMachineAttachment = db.ImportGamingMachineAttachments.Find(id);
            db.ImportGamingMachineAttachments.Remove(importGamingMachineAttachment);
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
