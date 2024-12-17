using appAPI.Service;
using appData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<Department>
    {
        public DepartmentController(IBaseService<Department> baseService) : base(baseService)
        {
        }
    }
}
