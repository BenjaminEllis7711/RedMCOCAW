﻿using RedMCOCAW.Models.Alliance;
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
            var model = new AllianceListItem[0];
            return View(model);
        }

        // Get: Create
        public ActionResult Create()
        {
            return View();
        }
    }
}