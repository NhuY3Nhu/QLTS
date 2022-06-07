using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectQLTS;

namespace ProjectQLTS.Controllers
{
    public class ThanhViensController : Controller
    {
        private qlts db = new qlts();

        // GET: ThanhViens
        /*public ActionResult Index()
        {
            var thanhViens = db.ThanhViens.Include(t => t.PhanQuyen);
            return View(thanhViens.ToList());
        }*/

        // GET: /Link/
        public ActionResult Index(string searchString)
        {
            var links = from l in db.ThanhViens
                        select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.HoTen.Contains(searchString));
            }

            return View(links);
        }

        // GET: ThanhViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            return View(thanhVien);
        }

        // GET: ThanhViens/Create
        public ActionResult Create()
        {
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen");
            return View();
        }

        // POST: ThanhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDThanhVien,HoTen,DiaChi,SDT,MatKhau,IDQuyen")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.ThanhViens.Add(thanhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", thanhVien.IDQuyen);
            return View(thanhVien);
        }

        // GET: ThanhViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            if (thanhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", thanhVien.IDQuyen);
            return View(thanhVien);
        }

        // POST: ThanhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDThanhVien,HoTen,DiaChi,SDT,MatKhau,IDQuyen")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", thanhVien.IDQuyen);
            return View(thanhVien);
        }

        public ActionResult Delete(int id)
        {
            ThanhVien thanhVien = db.ThanhViens.Find(id);
            db.ThanhViens.Remove(thanhVien);
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
