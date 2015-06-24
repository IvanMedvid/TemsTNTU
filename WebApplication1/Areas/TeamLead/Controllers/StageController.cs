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
    public class StageController : TeamLeadController
    {
        
        // GET: TeamLead/Stage
        public async Task<ActionResult> Index()
        {
            var stage = db.stage.Include(s => s.state_topic);
            return View(await stage.ToListAsync());
        }

        // GET: TeamLead/Stage/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stage stage = await db.stage.FindAsync(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // GET: TeamLead/Stage/Create
        public ActionResult Create()
        {
            ViewBag.id_artist = new SelectList(db.artist, "id_artist", "PIB");
            ViewBag.id_st = new SelectList(db.state_topic, "id_st", "title");
            return View();
        }

        // POST: TeamLead/Stage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_stage,number,time_begin,title,type_end_value,id_st,time_end,id_artist")] stage stage)
        {
            if (ModelState.IsValid)
            {
                db.stage.Add(stage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_artist = new SelectList(db.artist, "id_artist", "PIB", stage.id_artist);
            ViewBag.id_st = new SelectList(db.state_topic, "id_st", "title", stage.id_st);
            return View(stage);
        }

        // GET: TeamLead/Stage/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stage stage = await db.stage.FindAsync(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_stage = new SelectList(db.state_topic, "id_st", "time_begin", stage.id_stage);
            return View(stage);
        }

        // POST: TeamLead/Stage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_stage,number,time_begin,title,type_end_value,id_st,time_end,id_artist")] stage stage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_stage = new SelectList(db.state_topic, "id_st", "time_begin", stage.id_stage);
            return View(stage);
        }

        // GET: TeamLead/Stage/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stage stage = await db.stage.FindAsync(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // POST: TeamLead/Stage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            stage stage = await db.stage.FindAsync(id);
            db.stage.Remove(stage);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
