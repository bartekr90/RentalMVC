using RentalMVC.Domain;

namespace RentalMVC.Application.Extensions;

public static class ClaimExtensions
{
    public static string GetClaimName(this ClaimType claimType) => claimType switch
    {
        ClaimType.Create => nameof(ClaimType.Create),
        ClaimType.Read => nameof(ClaimType.Read),
        ClaimType.Update => nameof(ClaimType.Update),
        ClaimType.Delete => nameof(ClaimType.Delete),
        ClaimType.Accepting => nameof(ClaimType.Accepting),
        _ => throw new ArgumentOutOfRangeException(nameof(claimType), claimType, null)
    };
}