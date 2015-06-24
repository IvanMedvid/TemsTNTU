using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.DAL;

namespace WebApplication1.Areas.TeamLead.Controllers
{
    public class ReportCardController : TeamLeadController
    {
       
        // GET: TeamLead/ReportCard
        public async Task<ActionResult> Index()
        {
            var report_card = db.report_card.Include(r => r.report);
            return View(await report_card.ToListAsync());
        }

        // GET: TeamLead/ReportCard/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            report_card report_card = await db.report_card.FindAsync(id);
            if (report_card == null)
            {
                return HttpNotFound();
            }
            return View(report_card);
        }

        // GET: TeamLead/ReportCard/Create
        public ActionResult Create()
        {
            ViewBag.id_rc = new SelectList(db.report, "id_report", "id_artist");
            return View();
        }

        // POST: TeamLead/ReportCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_rc,id_report,fees,number,main_job")] report_card report_card)
        {
            if (ModelState.IsValid)
            {
                db.report_card.Add(report_card);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_rc = new SelectList(db.report, "id_report", "id_artist", report_card.id_rc);
           
            return View(report_card);
        }

        // GET: TeamLead/ReportCard/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            report_card report_card = await db.report_card.FindAsync(id);
            if (report_card == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_rc = new SelectList(db.report, "id_report", "id_artist", report_card.id_rc);
            return View(report_card);
        }

        // POST: TeamLead/ReportCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_rc,id_report,fees,number,main_job")] report_card report_card)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report_card).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_rc = new SelectList(db.report, "id_report", "id_artist", report_card.id_rc);
            return View(report_card);
        }

        // GET: TeamLead/ReportCard/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            report_card report_card = await db.report_card.FindAsync(id);
            if (report_card == null)
            {
                return HttpNotFound();
            }
            return View(report_card);
        }

        // POST: TeamLead/ReportCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            report_card report_card = await db.report_card.FindAsync(id);
            db.report_card.Remove(report_card);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
    }
}
