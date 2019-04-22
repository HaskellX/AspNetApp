using AutoMapper;
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
using System.Web.Caching;
using System.Web.Mvc;

namespace Epam.Library.Mvc.Controllers
{
    public class PaperIssueController : Controller
    {
        private readonly IPaperIssueLogic logic;
        private readonly ILogger logger;

        public PaperIssueController(IPaperIssueLogic logic, ILogger logger)
        {
            this.logic = logic;
            this.logger = logger;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(PaperIssueCreateFormVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = this.logic.Add(new Paper { Id = model.PaperId }, model.CityOfPublishing, new Publisher { Id = model.PublisherId }, model.DateOfIssue.Year, model.NumberOfPages, model.Note, model.IssueNumber, model.DateOfIssue);

                    logger.Info("PaperIssue was added", "Presentation layer, class PaperIssueController, method ActionResult Create(PaperIssueCreateFormVM)");


                    return RedirectToAction("Item", "Common", new { id = result });
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

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var cache = HttpContext.Cache;
            //var entity = cache.Get("issue") as PaperIssue;

            //if (entity == null)
            //{
            //    entity = this.logic.GetById((int)id);
            //    cache.Add("issue", entity, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10), CacheItemPriority.Normal, null);
            //}

            try
            {
                var entity = this.logic.GetById((int)id);
                ViewBag.PublisherId = new List<SelectListItem> { new SelectListItem { Value = entity.Publisher.Id.ToString(), Text = entity.Publisher.PublisherName.ToString() } };

                ViewBag.PaperId = new List<SelectListItem> { new SelectListItem { Text = entity.Paper.Name, Value = entity.Paper.Id.ToString(), Selected = true } };

                var model = Mapper.Map<PaperIssueEditFormVM>(entity);

                return View(model);
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(PaperIssueEditFormVM model)
        {
            var cache = HttpContext.Cache;
            var entity = cache.Get("issue") as PaperIssue;

            if (entity == null)
            {
                try
                {
                    entity = this.logic.GetById(model.Id);
                    cache.Add("issue", entity, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10), CacheItemPriority.Normal, null);
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

            ViewBag.PublisherId = new List<SelectListItem> { new SelectListItem { Value = entity.Publisher.Id.ToString(), Text = entity.Publisher.PublisherName.ToString() } };

            ViewBag.PaperId = new List<SelectListItem> { new SelectListItem { Text = entity.Paper.Name, Value = entity.Paper.Id.ToString(), Selected = true } };

            if (ModelState.IsValid)
            {
                try
                {
                    var result = this.logic.Update(model.Id, new Paper { Id = model.PaperId }, model.CityOfPublishing, new Publisher { Id = model.PublisherId }, model.DateOfIssue.Year, model.NumberOfPages, model.Note, model.IssueNumber, model.DateOfIssue);

                    logger.Info("PaperIssue was added", "Presentation layer, class PaperIssueController, method ActionResult Edit(PaperIssueFormVM)");

                    cache.Remove("issue");
                    return RedirectToAction("Item", "Common", new { Id = model.Id });
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

            return View(model);
        }
    }
}