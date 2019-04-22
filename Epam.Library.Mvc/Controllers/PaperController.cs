using BL_Contracts;
using BlContracts.Logic;
using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Epam.Library.Mvc.Controllers
{
    public class PaperController : Controller
    {
        private readonly IPaperLogic logic;
        private readonly ILogger logger;

        public PaperController(IPaperLogic logic, ILogger logger)
        {
            this.logger = logger;
            this.logic = logic;
        }
        public ActionResult AutoComplete(string nameStartsWith = "")
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    var result = this.logic.GetPapersStartsWith(nameStartsWith);
                    return Json(result.Select(x => new { id = x.Id, text = x.Name }), JsonRequestBehavior.AllowGet);
                }
                catch (System.Exception e)
                {
                    if (e is DalException)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                    }
                    else
                    {
                        logger.Warning("BL", e);
                        return RedirectToAction("Index", "Common");
                    }
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
