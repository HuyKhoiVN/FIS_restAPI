using appAPI.Service;
using appData.Models;
using Microsoft.AspNetCore.Mvc;

namespace appAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        public EmployeeController(IBaseService<Employee> baseService) : base(baseService)
        {
        }
    }
}
