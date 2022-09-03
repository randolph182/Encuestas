using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EncuestaProject.Models;

namespace EncuestaProject.Controllers
{
    [Authorize]
    public class CuentaController : Controller
    {
        private EncuestaModel db = new EncuestaModel();

        // GET: Cuenta
        public ActionResult Index()
        {
            return View(db.CUENTA.ToList());
        }

        // GET: Cuenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA cUENTA = db.CUENTA.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA);
        }

        // GET: Cuenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuenta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,usuario,password")] CUENTA cUENTA)
        {
            if (ModelState.IsValid)
            {
                db.CUENTA.Add(cUENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUENTA);
        }

        // GET: Cuenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA cUENTA = db.CUENTA.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA);
        }

        // POST: Cuenta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,usuario,password")] CUENTA cUENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUENTA);
        }

        // GET: Cuenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUENTA cUENTA = db.CUENTA.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }
            return View(cUENTA);
        }

        // POST: Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUENTA cUENTA = db.CUENTA.Find(id);
            db.CUENTA.Remove(cUENTA);
            db.SaveChanges();
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
