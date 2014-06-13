using StoObektaAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoObektaAdmin.Controllers
{
    public class CommentsController : Controller
    {
        //
        // GET: /Comments/

        public ActionResult Index()
        {
            var model = new CommentsModel();
            return View("CommentsPanel",model);
        }

        public ActionResult GetCommentsForSite(string number)
        {
            var model = new CommentsModel();
            model.FindComments(int.Parse(number));
            return View("CommentsPanel",model);
        }

        [HttpPost]
        public ActionResult DeleteComment(string commentId,string siteId)
        {
            var model = new CommentsModel();
            model.DeleteComment(int.Parse(commentId));
            model.FindComments(int.Parse(siteId));
            return View("CommentsPanel", model);
        }

    }
}
