using StoObektaAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoObektaAdmin.Controllers
{
    public class TouristsController : Controller
    {
        //
        // GET: /Tourist/

        public ActionResult Index()
        {
            TouristsModel model = new TouristsModel();
            model.loadTourists();
            return View("TouristsPanel",model);
        }

        [HttpPost]
        public ActionResult SendMessage(string androidID, string message)
        {
            TouristsModel model = new TouristsModel();
            model.sendMessageToUser(androidID, message);
            model.loadTourists();
            return View("TouristsPanel", model);
        }

    }
}
