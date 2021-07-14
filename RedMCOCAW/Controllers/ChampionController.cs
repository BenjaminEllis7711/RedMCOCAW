using Microsoft.AspNet.Identity;
using RedMCOCAW.Models.Champion;
using RedMCOCAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedMCOCAW.Controllers
{
    [Authorize]
    public class ChampionController : Controller
    {
        // GET: Champion
        public ActionResult Index()
        {
            ChampionService service = CreateChampionService();
            var model = service.GetChampions();

            return View(model);
        }


        // Get: Create        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChampionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            ChampionService service = CreateChampionService();
            if (service.CreateChampion(model))
            {
                TempData["SaveResult"] = "The champion was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Champion could not be created.");
            return View(model);
        }

        // Get: Edit
        public ActionResult Edit(int id)
        {
            var svc = CreateChampionService();
            var detail = svc.GetChampionById(id);
            var model = new ChampionListItem
            {
                ChampId = detail.ChampId,
                Name = detail.Name
                
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ChampionListItem model)
        {
            if (!ModelState.IsValid) return View(model);           

            var svc = CreateChampionService();
            if (svc.EditChampion(model))
            {
                TempData["SaveResult"] = "The champion was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The champion could not be updated.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateChampionService();
            var model = svc.GetChampionById(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateChampionService();
            var model = svc.GetChampionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteChampion(int id)
        {
            var svc = CreateChampionService();
            svc.DeleteChampion(id);
            TempData["SaveResult"] = "The champion was deleted";
            return RedirectToAction("Index");
        }





        private ChampionService CreateChampionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ChampionService(userId);
            return service;
        }

    }
}