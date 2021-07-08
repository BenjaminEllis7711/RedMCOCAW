using Microsoft.AspNet.Identity;
using RedMCOCAW.Models.NodeRoster;
using RedMCOCAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedMCOCAW.Controllers
{
    [Authorize]
    public class NodeRosterController : Controller
    {
        // GET: NodeRoster        
        public ActionResult Index()
        {
            NodeRosterService service = CreateNodeRosterService();
            var model = service.GetNodeRosters();

            return View(model);
        }


        // Get: Create        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NodeRosterModel model)
        {
            if (!ModelState.IsValid) return View(model);

            NodeRosterService service = CreateNodeRosterService();
            if (service.CreateNodeRoster(model))
            {
                TempData["SaveResult"] = "The champion was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "NodeRoster could not be created.");
            return View(model);
        }

        // Get: Edit
        public ActionResult Edit(int id)
        {
            var svc = CreateNodeRosterService();
            var detail = svc.GetNodeRosterByNodeId(id);
            var model = new NodeRosterModel
            {
                NodeId = detail.NodeId,
                NodeAssignmentId = detail.NodeAssignmentId

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NodeRosterModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var svc = CreateNodeRosterService();
            if (svc.EditNodeRoster(model))
            {
                TempData["SaveResult"] = "The node/roster connection was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The node/roster connection could not be updated.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateNodeRosterService();
            var model = svc.GetNodeRosterByNodeId(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateNodeRosterService();
            var model = svc.GetNodeRosterByNodeId(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNodeRoster(int id)
        {
            var svc = CreateNodeRosterService();
            svc.DeleteNodeRoster(id);
            TempData["SaveResult"] = "The node/roster connection was deleted";
            return RedirectToAction("Index");
        }





        private NodeRosterService CreateNodeRosterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NodeRosterService(userId);
            return service;
        }
    }
}