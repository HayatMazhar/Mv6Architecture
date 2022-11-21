using Core.Model;

namespace Core.IService
{
    public interface IEmployeeService
    {
        public void Insert(EmployeeModel? model);
        public void Remove(int id);
        List<EmployeeModel> Get();
        public EmployeeModel Save(int id);
    }
}
