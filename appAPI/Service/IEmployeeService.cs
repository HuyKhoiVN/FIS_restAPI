using appData.Models;
using appData.ModelsDTO;

namespace appAPI.Service
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<(List<EmployeeDTO> Items, int TotalCount)> GetEmployeesFullInfor(int pageNumber, int pageSize);
    }
}
