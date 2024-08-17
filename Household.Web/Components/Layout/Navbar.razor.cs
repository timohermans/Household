using Household.Web.Server;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Household.Web.Components.Layout;

public partial class Navbar
{
    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;
    [Inject] public ILogger<Navbar> Logger { get; set; } = default!;

    private AuthenticationState authenticationState;

    protected override async Task OnInitializedAsync()
    {
        authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

        var user = authenticationState.User.Identity;

        //Logger.LogInformation(authenticationState.User?.Dump());
        Logger.LogInformation(user.Dump());
    }
}