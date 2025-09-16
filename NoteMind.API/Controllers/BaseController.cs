using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Security.Claims;

namespace NoteMind.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<T> : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<T> _logger;

        public BaseController(IMapper mapper, ILogger<T> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        protected long GetUserIdFromClaims()
        {
            var userIdClaim = User.FindFirst("Id");
            if (userIdClaim != null && long.TryParse(userIdClaim.Value, out long userId))
            {
                return userId;
            }

            throw new AuthenticationException();
        }

        protected List<string> GetUserRolesFromClaims()
        {
            return User.FindAll(ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();
        }


        protected string GetRequestToken()
        {
            return (HttpContext.Request.Headers["Authorization"]).ToString().Replace("Bearer ", "");
        }
    }
}
