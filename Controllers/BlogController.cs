﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyShop.Models;

namespace ToyShop.Controllers
{
    public class BlogController : Controller
    {
        
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}