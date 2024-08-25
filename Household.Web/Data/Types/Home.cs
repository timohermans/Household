namespace Household.Web.Data.Types;

public class Home : IUserOwned
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public required string Name { get; set; }
    public string? OwnerId { get; set; }
}
