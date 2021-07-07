using Microsoft.AspNet.Identity;
using RedMCOCAW.Models.Alliance;
using RedMCOCAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedMCOCAW.Controllers
{
    [Authorize]
    public class AllianceController : Controller
    {
        // GET: Alliance
        public ActionResult Index()
        {
            AllianceService service = CreateAllianceService();
            var model = service.GetAlliances();

            return View(model);
        }


        // Get: Create        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AllianceCreate model)
        {
            if (!ModelState.IsValid) return View(model);           

            AllianceService service = CreateAllianceService();
            if (service.CreateAlliance(model))
            {
                TempData["SaveResult"] = "Your alliance was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Alliance could not be created.");
                return View(model);
        }

        // Get: Edit
        public ActionResult Edit(int id)
        {
            var svc = CreateAllianceService();
            var detail = svc.GetAllianceById(id);
            var model = new AllianceEdit
            {
                AllianceId = detail.AllianceId,
                AllianceTag = detail.AllianceTag,
                Notes = detail.Notes
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AllianceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.AllianceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = CreateAllianceService();
            if(svc.EditAlliance(model))
            {
                TempData["SaveResult"] = "You alliance was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your alliance could not be updated.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateAllianceService();
            var model = svc.GetAllianceById(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAllianceService();
            var model = svc.GetAllianceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAlliance(int id)
        {
            var svc = CreateAllianceService();
            svc.DeleteAlliance(id);
            TempData["SaveResult"] = "Your alliance was deleted";
            return RedirectToAction("Index");
        }

        
        
        
        
        private AllianceService CreateAllianceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AllianceService(userId);
            return service;
        }               
    }
}