using ForumDemo.Models.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ForumDemo.Models.DTO;
using ForumDemo.Models.Business.Exceptions;

namespace ForumDemo.Controllers
{
    [Authorize]
    public class ThemesController : Controller
    {
        ForumThemesService themesService = new ForumThemesService();
        public async Task<ActionResult> Index()
        {
            return View(await themesService.GetAllThemes());
        }

        public async Task<ActionResult> Detail(int? id)
        {
            if (id is null)
            {
                return HttpNotFound();
            }
            return View(await themesService.GetTheme((int)id));
        }

        public async Task<ActionResult> MyThemes()
        {
            var userId = User.Identity.GetUserId();
            var userThemes = await themesService.GetUserThemes(userId);
            return View(userThemes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ForumThemeDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //Save to database
            await themesService.CreateTheme(model, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return HttpNotFound();
            }

            try
            {
                await themesService.RemoveTheme((int)id, User.Identity.GetUserId());
                return RedirectToAction("MyThemes");
            }
            catch(NotUserThemeException)
            {
                return new HttpNotFoundResult("It`s not your theme");
            }
        }


        public ActionResult AddMessage(int? themeId)
        {
            if (themeId is null)
            {
                return HttpNotFound();
            }
            ViewData["themeId"] = themeId;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddMessage(ThemeMessageDto model, int themeId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await themesService.AddMessage(model, themeId, User.Identity.GetUserId());
            return RedirectToAction("Detail", new { id = themeId });
        }
    }
}