using EnlacesGymsWeb.Server.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EnlacesGymsWeb.Server.Middlewares
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private IUserService _userService;

        public JWTMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            _userService = userService;
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await attachAccountToContext(context, token);

            }
            await _next(context);
        }
        private async Task attachAccountToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JWTSettings:Key"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    //TokenDecryptionKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    // Add these...
                    ValidIssuer = _configuration["JWTSettings:Issuer"],
                    ValidAudience = _configuration["JWTSettings:Audience"],
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var UserAccountType = jwtToken.Claims.First(x => x.Type == "Type").Value;


                var name = jwtToken.Claims.First(x => x.Type == "Name").Value;
                var password = jwtToken.Claims.First(x => x.Type == "Password").Value;
                //var external = _userService.IsValidUserInformation(new Application.Helpers.LoginModel { UserName = name, Password = password });
                context.Items["Email"] = name;




            }
            catch
            {
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
            }
        }
    }
}
