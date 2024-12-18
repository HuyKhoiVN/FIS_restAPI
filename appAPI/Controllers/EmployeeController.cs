using appAPI.Service;
using appData.Models;
using appData.restException;
using Microsoft.AspNetCore.Mvc;

namespace appAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IBaseService<Employee> baseService, IEmployeeService employeeService) : base(baseService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getFullInfor")]
        public async Task<IActionResult> GetEmployeesFullInfor(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (items, totalCount) = await _employeeService.GetEmployeesFullInfor(pageNumber, pageSize);

                // Tạo đối tượng response bao gồm dữ liệu và tổng số bản ghi
                var response = new
                {
                    data = items,
                    totalCount = totalCount,
                    pageNumber = pageNumber,
                    pageSize = pageSize,
                    totalPages = (int)Math.Ceiling((double)totalCount / pageSize)
                };

                return Ok(response);
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "Đã xảy ra lỗi trong quá trình xử lý yêu cầu.",
                    data = ex.InnerException
                };
                return StatusCode(500, response);
            }
        }
    }
}