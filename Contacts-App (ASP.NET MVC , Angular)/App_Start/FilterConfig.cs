using System.Web;
using System.Web.Mvc;

namespace Contacts_App__ASP.NET_MVC___Angular_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
