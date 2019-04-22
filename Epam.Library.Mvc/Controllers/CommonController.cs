using BL_Contracts;
using BlContracts.Logic;
using Entities;
using Entities.Exceptions;
using Epam.Library.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Epam.Library.Mvc.Controllers
{
    public class CommonController : Controller
    {
        private readonly ICommonAccess commonAccessLogic;
        private readonly IPaperIssueLogic paperIssueLogic;
        private readonly ILogger logger;

        public CommonController(ICommonAccess logic, IPaperIssueLogic paperLogic, ILogger logger)
        {
            this.commonAccessLogic = logic;
            this.paperIssueLogic = paperLogic;
            this.logger = logger;
        }

    public ActionResult PaperIssuesByPaper(int? id)
        {
            if (id != null)
            {
                try
                {
                    IEnumerable<PaperIssue> li = paperIssueLogic.GetPaperIssuesByPaperId((int)id);
                    return View("GetPaperIssuesByPaperId", li);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Index(int pageNumber = 1)
        {
            try
            {
                int totalPages;
                IEnumerable<LibraryItem> items = commonAccessLogic.GetAll(pageNumber, 20, out totalPages);
                PaginationVM newModel = new PaginationVM { TotalNumberOfPages = totalPages, Items = items, CurrentPage = pageNumber };
                return View(newModel);
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

        //[ChildActionOnly]
        public ActionResult Item(int? id)
        {
            if (id != null)
            {
                try
                {
                    LibraryItem li = commonAccessLogic.GetItemById((int)id);
                    return View(li);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                try
                {
                    commonAccessLogic.Delete((int)id);
                    return RedirectToAction("Index", "Common");
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}