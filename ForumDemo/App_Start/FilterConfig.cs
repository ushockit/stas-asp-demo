using ForumDemo.Models.Filters;
using System.Web;
using System.Web.Mvc;

namespace ForumDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ConfirmEmailAttribute());
        }
    }
}
