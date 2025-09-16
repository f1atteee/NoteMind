using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace NoteMind.API.Controllers
{
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
    }
}
