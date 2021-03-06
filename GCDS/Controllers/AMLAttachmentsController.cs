﻿using System;
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
    public class AMLAttachmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AMLAttachments
        public ActionResult Index()
        {
            return View(db.AMLAttachments.ToList());
        }

        // GET: AMLAttachments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLAttachments aMLAttachments = db.AMLAttachments.Find(id);
            if (aMLAttachments == null)
            {
                return HttpNotFound();
            }
            return View(aMLAttachments);
        }

        // GET: AMLAttachments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AMLAttachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AMLCompanyProfileID,UserID,AttachmentCategory,ReferenceNumber,FilePath,FileName,UploadedDate,TimeStamp,Is_Deleted,DocumentType")] AMLAttachments aMLAttachments)
        {
            if (ModelState.IsValid)
            {
                db.AMLAttachments.Add(aMLAttachments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aMLAttachments);
        }

        // GET: AMLAttachments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLAttachments aMLAttachments = db.AMLAttachments.Find(id);
            if (aMLAttachments == null)
            {
                return HttpNotFound();
            }
            return View(aMLAttachments);
        }

        // POST: AMLAttachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AMLCompanyProfileID,UserID,AttachmentCategory,ReferenceNumber,FilePath,FileName,UploadedDate,TimeStamp,Is_Deleted,DocumentType")] AMLAttachments aMLAttachments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aMLAttachments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aMLAttachments);
        }

        // GET: AMLAttachments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AMLAttachments aMLAttachments = db.AMLAttachments.Find(id);
            if (aMLAttachments == null)
            {
                return HttpNotFound();
            }
            return View(aMLAttachments);
        }

        // POST: AMLAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AMLAttachments aMLAttachments = db.AMLAttachments.Find(id);
            db.AMLAttachments.Remove(aMLAttachments);
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
