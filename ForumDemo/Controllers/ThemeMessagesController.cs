using ForumDemo.Models.Business.Services;
using ForumDemo.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ForumDemo.Models.Business.Exceptions;

namespace ForumDemo.Controllers
{
    public class ThemeMessagesController : Controller
    {
        ThemeMessagesService messagesService = new ThemeMessagesService();
        public async Task<ActionResult> ModifyMessage(int? msgId, int? themeId)
        {
            if (msgId is null || themeId is null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            try
            {
                var msg = await messagesService.GetMessageById((int)msgId, User.Identity.GetUserId());
                ViewData["themeId"] = themeId;
                return View(msg);
            }
            catch(NotUserMessageException)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "It`s not your message");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ModifyMessage(ThemeMessageDto model, int themeId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await messagesService.ModifyMessage(model);
            return RedirectToAction("Detail", "Themes", new { id = themeId });
        }
    }
}