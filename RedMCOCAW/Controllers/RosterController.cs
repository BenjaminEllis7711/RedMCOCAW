using Microsoft.AspNet.Identity;
using RedMCOCAW.Models.Roster;
using RedMCOCAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedMCOCAW.Controllers
{
    [Authorize]
    public class RosterController : Controller
    {
        
        public ActionResult Index()
        {
            RosterService service = CreateRosterService();
            var model = service.GetRosters();

            return View(model);
        }

               
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RosterCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            RosterService service = CreateRosterService();

            if(!service.DoesChampIdExist(model.ChampionId))
            {
                ModelState.AddModelError("", "There is no champion with that ID");
                return View(model);
            }

            if (service.CreateRoster(model))
            {
                TempData["SaveResult"] = "Your roster adjustment has been made.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Roster could not be created.");
            return View(model);
        }

        // Get: Edit
        public ActionResult Edit(int id)
        {
            var svc = CreateRosterService();
            var detail = svc.GetRosterByMemberId(id);
            var model = new RosterEdit
            {
                MemberId = detail.MemberId,
                ChampionId = detail.ChampionId,
                NodeAssignmentId = detail.NodeAssignmentId,
                IsAssigned = detail.IsAssigned
                
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RosterEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MemberId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = CreateRosterService();
            if (svc.EditRoster(model))
            {
                TempData["SaveResult"] = "You node assignment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your node assignment could not be updated.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateRosterService();
            var model = svc.GetRosterByMemberId(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRosterService();
            var model = svc.GetRosterByMemberId(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoster(int id)
        {
            var svc = CreateRosterService();
            svc.DeleteRosterByNodeAssignmentId(id);
            TempData["SaveResult"] = "Your roster assignment was deleted";
            return RedirectToAction("Index");
        }





        private RosterService CreateRosterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RosterService(userId);
            return service;
        }
    }
}