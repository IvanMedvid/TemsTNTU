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
    public class DegreeController : SuperAdminController
    {
        
        // GET: SuperAdmin/Degree
        public async Task<ActionResult> Index()
        {
            return View(await db.degree.ToListAsync());
        }

        // GET: SuperAdmin/Degree/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            degree degree = await db.degree.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // GET: SuperAdmin/Degree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/Degree/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_degree,title,surcharge")] degree degree)
        {
            if (ModelState.IsValid)
            {
                db.degree.Add(degree);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(degree);
        }

        // GET: SuperAdmin/Degree/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            degree degree = await db.degree.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: SuperAdmin/Degree/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_degree,title,surcharge")] degree degree)
        {
            if (ModelState.IsValid)
            {
                var model = await db.degree.FindAsync(degree.id_degree);
                TryUpdateModel(model, new string[]
                {
                    "id_degree","title","surcharge"
                });
                db.Entry(model).State = EntityState.Modified;
                
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(degree);
        }

        // GET: SuperAdmin/Degree/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            degree degree = await db.degree.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: SuperAdmin/Degree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            degree degree = await db.degree.FindAsync(id);
            db.degree.Remove(degree);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
