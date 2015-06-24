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
    public class ArtistController : TeamLeadController
    {
      

        // GET: TeamLead/Artist
       
        public async Task<ActionResult> Index()
        {
            
            var artist = db.artist.Include(a => a.degree).Include(a => a.post).Include(a => a.rank).Include(a => a.state_topic);
            return View(await artist.ToListAsync());
        }
         [WordDocument]
        public ActionResult IndexDocument()
        {
            var artist = db.artist.Include(a => a.degree)
                                  .Include(a => a.post)
                                  .Include(a => a.rank)
                                  .Include(a => a.state_topic)
                                  .ToList();
            ViewBag.WordDocumentFilename = "AboutMeDocument";

            return View("Index", artist);
        }
       // GET: TeamLead/Artist/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            artist artist = await db.artist.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: TeamLead/Artist/Create
        public ActionResult Create()
        {
            ViewBag.id_degree = new SelectList(db.degree, "id_degree", "title");
            ViewBag.id_post = new SelectList(db.post, "id_post", "title");
            ViewBag.id_rank = new SelectList(db.rank, "id_rank", "title");
            ViewBag.id_st = new SelectList(db.state_topic, "id_st", "time_begin");
            return View();
        }

        // POST: TeamLead/Artist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_artist,PIB,id_degree,id_rank,id_post,diploma,date_diploma,certificate,date_certificate,id_st,id_stage")] artist artist)
        {
            if (ModelState.IsValid)
            {
                db.artist.Add(artist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_degree = new SelectList(db.degree, "id_degree", "title", artist.id_degree);
            ViewBag.id_post = new SelectList(db.post, "id_post", "title", artist.id_post);
            ViewBag.id_rank = new SelectList(db.rank, "id_rank", "title", artist.id_rank);
            ViewBag.id_st = new SelectList(db.state_topic, "id_st", "time_begin", artist.id_st);
            return View(artist);
        }

        // GET: TeamLead/Artist/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            artist artist = await db.artist.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_degree = new SelectList(db.degree, "id_degree", "title", artist.id_degree);
            ViewBag.id_post = new SelectList(db.post, "id_post", "title", artist.id_post);
            ViewBag.id_rank = new SelectList(db.rank, "id_rank", "title", artist.id_rank);
            ViewBag.id_st = new SelectList(db.state_topic, "id_st", "time_begin", artist.id_st);
            return View(artist);
        }

        // POST: TeamLead/Artist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_artist,PIB,id_degree,id_rank,id_post,diploma,date_diploma,certificate,date_certificate,id_st,id_stage")] artist artist)
        {
            if (ModelState.IsValid)
            {
                var model = await db.artist.FindAsync(artist.id_artist);
                TryUpdateModel(model, new string[]
                {
                    "PIB", "id_degree", "id_rank", "id_post", "diploma", "date_diploma", "certificate",
                    "date_certificate", "id_st"
                });
                db.Entry(model).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_degree = new SelectList(db.degree, "id_degree", "title", artist.id_degree);
            ViewBag.id_post = new SelectList(db.post, "id_post", "title", artist.id_post);
            ViewBag.id_rank = new SelectList(db.rank, "id_rank", "title", artist.id_rank);
            ViewBag.id_st = new SelectList(db.state_topic, "id_st", "time_begin", artist.id_st);
            return View(artist);
        }

        // GET: TeamLead/Artist/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            artist artist = await db.artist.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: TeamLead/Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            artist artist = await db.artist.FindAsync(id);
            db.artist.Remove(artist);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
