using EmployeeForm.Core.IRepository;
using EmployeeForm.Core.Model;
using EmployeeForm.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Adding new details
        public void Createform(EmployeeModel? employeeModel)
        {
            if (employeeModel == null) return;
            using var entity = new Registration_FormContext();
            if (employeeModel.ID == 0)
            {
                var employeeDetail = new EmployeeDetail
                {
                    Employee_Name = employeeModel.Name,
                    Age = employeeModel.age,
                    Gender = employeeModel.gender,
                    Qualification = employeeModel.qualification,
                    Job_Role = employeeModel.JobRole,
                    Experience = employeeModel.experience,
                    Address = employeeModel.address,
                    Phone_No = employeeModel.PhoneNo,
                    Email = employeeModel.email,
                    Password = employeeModel.password,
                    Conform_Password = employeeModel.Re_Password,
                    Created_Time_Stamp = DateTime.Now,
                    Updated_Time_Stamp = DateTime.Now
                };
                entity.Add(employeeDetail);
                entity.SaveChanges();

            }

            else
            {
                var check = entity.EmployeeDetail.SingleOrDefault(m => m.Employee_ID == employeeModel.ID);
                if (check != null)
                {
                    check.Employee_Name = employeeModel.Name;
                    check.Age = employeeModel.age;
                    check.Gender = employeeModel.gender;
                    check.Qualification = employeeModel.qualification;
                    check.Job_Role = employeeModel.JobRole;
                    check.Experience = employeeModel.experience;
                    check.Address = employeeModel.address;
                    check.Phone_No = employeeModel.PhoneNo;
                    check.Email = employeeModel.email;
                    check.Password = employeeModel.password;
                    check.Conform_Password = employeeModel.Re_Password;
                }

                entity.SaveChanges();
            }
        }
            #endregion

            #region Assigning values in Edit page
            public EmployeeModel Save(int id)
            {
                using var entity = new Registration_FormContext();
                var employeeModel = new EmployeeModel();
                var save = entity.EmployeeDetail.SingleOrDefault(m => m.Employee_ID == id);

                if (save != null)
                {
                    employeeModel.ID = save.Employee_ID;
                    employeeModel.Name = save.Employee_Name;
                    employeeModel.age = save.Age;
                    employeeModel.gender = save.Gender;
                    employeeModel.qualification = save.Qualification;
                    employeeModel.JobRole = save.Job_Role;
                    employeeModel.experience = save.Experience;
                    employeeModel.address = save.Address;
                    employeeModel.PhoneNo = save.Phone_No;
                    employeeModel.email = save.Email;
                    employeeModel.password = save.Password;
                    employeeModel.Re_Password = save.Conform_Password;
                }

                entity.SaveChanges();


                return employeeModel;
            }
            #endregion

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

            #region Listing the Details

            public List<EmployeeModel> listform()
            {
                var employeeList = new List<EmployeeModel>();
                using var entity = new Registration_FormContext();
                var list = entity.EmployeeDetail.ToList();
                employeeList.AddRange(list.Select(item => new EmployeeModel
                {
                    ID = item.Employee_ID,
                    Name = item.Employee_Name,
                    age = item.Age,
                    gender = item.Gender,
                    qualification = item.Qualification,
                    JobRole = item.Job_Role,
                    experience = item.Experience,
                    address = item.Address,
                    PhoneNo = item.Phone_No,
                    email = item.Email,
                    password = item.Password,
                    Re_Password = item.Conform_Password
                }));
                return employeeList;
            }
            #endregion

            #region Deleting detail
            public void deleteid(int id)
            {
                using var entity = new Registration_FormContext();
                var delete = entity.EmployeeDetail.SingleOrDefault(m => m.Employee_ID == id);
                if (delete == null) return;
                delete.Is_Deleted = true;
                entity.SaveChanges();
            }
            #endregion
        }
    }
