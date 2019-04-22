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
using System.Web.Caching;
using System.Web.Mvc;

namespace Epam.Library.Mvc.Controllers
{
    public class PatentController : Controller
    {
        private readonly ILogger logger;
        private readonly IPatentLogic patentLogic;

        public PatentController(IPatentLogic patentLogic, Cache cache, ILogger logger)
        {
            this.patentLogic = patentLogic;
            this.logger = logger;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(PatentCreateFormVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entityId = this.patentLogic.AddPatent(model.Country, model.RegNumber, model.SubmissionDocuments, model.DateOfPublication, model.DateOfPublication.Year, model.Name, model.NumberOfPages, model.Note, new HashSet<Author>(model.AuthorsId.Select(x => new Author { Id = x })));

                    logger.Info("Patent was added", "Presentation layer, class PatentController, method ActionResult Create(PatentCreateFormVM)");
                    return RedirectToAction("Item", "Common", new { id = entityId });
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
            //var entity = cache.Get("patent") as Patent;

            //if (entity == null)
            //{
            //    entity = this.patentLogic.GetPatentById((int)id);
            //    if (entity == null || ! (entity is Patent))
            //    {
            //        return HttpNotFound();
            //    }

            //    cache.Add("patent", entity, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10), CacheItemPriority.Normal, null);
            //}

            try
            {
                var entity = this.patentLogic.GetPatentById((int)id);

                ViewBag.AuthorsId = new MultiSelectList(entity.Authors.Select(x => new { Id = x.Id, FullName = x.FirstName + " " + x.LastName }), "Id", "FullName", selectedValues: entity.Authors.Select(x => x.Id));

                var model = Mapper.Map<PatentEditFormVM>(entity);

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
        public ActionResult Edit(PatentEditFormVM model)
        {
            var cache = HttpContext.Cache;
            var entity = cache.Get("patent") as Patent;

            if (entity == null)
            {
                try
                {
                    entity = this.patentLogic.GetPatentById(model.Id);
                    if (entity == null || !(entity is Patent))
                    {
                        return HttpNotFound();
                    }

                    cache.Add("patent", entity, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10), CacheItemPriority.Normal, null);
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

            ViewBag.AuthorsId = new MultiSelectList(entity.Authors.Select(x => new { Id = x.Id, FullName = x.FirstName + " " + x.LastName }), "Id", "FullName", selectedValues: entity.Authors.Select(x => x.Id));

            if (ModelState.IsValid)
            {
                try
                {
                    var result = this.patentLogic.Update(model.Id, model.Country, model.RegNumber, model.SubmissionDocuments, model.DateOfPublication, model.DateOfPublication.Year, model.Name, model.NumberOfPages, model.Note, new HashSet<Author>(model.AuthorsId.Select(x => new Author { Id = x })));
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

                logger.Info("Patent was updated", "Presentation layer, class PatentController, method ActionResult Edit(PatentEditFormVM)");

                cache.Remove("patent");
                return RedirectToAction("Item", "Common", new { Id = model.Id });
            }

            return View(model);
        }
    }
}