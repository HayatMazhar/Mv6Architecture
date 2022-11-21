using Core.IRepository;
using Core.IService;
using Core.Model;

namespace Services
{
    public class EmployeeServices:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }
        
        public void Insert(EmployeeModel? employeeModel)
        {
            _employeeRepository.Insert(employeeModel);
        }
      
        public List<EmployeeModel> Get()
        {
             return _employeeRepository.Get();
        }

        public void Remove(int id)
        {
            _employeeRepository.Remove(id);
        }

        public EmployeeModel Save(int id)
        {
            return _employeeRepository.Save(id);
        }

    }
}
