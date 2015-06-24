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

namespace WebApplication1.Areas.SuperAdmin.Controllers
{
    public class RankController : SuperAdminController
    {
        
        // GET: SuperAdmin/Rank
        public async Task<ActionResult> Index()
        {
            return View(await db.rank.ToListAsync());
        }

        // GET: SuperAdmin/Rank/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rank rank = await db.rank.FindAsync(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            return View(rank);
        }

        // GET: SuperAdmin/Rank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/Rank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_rank,surcharge,title")] rank rank)
        {
            if (ModelState.IsValid)
            {
                db.rank.Add(rank);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rank);
        }

        // GET: SuperAdmin/Rank/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rank rank = await db.rank.FindAsync(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            return View(rank);
        }

        // POST: SuperAdmin/Rank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_rank,surcharge,title")] rank rank)
        {
            if (ModelState.IsValid)
            {
                var model = await db.rank.FindAsync(rank.id_rank);
                TryUpdateModel(model, new string[]
                {
                    "id_rank","title","surcharge"
                });
                db.Entry(model).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rank);
        }

        // GET: SuperAdmin/Rank/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rank rank = await db.rank.FindAsync(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            return View(rank);
        }

        // POST: SuperAdmin/Rank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            rank rank = await db.rank.FindAsync(id);
            db.rank.Remove(rank);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
