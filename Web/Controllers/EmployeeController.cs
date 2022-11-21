using Core.IService;
using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {

        
        #region Declaration

     
        private readonly IEmployeeService _employeeService;

       public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        #endregion


        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel? employeeModel)
        {
            _employeeService.Insert(employeeModel);
            return RedirectToAction("List");
            

        }
        #endregion


        #region List
        public IActionResult List()
        {
            var list = _employeeService.Get();
            return View(list);
        }
        #endregion


        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = _employeeService.Save(id);
            return View("Create",edit);
        }
        //[HttpPost]
        //public IActionResult Edit( EmployeeModel employeeModel)
        //{
        //    employeeService.Editform(employeeModel);
        //    return RedirectToAction("Create");
        //}
        #endregion


        #region Delete
        public IActionResult Delete(int id)
        {
           _employeeService.Remove(id);
           return RedirectToAction("List");
        }
        #endregion

    }
}
