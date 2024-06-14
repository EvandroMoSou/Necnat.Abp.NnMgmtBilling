using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Necnat.Abp.NnMgmtBilling.Pages;

public class IndexModel : NnMgmtBillingPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
