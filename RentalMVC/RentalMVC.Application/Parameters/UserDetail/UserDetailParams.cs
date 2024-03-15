using RentalMVC.Domain.Interfaces.ValueObjects;

namespace RentalMVC.Application.Parameters.UserDetail;

public class UserDetailParams
{
    public required string CreatorId { get; set; }
    public CancellationToken Token { get; set; } = CancellationToken.None;
    public UserId GetUserId => new(CreatorId);
}
