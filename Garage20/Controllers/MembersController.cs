using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage20.Models;

namespace Garage20.Controllers
{
    public class MembersController : Controller
    {
        private Garage20Context db = new Garage20Context();

        // GET: Members
        public ActionResult Index(string searchMember)
        {
            var member = from m in db.Members
                        select m;

            if (!String.IsNullOrEmpty(searchMember))
            {
                member = member.Where(s => s.MemberName.Contains(searchMember));
            }

            
            return View(member.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberName")] Member member)
        {
            if (ModelState.IsValid)
            {
                Member existMember = db.Members.FirstOrDefault(v => v.MemberName.ToLower() == member.MemberName.ToLower());
                if (existMember != null)
                {
                    ViewBag.ErrorMessage = ("Error Member Name  \"" + existMember.MemberName + "\"  already exist, change to unique");
                    //return View(vehicle);
                }
                else
                {
                    db.Members.Add(member);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberName")] Member member)
        {
            if (ModelState.IsValid)
            {
                //Vehicle existRegNr = db.Vehicles.FirstOrDefault(v => v.RegNr.ToLower() == vehicle.RegNr.ToLower());
                Member existMember = db.Members.FirstOrDefault(v => v.MemberName.ToLower() == member.MemberName.ToLower());
                if (existMember != null)
                {
                    ViewBag.ErrorMessage = ("Error Member Name  \"" + existMember.MemberName + "\"  already exist, change to unique");
                    //return View(vehicle);
                }
                else
                {
                    db.Entry(member).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
