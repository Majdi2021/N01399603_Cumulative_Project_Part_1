using System.Web;
using System.Web.Mvc;

namespace N01366903_Cumulative_Part_1_Att2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
