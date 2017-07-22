using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlmacenSistemaTG.Models;

namespace AlmacenSistemaTG.Controllers
{
    public class EquiposController : Controller
    {
        private SistemaAlmacenEntities db = new SistemaAlmacenEntities();

        // GET: Equipos
        public ActionResult Index()
        {
            var equipoes = db.Equipoes.Include(e => e.Almacen).Include(e => e.Marca).Include(e => e.Modelo);
            return View(equipoes.ToList());
        }

        // GET: Equipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipos/Create
        public ActionResult Create()
        {
            ViewBag.iIdAlmacen = new SelectList(db.Almacens, "iIdAlmacen", "vchDescripcion");
            ViewBag.iIdMarca = new SelectList(db.Marcas, "iIdMarca", "vchDescripcion");
            ViewBag.iIdModelo = new SelectList(db.Modeloes, "iIdModelo", "vchDescripcion");
            return View();
        }

        // POST: Equipos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iIdEquipo,iIdMarca,iIdModelo,vchNoSerie,iExistencia,vchProveedor,iIdAlmacen")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipoes.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iIdAlmacen = new SelectList(db.Almacens, "iIdAlmacen", "vchDescripcion", equipo.iIdAlmacen);
            ViewBag.iIdMarca = new SelectList(db.Marcas, "iIdMarca", "vchDescripcion", equipo.iIdMarca);
            ViewBag.iIdModelo = new SelectList(db.Modeloes, "iIdModelo", "vchDescripcion", equipo.iIdModelo);
            return View(equipo);
        }

        // GET: Equipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.iIdAlmacen = new SelectList(db.Almacens, "iIdAlmacen", "vchDescripcion", equipo.iIdAlmacen);
            ViewBag.iIdMarca = new SelectList(db.Marcas, "iIdMarca", "vchDescripcion", equipo.iIdMarca);
            ViewBag.iIdModelo = new SelectList(db.Modeloes, "iIdModelo", "vchDescripcion", equipo.iIdModelo);
            return View(equipo);
        }

        // POST: Equipos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iIdEquipo,iIdMarca,iIdModelo,vchNoSerie,iExistencia,vchProveedor,iIdAlmacen")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iIdAlmacen = new SelectList(db.Almacens, "iIdAlmacen", "vchDescripcion", equipo.iIdAlmacen);
            ViewBag.iIdMarca = new SelectList(db.Marcas, "iIdMarca", "vchDescripcion", equipo.iIdMarca);
            ViewBag.iIdModelo = new SelectList(db.Modeloes, "iIdModelo", "vchDescripcion", equipo.iIdModelo);
            return View(equipo);
        }

        // GET: Equipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipo equipo = db.Equipoes.Find(id);
            db.Equipoes.Remove(equipo);
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
