namespace FitnessApp.Web.Sessions;
public class IdleTimeoutMiddleware
{
    private readonly RequestDelegate _next;

    public IdleTimeoutMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var lastActivity = context.Session.GetString("LastActivity");

        if (!string.IsNullOrEmpty(lastActivity))
        {
            var lastActivityTime = DateTime.Parse(lastActivity);
            var idleTime = DateTime.Now - lastActivityTime;

            // If the idle time exceeds the configured timeout, log the user out
            if (idleTime.TotalMinutes >= 5)
            {
                // Perform logout or session expiration logic here.
                // For example:
                // context.SignOutAsync();
                // If using authentication
                
                // Clear the session
                context.Session.Clear();
                context.Response.Redirect("/Account/Logout"); // Redirect to logout page or login page
                return;
            }
        }

        await _next(context);
    }
}