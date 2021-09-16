using SmartStore.Web.Framework.Routing;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartStore.Plugin.WebHooks
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("SmartStore.WebHooks",
                 "Plugins/WebHooks/{action}",
                 new { controller = "WebHooks", action = "Configure" },
                 new[] { "SmartStore.WebHooks.Controllers" }
            )
            .DataTokens["area"] = "SmartStore.WebHooks";
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
