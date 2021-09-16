using SmartStore.Collections;
using SmartStore.Web.Framework.UI;


namespace SmartStore.WebHooks
{
    public class AdminMenu : AdminMenuProvider
    {
        protected override void BuildMenuCore(TreeNode<MenuItem> pluginsNode)
        {
            var menuItem = new MenuItem().ToBuilder()
                .Text("WebHooks")
                .ResKey("Plugins.FriendlyName.SmartStore.WebHooks")
                .Icon("far fa-images")

                .Action("ConfigurePlugin", "Plugin", new { systemName = "SmartStore.WebHooks", area = "Admin" })
                .ToItem();

            pluginsNode.Prepend(menuItem);

             menuItem = new MenuItem().ToBuilder()
                .Text("Download Royal Mail")
                .Icon("fab fa-google")
                .ResKey("Plugins.FriendlyName.SmartStore.WebHooks")
                .Action("PullRM", "WebHooks", new { systemName = Plugin.SystemName, area = "SmartStore.WebHooks" })
                .ToItem();
            pluginsNode.Prepend(menuItem);
        }

        public override int Ordinal
        {
            get
            {
                return -200;
            }
        }
    }
}
