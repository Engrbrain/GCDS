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
    public class AdminTicketMessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminTicketMessages
        public ActionResult Index()
        {
            var ticketMessage = db.TicketMessage.Include(t => t.Ticket);
            return View(ticketMessage.ToList());
        }

        // GET: AdminTicketMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketMessage ticketMessage = db.TicketMessage.Find(id);
            if (ticketMessage == null)
            {
                return HttpNotFound();
            }
            return View(ticketMessage);
        }

        // GET: AdminTicketMessages/Create
        public ActionResult Create()
        {
            ViewBag.TicketId = new SelectList(db.Ticket, "Id", "Subject");
            return View();
        }

        // POST: AdminTicketMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TicketId,Message,Response,MessageDate,ResponseDate,ResponseBy,MessageBy,TimeStamp,Is_Deleted")] TicketMessage ticketMessage)
        {
            if (ModelState.IsValid)
            {
                db.TicketMessage.Add(ticketMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketId = new SelectList(db.Ticket, "Id", "Subject", ticketMessage.TicketId);
            return View(ticketMessage);
        }

        // GET: AdminTicketMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketMessage ticketMessage = db.TicketMessage.Find(id);
            if (ticketMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketId = new SelectList(db.Ticket, "Id", "Subject", ticketMessage.TicketId);
            return View(ticketMessage);
        }

        // POST: AdminTicketMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TicketId,Message,Response,MessageDate,ResponseDate,ResponseBy,MessageBy,TimeStamp,Is_Deleted")] TicketMessage ticketMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketId = new SelectList(db.Ticket, "Id", "Subject", ticketMessage.TicketId);
            return View(ticketMessage);
        }

        // GET: AdminTicketMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketMessage ticketMessage = db.TicketMessage.Find(id);
            if (ticketMessage == null)
            {
                return HttpNotFound();
            }
            return View(ticketMessage);
        }

        // POST: AdminTicketMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketMessage ticketMessage = db.TicketMessage.Find(id);
            db.TicketMessage.Remove(ticketMessage);
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
