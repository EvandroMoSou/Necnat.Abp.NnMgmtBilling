using Necnat.Abp.NnMgmtBilling.Localization;
using Necnat.Abp.NnMgmtBilling.Permissions;
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

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<NnMgmtBillingResource>();

        bool displaybillingMenu = false;
        var billingMenu = new ApplicationMenuItem(
            NnMgmtBillingMenus.Prefix,
            l["Menu:NnMgmtBilling"],
            icon: "fas fa-dollar-sign"
        );

        bool displayBillingConfiguracaoMenu = false;
        var billingConfiguracaoMenu = new ApplicationMenuItem(
            NnMgmtBillingMenus.Configuration,
            l["Menu:NnMgmtBilling:Configuration"],
            order: 1
        );

        if (await context.IsGrantedAsync(NnMgmtBillingPermissions.PrmBillingEndpoint.Default))
        {
            billingConfiguracaoMenu.AddItem(new ApplicationMenuItem(
                NnMgmtBillingMenus.Configuration_BillingEndpoint,
                l["Menu:NnMgmtBilling:Configuration:BillingEndpoint"],
                url: "/NnMgmtBilling/Configuration/BillingEndpoints",
                order: 1
            ));
            displayBillingConfiguracaoMenu = true;
        }

        if (await context.IsGrantedAsync(NnMgmtBillingPermissions.PrmBillingClient.Default))
        {
            billingConfiguracaoMenu.AddItem(new ApplicationMenuItem(
                NnMgmtBillingMenus.Configuration_BillingClient,
                l["Menu:NnMgmtBilling:Configuration:BillingClient"],
                url: "/NnMgmtBilling/Configuration/BillingClients",
                order: 2
            ));
            displayBillingConfiguracaoMenu = true;
        }

        if (await context.IsGrantedAsync(NnMgmtBillingPermissions.PrmBillingContract.Default))
        {
            billingConfiguracaoMenu.AddItem(new ApplicationMenuItem(
                NnMgmtBillingMenus.Configuration_BillingContract,
                l["Menu:NnMgmtBilling:Configuration:BillingContract"],
                url: "/NnMgmtBilling/Configuration/BillingContracts",
                order: 2
            ));
            displayBillingConfiguracaoMenu = true;
        }

        if (await context.IsGrantedAsync(NnMgmtBillingPermissions.PrmSku.Default))
        {
            billingConfiguracaoMenu.AddItem(new ApplicationMenuItem(
                NnMgmtBillingMenus.Configuration_Sku,
                l["Menu:NnMgmtBilling:Configuration:Sku"],
                url: "/NnMgmtBilling/Configuration/Skus",
                order: 3
            ));
            displayBillingConfiguracaoMenu = true;
        }

        if (displayBillingConfiguracaoMenu)
            billingMenu.AddItem(billingConfiguracaoMenu);

        if (await context.IsGrantedAsync(NnMgmtBillingPermissions.PrmBillingEndpoint.CallEndpoint))
        {
            billingMenu.AddItem(new ApplicationMenuItem(
                NnMgmtBillingMenus.Dashboard,
                l["Menu:NnMgmtBilling:Dashboard"],
                url: "/NnMgmtBilling/Dashboard",
                order: 2
            ));
            displaybillingMenu = true;
        }

        if (displaybillingMenu || displayBillingConfiguracaoMenu)
            context.Menu.AddItem(billingMenu);
    }
}
