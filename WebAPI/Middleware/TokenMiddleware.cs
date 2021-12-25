using Application.Features.Auth.Queries;
using Application.Services.Implementation;
using MediatR;

namespace WebAPI.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMediator mediator)
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            if (token != null && token != "")
            {
                var tokenHandler = new JwtService();
                var username = tokenHandler.ValidateToken(token);

                if(username == null)
                {
                    await _next(context);
                    return;
                }

                var user = await mediator.Send(new QueryUserByNameCommand(username));

                context.Items["User"] = user;
            }
            await _next(context);
        }
    }
}