using RentalMVC.Domain;

namespace RentalMVC.Application.Extensions;

public static class RoleExtensions
{
    public static string GetRoleName(this Role role) => role switch
    {
        Role.Admin => nameof(Role.Admin),
        Role.Lessor => nameof(Role.Lessor),
        Role.Employee => nameof(Role.Employee),
        Role.SuperEmployee => nameof(Role.SuperEmployee),
        Role.Client => nameof(Role.Client),
        _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
    };
}