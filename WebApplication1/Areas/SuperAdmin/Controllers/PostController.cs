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
    public class PostController : SuperAdminController
    {
        // GET: SuperAdmin/Post
        public async Task<ActionResult> Index()
        {
            return View(await db.post.ToListAsync());
        }

        // GET: SuperAdmin/Post/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = await db.post.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: SuperAdmin/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_post,title,salary")] post post)
        {
            if (ModelState.IsValid)
            {
                db.post.Add(post);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: SuperAdmin/Post/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = await db.post.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: SuperAdmin/Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_post,title,salary")] post post)
        {
            if (ModelState.IsValid)
            {
                var model = await db.post.FindAsync(post.id_post);
                TryUpdateModel(model, new string[]
                {
                    "id_post","title","salary"
                });
                db.Entry(model).State = EntityState.Modified;
                
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: SuperAdmin/Post/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = await db.post.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: SuperAdmin/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            post post = await db.post.FindAsync(id);
            db.post.Remove(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
