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
    public class PublisherController : Controller
    {
        private readonly IPublisherLogic logic;
        private readonly ILogger logger;

        public PublisherController(IPublisherLogic logic, ILogger logger)
        {
            this.logic = logic;
            this.logger = logger;
        }

        public ActionResult AutoComplete(string nameStartsWith = "")
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    return this.Json(this.logic.GetAll(nameStartsWith).Select(x => new { id = x.Id, text = x.PublisherName }), JsonRequestBehavior.AllowGet);
                }
                catch (System.Exception e)
                {
                    if (e is DalException)
                    {
                        return this.Json(new{ }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        logger.Warning("BL", e);
                        return this.Json(new { }, JsonRequestBehavior.AllowGet);
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