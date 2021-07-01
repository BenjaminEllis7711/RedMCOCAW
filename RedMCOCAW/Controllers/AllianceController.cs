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
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Alliance could not be created.");
                return View(model);
        }

        // Get: Edit
        public ActionResult Edit(AllianceCreate model)
        {

        }
        private AllianceService CreateAllianceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AllianceService(userId);
            return service;
        }               
    }
}