using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyDemo.Models;

namespace MyDemo.Controllers
{
    public class HushHushController : Controller
    {
        private FortKnoxContext db = new FortKnoxContext();

        // GET: /HushHush/
        public async Task<ActionResult> Index()
        {
            return View(await db.FortKnoxes.ToListAsync());
        }

        // GET: /HushHush/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FortKnox fortknox = await db.FortKnoxes.FindAsync(id);
            if (fortknox == null)
            {
                return HttpNotFound();
            }
            return View(fortknox);
        }

        // GET: /HushHush/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /HushHush/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,TopSecret,OtherDataWeDontCareAbout")] FortKnox fortknox)
        {
            if (ModelState.IsValid)
            {
                db.FortKnoxes.Add(fortknox);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fortknox);
        }

        // GET: /HushHush/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FortKnox fortknox = await db.FortKnoxes.FindAsync(id);
            if (fortknox == null)
            {
                return HttpNotFound();
            }
            return View(fortknox);
        }

        // POST: /HushHush/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,TopSecret,OtherDataWeDontCareAbout")] FortKnox fortknox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fortknox).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fortknox);
        }

        // GET: /HushHush/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FortKnox fortknox = await db.FortKnoxes.FindAsync(id);
            if (fortknox == null)
            {
                return HttpNotFound();
            }
            return View(fortknox);
        }

        // POST: /HushHush/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FortKnox fortknox = await db.FortKnoxes.FindAsync(id);
            db.FortKnoxes.Remove(fortknox);
            await db.SaveChangesAsync();
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
