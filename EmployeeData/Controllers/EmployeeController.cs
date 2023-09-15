using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeLib.Repo;
using EmployeeLib.Model;

namespace EmployeeData.Controllers
{
    public class EmployeeController : Controller
    {
       public EmployeeRepo obj;
        public EmployeeController()
        {
            obj = new EmployeeRepo();
        }
        public ActionResult List()
        {
            return View("ListEmployeedata", new List<EmployeeModel>(obj.GetEmployeeData()));
        }
        public ActionResult Create()
        {
            var model = new EmployeeModel();
            return View("CreateEmployeedata", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    obj.InsertEmployeeData(data);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("CreateEmployeedata", data);

                }
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int Empid)
        {
            var result = obj.GetEmployeeData(Empid);
            return View("EditEmployeeData", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Empid, EmployeeModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                
                    obj.UpdateEmployeeData(data);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("EditEmployeeData", data);

                }
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Delete(int Empid)
        {

            var result = obj.GetEmployeeData(Empid);

            return View("DeleteEmployeedata", result);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int Empid)
        {
            try
            {
                obj.DeleteEmployeeData(Empid);
                return RedirectToAction(nameof(List));
             
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
