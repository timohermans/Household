
using Microsoft.AspNetCore.Components;

namespace Household.Web.Components.Pages;

public partial class Rooms
{
    [Inject] public NavigationManager NavigationManager { get; set; } = default!;

    protected override void OnInitialized()
    {

    }
}
