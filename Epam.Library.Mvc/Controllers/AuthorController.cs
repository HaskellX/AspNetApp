using BL_Contracts;
using BlContracts.Logic;
using Entities.Exceptions;
using Epam.Library.Mvc.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Epam.Library.Mvc.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorLogic authorLogic;
        private readonly ILogger logger;

        public AuthorController(IAuthorLogic logic, ILogger logger)
        {
            this.logger = logger;
            this.authorLogic = logic;
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AuthorCreateVM model)
        {
            if (model == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    authorLogic.Add(new Entities.Author() { FirstName = model.FirstName, LastName = model.LastName });
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
                    }
                }
                logger.Info("Author was added", "Presentation layer, class AuthorController, method ActionResult Create(AuthorCreateVM)");
            }

            return View(model);
        }

        public ActionResult AutoComplete(string nameStartsWith = "")
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    var result = this.authorLogic.GetAll(nameStartsWith);
                    return Json(result.Select(x => new { id = x.Id, text = x.FirstName + " " + x.LastName }), JsonRequestBehavior.AllowGet);
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
                        return HttpNotFound();
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