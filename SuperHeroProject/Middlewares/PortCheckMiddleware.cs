namespace SuperHeroProject.Middlewares
{
    public class PortCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly int _port;
        public PortCheckMiddleware(RequestDelegate next, int port)
        {
            _next=next;
            _port=port;
        }
        public async Task Invoke(HttpContext context)
        {
            if(context.Connection.LocalPort != _port)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Bu port izinli değil !");
                return;
            }
            await _next(context);
        }
    }
}
