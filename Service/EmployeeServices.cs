﻿using EmployeeForm.Core.IRepository;
using EmployeeForm.Core.IService;
using EmployeeForm.Core.Model;

namespace EmployeeForm.Services
{
    public class EmployeeServices:IEmployeeService
    {
        readonly IEmployeeRepository _employeeRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }
        #region Createform
        public void Createform(EmployeeModel? employeeModel)
        {
            _employeeRepository.Createform(employeeModel);
        }
        #endregion

      

        #region Listform

       
        public List<EmployeeModel> listform()
        {
             return _employeeRepository.listform();
        }
        #endregion

        public void deleteid(int id)
        {
            _employeeRepository.deleteid(id);
        }

        public EmployeeModel Save(int id)
        {
            return _employeeRepository.Save(id);
        }

    }
}
