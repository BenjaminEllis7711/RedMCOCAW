using Microsoft.AspNet.Identity;
using RedMCOCAW.Models.Node;
using RedMCOCAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedMCOCAW.Controllers
{
    [Authorize]
    public class NodeController : Controller
    {
        // GET: Node
        public ActionResult Index()
        {
            NodeService service = CreateNodeService();
            var model = service.GetNodes();

            return View(model);
        }


        // Get: Create        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NodeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            NodeService service = CreateNodeService();
            if (service.CreateNode(model))
            {
                TempData["SaveResult"] = "The node was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Node could not be created.");
            return View(model);
        }

        // Get: Edit
        public ActionResult Edit(int id)
        {
            var svc = CreateNodeService();
            var detail = svc.GetNodeById(id);
            var model = new NodeListItem
            {
                NodeId = detail.NodeId,
                Details = detail.Details

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NodeListItem model)
        {
            if (!ModelState.IsValid) return View(model);

            var svc = CreateNodeService();
            if (svc.EditNode(model))
            {
                TempData["SaveResult"] = "The node was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The node could not be updated.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateNodeService();
            var model = svc.GetNodeById(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateNodeService();
            var model = svc.GetNodeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNode(int id)
        {
            var svc = CreateNodeService();
            svc.DeleteNode(id);
            TempData["SaveResult"] = "The node was deleted";
            return RedirectToAction("Index");
        }





        private NodeService CreateNodeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NodeService(userId);
            return service;
        }

    }
}
