using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc02.Controllers
{
    public class CourseController : Controller
    {
        public static List<mvc02.Models.Course> clist = new List<mvc02.Models.Course>();

        static CourseController()
        {
            mvc02.Models.Course c = new mvc02.Models.Course();
            c.Id = 1;
            c.Code = "L001";
            c.Name = "Linux LPI Level 1";
            c.Category = "Server Admin";
            c.Tutor = "Peter";
            c.Price = 3000;
            clist.Add(c);

            c = new mvc02.Models.Course();
            c.Id = 2;
            c.Code = "L002";
            c.Name = "LPI Level 2";
            c.Category = "Server Admin";
            c.Tutor = "Peter";
            c.Price = 4000;
            clist.Add(c);
        }

        // GET: Course
        public ActionResult Index()
        {
            return View(clist);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            mvc02.Models.Course c = clist.Single(r => r.Id == id);
            return View(c);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                mvc02.Models.Course c = new mvc02.Models.Course();
                c.Id = clist.ElementAt(clist.Count - 1).Id + 1;
                c.Code = collection["Code"];
                c.Name = collection["Name"];
                c.Tutor = collection["Tutor"];
                c.Price = Convert.ToDecimal(collection["Price"]);
                clist.Add(c);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            mvc02.Models.Course c = clist.Single(r => r.Id == id);
            return View(c);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                mvc02.Models.Course c = clist.Single(r => r.Id == id);
                c.Id = clist.ElementAt(clist.Count - 1).Id + 1;
                c.Code = collection["Code"];
                c.Name = collection["Name"];
                c.Tutor = collection["Tutor"];
                c.Price = Convert.ToDecimal(collection["Price"]);

                return RedirectToAction("Index");
            }
            catch
            {
                mvc02.Models.Course c = clist.Single(r => r.Id == id);

                return View(c);
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            mvc02.Models.Course c = clist.Single(r => r.Id == id);

            return View(c);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                mvc02.Models.Course c = clist.Single(r => r.Id == id);
                clist.Remove(c);

                return RedirectToAction("Index");
            }
            catch
            {
                mvc02.Models.Course c = clist.Single(r => r.Id == id);

                return View(c);
            }
        }
    }
}
