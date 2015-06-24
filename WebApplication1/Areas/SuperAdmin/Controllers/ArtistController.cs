using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1.Controllers;
using WebApplication1.Models.DAL;

namespace WebApplication1.Areas.SuperAdmin.Controllers
{
    public class ArtistController : SuperAdminController
    {
        

        // GET: SuperAdmin/Artist
        public async Task<ActionResult> Index()
        {
            string userId = User.Identity.GetUserId();
            return RedirectToAction("Details", "Artist", new{id = userId});
        }

        // GET: SuperAdmin/Artist/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = await db.artist.FindAsync(id);
            if (artist == null) 
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: SuperAdmin/Artist/Create
        public ActionResult Create()
        {
            ViewBag.id_degree = new SelectList(db.degree, "id_degree", "title");
            ViewBag.id_post = new SelectList(db.post, "id_post", "title");
            ViewBag.id_rank = new SelectList(db.rank, "id_rank", "title");
            ViewBag.id_st = new SelectList(db.state_topic, "id_st", "time_begin");
            return View();
        }

        // POST: SuperAdmin/Artist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_artist,PIB,id_degree,id_rank,id_post,diploma,date_diploma,certificate,date_certificate,id_st")] artist artist)
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

        // GET: SuperAdmin/Artist/Edit/5
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

        // POST: SuperAdmin/Artist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_artist,PIB,id_degree,id_rank,id_post,diploma,date_diploma,certificate,date_certificate,id_st")] artist artist)
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

        // GET: SuperAdmin/Artist/Delete/5
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

        // POST: SuperAdmin/Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
           artist artist = await db.artist.FindAsync(id);
            var user = await db.AspNetUsers.FindAsync(id);
            db.artist.Remove(artist);
            db.AspNetUsers.Remove(user);
            await db.SaveChangesAsync();
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home", new {area = ""});
        }

    }
}
