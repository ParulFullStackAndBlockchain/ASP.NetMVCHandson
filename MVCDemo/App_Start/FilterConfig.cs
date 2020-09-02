using System.Web;
using System.Web.Mvc;

namespace MVCDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //the code below adds "HandleErrorAttribute" to GlobalFilterCollection.
            filters.Add(new HandleErrorAttribute());
        }
    }
}
