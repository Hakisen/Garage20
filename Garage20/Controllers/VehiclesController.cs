using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage20.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage20.Controllers
{
    public class VehiclesController : Controller
    {
        private Garage20Context db = new Garage20Context();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        //***********************************************
        //***********************************************


        public ActionResult Search()
        {
            return View();
        }


        [HttpGet]
        //GET: Vehicle/RegNr
        //public ActionResult Search([Bind(Include = "TypeOfVehicle, RegNr, colour, Brand, Model, NrOfWheels")] Vehicle vehicle)
        public ActionResult Search(string TypeOfVehicle, string RegNr, string colour, string Brand, string Model, int? NrOfWheels)
        {
            //if (RegNr == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Vehicle vehicle = db.Vehicles.Find(RegNr);
            //if (vehicle == null)
            //{
            //    return HttpNotFound();
            //}

            return View(db.Vehicles.Where(p => p.TypeOfVehicle.Equals(TypeOfVehicle) && p.RegNr.ToUpper().Contains(RegNr.ToUpper()) && p.colour.ToUpper().Contains(colour.ToUpper()) && p.Brand.ToUpper().Contains(Brand.ToUpper())).ToList()); //OK! 
            //searchedVehicles.ForEach(p => Console.WriteLine("Vehicle: \t" + p.GetType().Name

            //return View(db.Vehicles.ToList());


            //return View(vehicle);
        }

        //****************************************************
        //****************************************************




        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id,TypeOfVehicle,RegNr,colour,Brand,Model,NrOfWheels,TimeIn")] Vehicle vehicle)
        {

            if (ModelState.IsValid)
            {   
                vehicle.TimeIn = DateTime.Now;
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeOfVehicle,RegNr,colour,Brand,Model,NrOfWheels,TimeIn")] Vehicle vehicle)
        {
            //var timeIn = vehicle.TimeIn;
            if (ModelState.IsValid)
            {
                var old = db.Vehicles.Find(vehicle.Id);
                vehicle.TimeIn = old.TimeIn;

                //vehicle.TimeIn = timeIn;
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
