using Microsoft.AspNet.Identity;
using RedMCOCAW.Models.Member;
using RedMCOCAW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedMCOCAW.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {

        // GET: Member
        public ActionResult Index()
        {
            MemberService service = CreateMemberService();
            var model = service.GetMembers();

            return View(model);
        }


        // Get: Create        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            MemberService service = CreateMemberService();

            if(service.IsMemberNameInAlliance(model.Name, model.AllianceTag))
            {
                ModelState.AddModelError("", "A member by that name already exists in that alliance.");
                return View(model);
            }
            if (service.CreateMember(model))
            {
                TempData["SaveResult"] = "Your Member was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Member could not be created.");
            return View(model);
        }

        // Get: Edit by member id
        public ActionResult Edit(int id)
        {
            var svc = CreateMemberService();
            var detail = svc.GetMemberById(id);
            var model = new MemberEdit
            {
                MemberId = detail.MemberId, 
                AllianceId = detail.AllianceId,
                Name = detail.Name,
                Notes = detail.Notes
            };
            return View(model);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MemberEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MemberId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = CreateMemberService();
            if (!svc.DoesAllianceExistForMemberEdit(model.AllianceId))
            {
                ModelState.AddModelError("", "You do not own an alliance by that ID");
                return View(model);
            }
            if (svc.EditMember(model))
            {
                TempData["SaveResult"] = "Your member was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your member could not be updated.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var svc = CreateMemberService();
            var model = svc.GetMemberById(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMemberService();
            var model = svc.GetMemberById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMember(int id)
        {
            var svc = CreateMemberService();
            svc.DeleteMember(id);
            TempData["SaveResult"] = "Your member was deleted";
            return RedirectToAction("Index");
        }





        private MemberService CreateMemberService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberService(userId);
            return service;
        }

    }
}