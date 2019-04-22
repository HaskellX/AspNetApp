using AutoMapper;
using BL_Contracts;
using BlContracts.Logic;
using Entities;
using Entities.Exceptions;
using Epam.Library.Mvc.Filters;
using Epam.Library.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Security;

namespace Epam.Library.Mvc.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private readonly IBookLogic bookLogic;
        private readonly ILogger logger;

        public BookController(IBookLogic logic, ILogger logger)
        {
            this.bookLogic = logic;
            this.logger = logger;
        }

        [Authorize(Roles = "Admin")]
        /*[LibraryAuth(Roles = "Admin")]*/
        [PostActions]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(BookCreateFormVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = this.bookLogic.Add(model.Name, new HashSet<Author>(model.AuthorsId.Select(x => new Author { Id = x })), model.CityOfPublishing, new Publisher { Id = model.PublisherId }, model.YearOfPublishing, model.NumberOfPages, model.Note, model.ISBN);

                    logger.Info("Book was added", "Presentation layer, class BookController, method ActionResult Create(BookCreateFormVM)");

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
            //var entity = cache.Get("book") as Book;

            //if (entity == null)
            //{
            //    entity = this.bookLogic.GetBookById((int)id);
            //    cache.Add("book", entity, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10), CacheItemPriority.Normal, null);
            //}
            try
            {

                var entity = this.bookLogic.GetBookById((int)id);

                ViewBag.PublisherId = new List<SelectListItem> { new SelectListItem { Value = entity.Publisher.Id.ToString(), Text = entity.Publisher.PublisherName.ToString() } };

                ViewBag.AuthorsId = new MultiSelectList(entity.Authors.Select(x => new { Id = x.Id, FullName = x.FirstName + " " + x.LastName }), "Id", "FullName", selectedValues: entity.Authors.Select(x => x.Id));


                var model = Mapper.Map<BookEditFormVM>(entity);

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

        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(BookEditFormVM model)
        {
            var cache = HttpContext.Cache;
            var entity = cache.Get("book") as Book;

            if (entity == null)
            {
                try
                {
                    entity = this.bookLogic.GetBookById(model.Id);
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

                cache.Add("book", entity, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10), CacheItemPriority.Normal, null);
            }

            ViewBag.PublisherId = new List<SelectListItem> { new SelectListItem { Value = entity.Publisher.Id.ToString(), Text = entity.Publisher.PublisherName.ToString() } };

            ViewBag.AuthorsId = new MultiSelectList(entity.Authors.Select(x => new { Id = x.Id, FullName = x.FirstName + " " + x.LastName }), "Id", "FullName", selectedValues: entity.Authors.Select(x => x.Id));

            if (ModelState.IsValid)
            {
                try
                {
                    var result = this.bookLogic.Update(model.Id, model.Name, new HashSet<Author>(model.AuthorsId.Select(x => new Author { Id = x })), model.CityOfPublishing, new Publisher { Id = model.Id }, model.YearOfPublishing, model.NumberOfPages, model.Note, model.ISBN);

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

                logger.Info("Book was updated", "Presentation layer, class BookController, method ActionResult Edit(BookEditFormVM)");

                cache.Remove("book");
                return RedirectToAction("Item", "Common", new { Id = model.Id });


            }

            return View(model);
        }

    }
}