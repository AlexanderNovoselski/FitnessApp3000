using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

public static class RoleHelper
{
    public static async Task<bool> IsUserInRoleAsync(UserManager<User> userManager, ClaimsPrincipal user, string role)
    {
        var userId = userManager.GetUserId(user);
        var currentUser = await userManager.FindByIdAsync(userId);
        var isInRole = await userManager.IsInRoleAsync(currentUser, role);
        return isInRole;
    }
}