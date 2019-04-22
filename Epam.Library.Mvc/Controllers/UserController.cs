using AutoMapper;
using BL_Contracts;
using BL_Contracts.Logic;
using Entities.Exceptions;
using Epam.Library.Mvc.Models;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace Epam.Library.Mvc.Controllers
{
    public class UserController : Controller
    {
        private IUserLogic logic;
        private readonly ILogger logger;

        public UserController(IUserLogic logic, ILogger logger)
        {
            this.logic = logic;
            this.logger = logger;
        }

        [ChildActionOnly]
        public ActionResult AdminIssues()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Edit(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var entity = this.logic.GetUserByLogin(login);

                var model = Mapper.Map<UserEditVM>(entity);

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

        [HttpPost]
        public ActionResult Edit(UserEditVM model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                this.logic.ChangeRole(model.Login, model.Role);
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

            return RedirectToAction("Index", "User");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            try
            {
                return View(this.logic.GetAll());
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserCreateVM model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (this.logic.Add(model.Login, role: "User", password: model.Password))
                    {
                        logger.Info("New user was created", "Presentation layer, class UserController, method ActionResult Register(UserCreateVM)");
                        return RedirectToAction("Index", "Common");
                    }
                    else
                    {
                        return View("Register", model);
                    }
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
                return View("Register", model);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult ChangeRole(UserEditVM model)
        {
            if (model == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                logic.ChangeRole(model.Login, model.Role);
                logger.Info("Role was changed", "Presentation layer, class UserController, method ActionResult ChangeRole(UserEditVM)");

                return RedirectToAction("Index");
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (this.logic.CanLogin(model.Login, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, createPersistentCookie: true);
                        logger.Info("A user just logged in", "Presentation layer, class UserController, method ActionResult Login(LoginVM model)");
                        return RedirectToAction("Index", "Common", new { id = 1 });
                    }
                    else
                    {
                        return View(model);
                    }
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

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult LoginBlock()
        {
            if (User.Identity.IsAuthenticated)
            {
                return PartialView("_LogoutPartial");
            }
            else
            {
                return PartialView("_LoginPartial");
            }
        }

        [ChildActionOnly]
        public ActionResult Toolbox()
        {
            if (Roles.IsUserInRole("Admin"))
            {
                return PartialView("_IndexToolboxAdminPartial");
            }

            if (Roles.IsUserInRole("User"))
            {
                return PartialView("_IndexToolboxUserPartial");
            }

            return null;
        }
    }
}