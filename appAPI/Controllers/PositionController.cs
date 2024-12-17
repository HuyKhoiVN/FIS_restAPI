using appAPI.Service;
using appData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionController : BaseController<Position>
    {
        public PositionController(IBaseService<Position> baseService) : base(baseService)
        {
        }
    }
}
