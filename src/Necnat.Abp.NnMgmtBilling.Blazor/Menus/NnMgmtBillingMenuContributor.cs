using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Necnat.Abp.NnMgmtBilling.Blazor.Menus;

public class NnMgmtBillingMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(NnMgmtBillingMenus.Prefix, displayName: "NnMgmtBilling", "/NnMgmtBilling", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
