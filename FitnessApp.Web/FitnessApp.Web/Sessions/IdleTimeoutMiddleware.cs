using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

public class IdleTimeoutMiddleware
{
    private readonly RequestDelegate _next;
    private readonly TimeSpan _idleTimeout = TimeSpan.FromMinutes(15);

    public IdleTimeoutMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context?.User.Identity.IsAuthenticated == true)
        {
            var lastActivityString = context.Session.GetString("LastActivity");
            if (DateTime.TryParse(lastActivityString, out var lastActivity))
            {
                var idleTime = DateTime.UtcNow - lastActivity;

                if (idleTime >= _idleTimeout)
                {
                    context.Session.Clear();
                    await LogoutAndRedirect(context);
                    return;
                }
            }

            // Update the LastActivity in the session with the current time on each request
            context.Session.SetString("LastActivity", DateTime.UtcNow.ToString());
        }

        await _next(context);
    }

    private async Task LogoutAndRedirect(HttpContext context)
    {
        var signInManager = context.RequestServices.GetRequiredService<SignInManager<User>>();
        await signInManager.SignOutAsync();
        context.Response.Redirect("/Identity/Account/Login");
    }
}
