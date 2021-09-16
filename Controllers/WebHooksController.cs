using System;
using System.IO;
using System.Net;
using SmartStore.ComponentModel;
using SmartStore.Services;
using SmartStore.Services.Common;
using SmartStore.Web.Framework.Controllers;
using SmartStore.Web.Framework.Security;
using SmartStore.Web.Framework.Settings;
using SmartStore.Web.Framework.Theming;
using SmartStore.WebHooks.Models;
using SmartStore.WebHooks.Settings;
using System.Web.Mvc;
using SmartStore.Core.Security;


namespace SmartStore.Controllers
{
    public class WebHooksController : AdminControllerBase
    {
        private readonly ICommonServices _services;
        private readonly IGenericAttributeService _genericAttributeService;

        public WebHooksController(
            ICommonServices services,
            IGenericAttributeService genericAttributeService)
        {
            _services = services;
            _genericAttributeService = genericAttributeService;
        }

        [AdminAuthorize]
        [ChildActionOnly, LoadSetting]
        public ActionResult Configure(WebHooksSettings settings)
        {
            var model = MiniMapper.Map<WebHooksSettings, ConfigurationModel>(settings);

            return View(model);
        }

        [AdminAuthorize]
        [HttpPost, ChildActionOnly, SaveSetting]
        [ValidateAntiForgeryToken]
        public ActionResult Configure(ConfigurationModel model, WebHooksSettings settings)
        {
            if (!ModelState.IsValid)
            {
                return Configure(settings);
            }

            ModelState.Clear();
            MiniMapper.Map(model, settings);

            return RedirectToConfiguration("SmartStore.WebHooks");
        }

        [AdminAuthorize, AdminThemed]
        public ActionResult PullRM()
        {
            WebClient client = new WebClient();
            using (var stream = client.OpenRead(new Uri("http://martsmartstore.azurewebsites.net/api/UploadOrders")))
            using (var streamReader = new StreamReader(stream))
            {
                streamReader.ReadToEnd();
            }
            return RedirectToConfiguration("SmartStore.WebHooks");
        }


    }
}