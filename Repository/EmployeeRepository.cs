using Core.IRepository;
using Core.Model;
using EmployeeForm.Entity;

namespace Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Insert(EmployeeModel? employeeModel)
        {
            if (employeeModel == null) return;
            using var entity = new Registration_FormContext();
            if (employeeModel.Id == 0)
            {
                var employeeDetail = new EmployeeDetail
                {
                    Employee_Name = employeeModel.Name,
                    Age = employeeModel.Age,
                    Gender = employeeModel.Gender,
                    Qualification = employeeModel.Qualification,
                    Job_Role = employeeModel.JobRole,
                    Experience = employeeModel.Experience,
                    Address = employeeModel.Address,
                    Phone_No = employeeModel.PhoneNo,
                    Email = employeeModel.Email,
                    Password = employeeModel.Password,
                    Conform_Password = employeeModel.ConfirmPassword,
                    Created_Time_Stamp = DateTime.Now,
                    Updated_Time_Stamp = DateTime.Now
                };
                entity.Add(employeeDetail);
                entity.SaveChanges();

            }

            else
            {
                var check = entity.EmployeeDetail.SingleOrDefault(m => m.Employee_ID == employeeModel.Id);
                if (check != null)
                {
                    check.Employee_Name = employeeModel.Name;
                    check.Age = employeeModel.Age;
                    check.Gender = employeeModel.Gender;
                    check.Qualification = employeeModel.Qualification;
                    check.Job_Role = employeeModel.JobRole;
                    check.Experience = employeeModel.Experience;
                    check.Address = employeeModel.Address;
                    check.Phone_No = employeeModel.PhoneNo;
                    check.Email = employeeModel.Email;
                    check.Password = employeeModel.Password;
                    check.Conform_Password = employeeModel.ConfirmPassword;
                }

                entity.SaveChanges();
            }
        }

        public EmployeeModel Save(int id)
        {
            using var entity = new Registration_FormContext();
            var employeeModel = new EmployeeModel();
            var save = entity.EmployeeDetail.SingleOrDefault(m => m.Employee_ID == id);

            if (save != null)
            {
                employeeModel.Id = save.Employee_ID;
                employeeModel.Name = save.Employee_Name;
                employeeModel.Age = save.Age;
                employeeModel.Gender = save.Gender;
                employeeModel.Qualification = save.Qualification;
                employeeModel.JobRole = save.Job_Role;
                employeeModel.Experience = save.Experience;
                employeeModel.Address = save.Address;
                employeeModel.PhoneNo = save.Phone_No;
                employeeModel.Email = save.Email;
                employeeModel.Password = save.Password;
                employeeModel.ConfirmPassword = save.Conform_Password;
            }

            entity.SaveChanges();


            return employeeModel;
        }
        //#region Editing Details

        //public void Editform(EmployeeModel employeeModel)
        //{

        //    using (Registration_FormContext entity = new Registration_FormContext())
        //    {

        //        var check = entity.EmployeeDetail.Where(m => m.Employee_ID == employeeModel.ID).SingleOrDefault();
        //        if (check != null)
        //        {
        //            check.Employee_Name = employeeModel.Name;
        //            check.Age = employeeModel.age;
        //            check.Gender = employeeModel.gender;
        //            check.Qualification = employeeModel.qualification;
        //            check.Job_Role = employeeModel.JobRole;
        //            check.Experience = employeeModel.experience;
        //            check.Address = employeeModel.address;
        //            check.Phone_No = employeeModel.PhoneNo;
        //            check.Email = employeeModel.email;
        //            check.Password = employeeModel.password;
        //            check.Conform_Password = employeeModel.Re_Password;

        //            entity.SaveChanges();
        //        }

        //    }

        //}
        //#endregion

        public List<EmployeeModel> Get()
        {
            var employeeList = new List<EmployeeModel>();
            using var entity = new Registration_FormContext();
            var list = entity.EmployeeDetail.Where(m => m.Is_Deleted == false).ToList();
            employeeList.AddRange(list.Select(item => new EmployeeModel
            {
                Id = item.Employee_ID,
                Name = item.Employee_Name,
               Age = item.Age,
                Gender = item.Gender,
                Qualification = item.Qualification,
                JobRole = item.Job_Role,
                Experience = item.Experience,
                Address = item.Address,
                PhoneNo = item.Phone_No,
                Email = item.Email,
                Password = item.Password,
                ConfirmPassword = item.Conform_Password
            }));
            return employeeList;
        }

        
        public void Remove(int id)
        {
            using var entity = new Registration_FormContext();
            var delete = entity.EmployeeDetail.SingleOrDefault(m => m.Employee_ID == id);
            if (delete == null) return;
            delete.Is_Deleted = true;
            entity.SaveChanges();
        }
    }
}
