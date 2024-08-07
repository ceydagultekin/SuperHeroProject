namespace SuperHeroProject.Middlewares
{
    public class UserAgentCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<string> _allowedUserAgents;

        public UserAgentCheckMiddleware(RequestDelegate next, List<string> allowedUserAgents)
        {
            _next = next;
            _allowedUserAgents = allowedUserAgents;
        }
        public async Task Invoke(HttpContext context)
        {
          if(!context.Request.Headers.TryGetValue("User-Agent", out var UserAgent ))
          {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Bu tarayıcı izinli değil.");
                return;
          }

            var userAgentString = UserAgent.ToString().ToLower();
            if(!_allowedUserAgents.Any(ua => userAgentString.Contains(ua.ToLower())))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Bu tarayıcı izinli değil.");
                return;
            }
            await _next(context);

        }
    }
}
