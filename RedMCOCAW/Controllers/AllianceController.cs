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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AllianceService(userId);
            var model = service.GetAlliances();

            return View(model);
        }

        // Get: Create
        public ActionResult Create()
        {
            return View();
        }
    }
}