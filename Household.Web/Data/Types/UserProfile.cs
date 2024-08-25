namespace Household.Web.Data.Types;

public class UserProfile : IUserOwned
{
    public int Id { get; set; }
    public required string UserId { get; set; }
}
