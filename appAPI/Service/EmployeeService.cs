using appData.Models;
using appData.ModelsDTO;
using appData.Repository;
using System.Drawing.Printing;

namespace appAPI.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IBaseRepository<Position> _positionRepository;
        private readonly IBaseRepository<Department> _departmentRepository;

        public EmployeeService(IBaseRepository<Employee> repository, IBaseRepository<Position> positionRepository, IBaseRepository<Department> departmentRepository) : base(repository)
        {
            _positionRepository = positionRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<(List<EmployeeDTO> Items, int TotalCount)> GetEmployeesFullInfor(int pageNumber, int pageSize)
        {
            //var employees = await _repository.GetAllAsync();

            var (employees, totalCount) = await _repository.GetPagingAsync(pageNumber, pageSize);

            var employeeDtoList = new List<EmployeeDTO>();

            foreach (var employee in employees)
            {
                var department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
                var position = await _positionRepository.GetByIdAsync(employee.PositionId);

                var employeeDTO = new EmployeeDTO
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Gender = employee.Gender,
                    DateOfBirth = employee.DateOfBirth,
                    HireDate = employee.HireDate,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = department.DepartmentName,
                    PositionId = department.DepartmentId,
                    PositionName = position.PositionName,
                    CreatedDate = employee.CreatedDate,
                    Active = employee.Active
                };

                employeeDtoList.Add(employeeDTO);
            }

            return (employeeDtoList, totalCount);
        }
    }
}
