using Core.Model;

namespace Core.IRepository
{
    public  interface IEmployeeRepository
    {
        public void Insert(EmployeeModel? model);
        List<EmployeeModel> Get();
        public void Remove(int id);
        public EmployeeModel Save(int id);
    }
}
