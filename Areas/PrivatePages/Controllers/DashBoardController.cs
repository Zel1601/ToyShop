using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToyShop.Areas.PrivatePages.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: PrivatePages/DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}