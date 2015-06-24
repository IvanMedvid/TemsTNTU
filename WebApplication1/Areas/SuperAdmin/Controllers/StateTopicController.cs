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
using Microsoft.AspNet.Identity.Owin;
using WebApplication1.Models.DAL;

namespace WebApplication1.Areas.SuperAdmin.Controllers
{
    public class StateTopicController : SuperAdminController
    {
        
        // GET: SuperAdmin/StateTopic
        public async Task<ActionResult> Index()
        {
            var state_topic = db.state_topic.Include(s => s.artist1);
            return View(await state_topic.ToListAsync());
        }

        // GET: SuperAdmin/StateTopic/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            state_topic state_topic = await db.state_topic.FindAsync(id);
            if (state_topic == null)
            {
                return HttpNotFound();
            }
            return View(state_topic);
        }

        // GET: SuperAdmin/StateTopic/Create
        public ActionResult Create()
        {
            
               
            ViewBag.id_artist = new SelectList(db.artist, "id_artist", "PIB");
            return View();
        }

        // POST: SuperAdmin/StateTopic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_st,budget,time_begin,title,id_artist, time_end")] state_topic state_topic)
        {
            if (ModelState.IsValid)
            {
                db.state_topic.Add(state_topic);
                ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                            .GetUserManager<ApplicationUserManager>();
                string[] roles = { "Admin", "TeamLead", "SuperAdmin" };
                for (int i = 0; i < roles.Length; i++)
                {
                    await userManager.RemoveFromRolesAsync(state_topic.id_artist, roles[i]);
                }
                    
                await userManager.AddToRoleAsync(state_topic.id_artist, "TeamLead");
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            GetNoneSuperAdminUser(state_topic.id_artist);
            ViewBag.id_artist = new SelectList(db.artist, "id_artist", "PIB", state_topic.id_artist);
            return View(state_topic);
        }

        // GET: SuperAdmin/StateTopic/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            state_topic state_topic = await db.state_topic.FindAsync(id);
            if (state_topic == null)
            {
                return HttpNotFound();
            }
            GetNoneSuperAdminUser(state_topic.id_artist);
            return View(state_topic);
        }

        // POST: SuperAdmin/StateTopic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_st,budget,time_begin,title,time_end,id_artist")] state_topic state_topic)
        {
            if (ModelState.IsValid)
            {
                var model = await db.state_topic.FindAsync(state_topic.id_st);
                TryUpdateModel(model, new string[]
                {
                    "id_st","budget","time_begin","title","time_end","id_artist"
                });
                db.Entry(model).State = EntityState.Modified;
                ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                            .GetUserManager<ApplicationUserManager>();
                string[] roles = { "Admin", "TeamLead", "SuperAdmin" };
                for (int i = 0; i < roles.Length; i++)
                {
                    await userManager.RemoveFromRolesAsync(state_topic.id_artist, roles[i]);
                }

                await userManager.AddToRoleAsync(state_topic.id_artist, "TeamLead");
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            GetNoneSuperAdminUser(state_topic.id_artist);
            return View(state_topic);
        }

        public void GetNoneSuperAdminUser(string selected)
        {
            //var superAdmin = db.AspNetRoles.Include(u => u.AspNetUsers)
            //                                .Where(r => r.Name == "SuperAdmin").ToList();


            var superAdminID = db.AspNetUsers.Include(i => i.AspNetRoles)
                                            .Where(x => x.AspNetRoles.Any(r => r.Name == "SuperAdmin"))
                                            .Select(s=>s.Id)
                                            .ToArray();                         
       
            ViewBag.id_artist = new SelectList(db.artist.Where(a => !superAdminID.Contains(a.id_artist)), "id_artist", "PIB", selected);
        }
        // GET: SuperAdmin/StateTopic/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            state_topic state_topic = await db.state_topic.FindAsync(id);
            if (state_topic == null)
            {
                return HttpNotFound();
            }
            return View(state_topic);
        }

        // POST: SuperAdmin/StateTopic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            state_topic state_topic = await db.state_topic.FindAsync(id);
            db.state_topic.Remove(state_topic);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
