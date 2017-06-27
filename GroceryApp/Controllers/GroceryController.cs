using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryApp.Controllers
{
    [RoutePrefix("grocery")]
    public class GroceryController : Controller
    {
        [Route("list")]
        public ActionResult List()
        {
            return View();
        }
    }
}