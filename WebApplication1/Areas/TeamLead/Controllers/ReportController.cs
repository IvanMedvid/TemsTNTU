using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.DAL;

namespace WebApplication1.Areas.TeamLead.Controllers
{
    public class ReportController : TeamLeadController
    {
      
        // GET: TeamLead/Report
        public async Task<ActionResult> Index()
        {
            var report = db.report.Include(r => r.artist).Include(r => r.report_card).Include(r => r.stage1);
            return View(await report.ToListAsync());
        }

        // GET: TeamLead/Report/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            report report = await db.report.FindAsync(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: TeamLead/Report/Create
        public ActionResult Create()
        {
            ViewBag.id_artist = new SelectList(db.artist, "id_artist", "PIB");
            ViewBag.id_report = new SelectList(db.report_card, "id_rc", "main_job");
            ViewBag.id_stage = new SelectList(db.stage, "id_stage", "title");
            return View();
        }

        // POST: TeamLead/Report/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_report,id_artist,id_stage,stage")] report report)
        {
            if (ModelState.IsValid)
            {
                db.report.Add(report);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_artist = new SelectList(db.artist, "id_artist", "PIB", report.id_artist);
            ViewBag.id_report = new SelectList(db.report_card, "id_rc", "main_job", report.id_report);
            ViewBag.id_stage = new SelectList(db.stage, "id_stage", "title", report.id_stage);
            return View(report);
        }

        // GET: TeamLead/Report/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            report report = await db.report.FindAsync(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_artist = new SelectList(db.artist, "id_artist", "PIB", report.id_artist);
            ViewBag.id_report = new SelectList(db.report_card, "id_rc", "main_job", report.id_report);
            ViewBag.id_stage = new SelectList(db.stage, "id_stage", "time_begin", report.id_stage);
            return View(report);
        }

        // POST: TeamLead/Report/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_report,id_artist,id_stage,stage")] report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_artist = new SelectList(db.artist, "id_artist", "PIB", report.id_artist);
            ViewBag.id_report = new SelectList(db.report_card, "id_rc", "main_job", report.id_report);
            ViewBag.id_stage = new SelectList(db.stage, "id_stage", "time_begin", report.id_stage);
            return View(report);
        }

        // GET: TeamLead/Report/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            report report = await db.report.FindAsync(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: TeamLead/Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            report report = await db.report.FindAsync(id);
            db.report.Remove(report);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
