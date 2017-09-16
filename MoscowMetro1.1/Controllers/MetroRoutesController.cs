using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoscowMetro1._1.Models;

namespace MoscowMetro1._1.Controllers
{
    public class MetroRoutesController : Controller
    {
        private MoscowMetroEntities db = new MoscowMetroEntities();

        // GET: MetroRoutes
        public ActionResult Index()
        {
            return View(db.MetroRoutes.ToList());
        }

        public ActionResult Get()
        {

            //db.MetroRoutes.Select(c => c.UserId == userId).ToList()

            return Json(db.MetroRoutes.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: MetroRoutes/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetroRoute metroRoute = db.MetroRoutes.Find(id);
            if (metroRoute == null)
            {
                return HttpNotFound();
            }
            return View(metroRoute);
        }

        // GET: MetroRoutes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetroRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateAntiForgeryHeader]
        public ActionResult Create([Bind(Include = "id,UserId,SequenceOfStations,Name")] MetroRoute metroRoute)
        {
            if (metroRoute.SequenceOfStations == null) return Json(metroRoute);

            if (ModelState.IsValid)
            {
                db.MetroRoutes.Add(metroRoute);
                db.SaveChanges();
                return Json(db.MetroRoutes.ToList());
            }

            //return View(metroRoute);
            return Json(metroRoute);
        }

        // GET: MetroRoutes/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetroRoute metroRoute = db.MetroRoutes.Find(id);
            if (metroRoute == null)
            {
                return HttpNotFound();
            }
            return View(metroRoute);
        }

        // POST: MetroRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserId,SequenceOfStations,Name")] MetroRoute metroRoute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metroRoute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metroRoute);
        }

        // GET: MetroRoutes/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetroRoute metroRoute = db.MetroRoutes.Find(id);
            if (metroRoute == null)
            {
                return HttpNotFound();
            }
            return View(metroRoute);
        }

        // POST: MetroRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        [ValidateAntiForgeryHeader]
        public ActionResult DeleteConfirmed(short id)
        {
            MetroRoute metroRoute = db.MetroRoutes.Find(id);
            db.MetroRoutes.Remove(metroRoute);
            db.SaveChanges();
            return Json(db.MetroRoutes.ToList());
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
