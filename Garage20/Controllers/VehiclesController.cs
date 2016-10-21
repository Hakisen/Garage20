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


        //*******************************************************

        //Search-funktionen. Det går att söka på samtliga fäl (utom Id och Time) samtidigt.
        //public ActionResult Search()  // Ersatt av ViewModel nedan
        public ActionResult SearchView()
        {
            return View();
        }

                //GET: Vehicle/Search all
        [HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult Search()  // Ersatt av ViewModel nedan

        public ActionResult SearchView(string typeOfVehicle=null, string RegNr = "", string colour = "", string Brand = "", string Model = "", string NrOfWheels = null)
        //public ActionResult Search(TypeOfVehicle TypeOfVehicle, string RegNr = "", string colour = "", string Brand = "", string Model = "", int NrOfWheels = 0) //Fungerar med enum!
        {            
            var model = db.Vehicles
                .Where(p => (p.TypeOfVehicle.ToString().ToLower().Contains(typeOfVehicle.ToLower()) || typeOfVehicle == null || typeOfVehicle == "") 
                && (RegNr == null || RegNr == "" || p.RegNr.ToUpper().Contains(RegNr.ToUpper()))
                && (colour == null || colour == "" || p.colour.ToUpper().Contains(colour.ToUpper()))
                && (Brand == null || Brand == "" || p.Brand.ToUpper().Contains(Brand.ToUpper()))
                && (p.NrOfWheels.ToString().Contains(NrOfWheels) || NrOfWheels == "" || NrOfWheels == null || NrOfWheels == "0"));
                
/*            .Where(p => p.TypeOfVehicle.ToString().ToLower().Contains(typeOfVehicle.ToString().ToLower()) 
            && (RegNr == null || RegNr == "" || p.RegNr.ToUpper().Contains(RegNr.ToUpper())) 
            && (colour == null || colour == "" || p.colour.ToUpper().Contains(colour.ToUpper())) 
            && (Brand == null || Brand == "" || p.Brand.ToUpper().Contains(Brand.ToUpper())) 
            && (p.NrOfWheels.ToString().Contains(NrOfWheels) || NrOfWheels == "" || NrOfWheels == null));   */

            //.Where(p => RegNr == null || RegNr == "" || p.RegNr.ToUpper().Contains(RegNr.ToUpper()));  //FUNGERAR även utan text i RegNr!
            //.Where(p => p.RegNr.ToUpper().Contains(RegNr.ToUpper()) || RegNr == null || RegNr == "");  //FUNGERAR även utan text i RegNr!!
            //.Where(p => p.RegNr == null || p.RegNr == "" || p.RegNr.ToUpper().Contains(RegNr.ToUpper()));  //FUNGERAR med text i RegNr!
            //.Where(p => p.TypeOfVehicle.ToString().ToLower().Contains(TypeOfVehicle.ToString().ToLower()));    //FUNGERAR!! Här skickas enum in....
            //.Where(p => p.TypeOfVehicle.ToString().ToLower() == TypeOfVehicle.ToString().ToLower());   //FUNGERAR!! Här skickas enum in...

/*            .Where(p => p.TypeOfVehicle.ToString().ToLower().Contains(TypeOfVehicle.ToString().ToLower()) 
              && (p.RegNr == null || p.RegNr == "" || p.RegNr.ToUpper().Contains(RegNr.ToUpper())) 
              && (p.colour == null || p.colour == "" || p.colour.ToUpper().Contains(colour.ToUpper())) 
              && (p.Brand == null || p.Brand == "" || p.Brand.ToUpper().Contains(Brand.ToUpper())) 
              && (p.NrOfWheels == NrOfWheels || p.NrOfWheels == 0));   Här är NrOfWheels en int.    */

            if (model.Count() == 0)
            {
                ViewBag.ResultMessage = "No parked vechicles found in your Search";
            }           

            return View("SearchResult", model.ToList());  // "SearcResult" är en annan vy
        } 

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
