using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using ForumDemo.Models.EF.Entites;

namespace ForumDemo.Models.EF
{
    public class ForumInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var defaultUser = new ApplicationUser
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com"
            };
            var defaultPassword = "Admin_2021";
            userManager.Create(defaultUser, defaultPassword);

            var user1 = new ApplicationUser
            {
                Email = "user1@gmail.com",
                UserName = "user1@gmail.com"
            };
            var user1Password = "User1_2021";
            userManager.Create(user1, user1Password);


            var themeMsg1 = new ThemeMessage
            {
                Text = "Some text 1",
                Publisher = user1
            };
            var themeMsg2 = new ThemeMessage
            {
                Text = "Some text 2",
                Publisher = user1
            };

            var forumTheme1 = new ForumTheme
            {
                Title = "Some title",
                Description = "Some description 1",
                Messages = new List<ThemeMessage> { themeMsg1, themeMsg2 },
                Owner = defaultUser,
                IsPublished = true,
                PublishDate = DateTime.Now
            };

            context.ForumThemes.Add(forumTheme1);

            context.SaveChanges();
        }
    }
}