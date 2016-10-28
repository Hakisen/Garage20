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
using System.Data.Entity.Migrations;

namespace Garage20.Controllers
{
    public class VehiclesController : Controller
    {
        private Garage20Context db = new Garage20Context();

        // GET: Vehicles
        public ActionResult Index(string sort, string searchVType, string searchRNr)
        {
            //var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.TypeOfVehicle);
            //return View(vehicles.ToList());

            var model = db.Vehicles.Include(v => v.Member).Include(v => v.TypeOfVehicle).Where(p => p.TimeOut.Year < 2000);

            if (!String.IsNullOrEmpty(searchVType))
            {
                model = model.Where(s => s.TypeOfVehicle.VehicleType.Contains(searchVType));
            }

            if (!String.IsNullOrEmpty(searchRNr))
            {
                model = model.Where(s => s.RegNr.Contains(searchRNr));
            }


            if (sort == "Member")
            {
                model = model.OrderBy(v => v.Member.MemberName);
            }
            if (sort == "typeOfVehicle")
            {
                model = model.OrderBy(v => v.TypeOfVehicle.VehicleType);
            }
            else if (sort == "regNr")
            {
                model = model.OrderBy(v => v.RegNr);
            }
            else if (sort == "colour")
            {
                model = model.OrderBy(v => v.colour);
            }
            else if (sort == "brand")
            {
                model = model.OrderBy(v => v.Brand);
            }
            else if (sort == "model")
            {
                model = model.OrderBy(v => v.Model);
            }
            else if (sort == "nrOfWheels")
            {
                model = model.OrderBy(v => v.NrOfWheels);
            }
            else if (sort == "timeIn")
            {
                model = model.OrderBy(v => v.TimeIn);
            }           

            return View(model.ToList());
            //return View(db.Vehicles.ToList());
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

        public ActionResult SearchView(string typeOfVehicle = null, string memberName = null, string RegNr = "", string colour = "", string Brand = "", string Model = "", string NrOfWheels = null)
        //public ActionResult SearchView(string typeOfVehicle = null, string RegNr = "", string colour = "", string Brand = "", string Model = "", string NrOfWheels = null) //Med egen ViewModel = SerarchView
        //public ActionResult Search(TypeOfVehicle TypeOfVehicle, string RegNr = "", string colour = "", string Brand = "", string Model = "", int NrOfWheels = 0) //Fungerar med enum!
        {
            var model = db.Vehicles
                .Where(p => (p.TypeOfVehicle.VehicleType.ToString().ToLower().Contains(typeOfVehicle.ToLower()) || typeOfVehicle == null || typeOfVehicle == "")
                && (p.Member.MemberName.ToString().ToLower().Contains(memberName.ToLower()) || memberName == null || memberName == "") 
                && (RegNr == null || RegNr == "" || p.RegNr.ToUpper().Contains(RegNr.ToUpper()))
                && (colour == null || colour == "" || p.colour.ToUpper().Contains(colour.ToUpper()))
                && (Brand == null || Brand == "" || p.Brand.ToUpper().Contains(Brand.ToUpper()))
                && (p.NrOfWheels.ToString().Contains(NrOfWheels) || NrOfWheels == "" || NrOfWheels == null || NrOfWheels == "0"));

 /*             .Where(p => (p.TypeOfVehicle.ToString().ToLower().Contains(typeOfVehicle.ToLower()) || typeOfVehicle == null || typeOfVehicle == "") 
                && (RegNr == null || RegNr == "" || p.RegNr.ToUpper().Contains(RegNr.ToUpper()))
                && (colour == null || colour == "" || p.colour.ToUpper().Contains(colour.ToUpper()))
                && (Brand == null || Brand == "" || p.Brand.ToUpper().Contains(Brand.ToUpper()))
                && (p.NrOfWheels.ToString().Contains(NrOfWheels) || NrOfWheels == "" || NrOfWheels == null || NrOfWheels == "0"));

                
            .Where(p => p.TypeOfVehicle.ToString().ToLower().Contains(typeOfVehicle.ToString().ToLower()) 
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

            return View("SearchResult", model.ToList());  // "SearchResult" är en annan vy
        } 

        //****************************************************


        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberName");
            ViewBag.TypeOfVehicleId = new SelectList(db.TypeOfVehicles, "Id", "VehicleType");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeOfVehicleId,RegNr,colour,Brand,Model,NrOfWheels,MemberId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
               Vehicle existRegNr = db.Vehicles.FirstOrDefault(v => v.RegNr.ToLower() == vehicle.RegNr.ToLower());
                if (existRegNr != null && existRegNr.TimeOut.Year < 2000)
                {
                        ViewBag.ErrorMessage = ("Error vehicle RegNr  \"" + existRegNr.RegNr + "\"  already exist, change to unique");
                        //return View(vehicle);
                }
                else
                {
                    vehicle.TimeIn = DateTime.Now;
                    //vehicle.ParkingCostParkHour = 60;
                    db.Vehicles.Add(vehicle);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                    
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberName", vehicle.MemberId);
            ViewBag.TypeOfVehicleId = new SelectList(db.TypeOfVehicles, "Id", "VehicleType", vehicle.TypeOfVehicleId);
            return View(vehicle);
        }


    //    if (ModelState.IsValid)  //gamla koden inanan Ulfs ändringar
    //    {
    //        vehicle.TimeIn = DateTime.Now;
    //        db.Vehicles.Add(vehicle);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    return View(vehicle);
    //}

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

            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberName", vehicle.MemberId);
            ViewBag.TypeOfVehicleId = new SelectList(db.TypeOfVehicles, "Id", "VehicleType", vehicle.TypeOfVehicleId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeOfVehicleId,RegNr,colour,Brand,Model,NrOfWheels,MemberId")] Vehicle vehicle)

        {
            //var timeIn = vehicle.TimeIn;
            if (ModelState.IsValid)
            {
//                Vehicle existRegNr = db.Vehicles.FirstOrDefault(v => v.RegNr.ToLower() == vehicle.RegNr.ToLower());
                Vehicle existRegNr = db.Vehicles.FirstOrDefault(v => v.RegNr.ToLower() == vehicle.RegNr.ToLower());

                var test = existRegNr;

                if (existRegNr != null && (existRegNr.Id != vehicle.Id))  // && (existRegNr.TimeOut.Year < 2000))
                {
                    ViewBag.ErrorMessage = ("Error vehicle RegNr  \"" + existRegNr.RegNr + "\"  already exist, change to unique");
                    //return View(vehicle);
                }
                else
                {
                    //vehicle.ParkingCostParkHour = 60;
                    //db.Vehicles.Add(vehicle);
                    var old = db.Vehicles.Find(vehicle.Id);
                    vehicle.TimeIn = old.TimeIn;
                    //context.Entry(vehicle).State?? context.Entry är förmodligen vårt db.Entry
                    //db.Entry(vehicle).State = EntityState.Modified;
                    db.Vehicles.AddOrUpdate(vehicle);  //
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "MemberName", vehicle.MemberId);
            ViewBag.TypeOfVehicleId = new SelectList(db.TypeOfVehicles, "Id", "VehicleType", vehicle.TypeOfVehicleId);
            return View(vehicle);
        }

        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehicle).State = EntityState.Modified;

        //        //DateTime time = DateTime.Now;              // Use current time
        //        //string format = "yyyy-MM-dd HH:MM:ss";    // modify the format depending upon input required in the column in database 
        //        //string insert = @" insert into Table(DateTime Column) values ('" + time.ToString(format) + "')";

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vehicle);
        //}

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
            vehicle.TimeOut = DateTime.Now;
            vehicle.TimeParked = vehicle.TimeOut - vehicle.TimeIn;
            vehicle.TimeFee = 60 * (int)((TimeSpan)vehicle.TimeParked).TotalMinutes / 60;
            //db.SaveChanges();
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)  //old view
        //public ActionResult Delete([Bind(Include = "Id,TypeOfVehicle,RegNr,colour,Brand,Model,NrOfWheels,TimeIn,TimeOut,TimeFee")] Vehicle vehicle)
        {            
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle.TimeOut.Year < 2000)
            {
                vehicle.TimeOut = DateTime.Now;
                vehicle.TimeParked = vehicle.TimeOut - vehicle.TimeIn;
                vehicle.TimeFee = 60 * (int)((TimeSpan)vehicle.TimeParked).TotalMinutes / 60;
                var old = db.Vehicles.Find(vehicle.Id);
                vehicle.TimeIn = old.TimeIn;

                //db.Vehicles.Remove(vehicle);  //old Remove-function
                db.Vehicles.AddOrUpdate(vehicle);
                db.SaveChanges();

                return View("Receipt", vehicle);
            }
            ViewBag.Message = "Sorry, no can do - Vehicle already checked out!";
            return View(vehicle);       
        }


        // Scaffold original VS:
        //// POST: Vehicles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    db.Vehicles.Remove(vehicle);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
