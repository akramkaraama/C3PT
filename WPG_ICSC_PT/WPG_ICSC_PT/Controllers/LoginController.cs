using BOL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Diagnostics;
using System.Web.Routing;

namespace WPG_ICSC_PT.Controllers
{
    public class LoginController : Controller
    {
        EmployeeSecurity empSecurty = new EmployeeSecurity();
        EmployeeBL empBL = new EmployeeBL();


        // GET: /Security/Login/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SignIn(Employee employee)
        {
            try
            {
                var currentEmp = empBL.GetALL().FirstOrDefault(x => x.Email == employee.Email && x.Password == employee.Password);
                var isUserValid = empSecurty.Login(employee.Email, employee.Password);
                if (isUserValid)
                {
                    ViewBag.Name = employee.Email;
                    //return RedirectToAction("Index", "Home", new { employee.Id});
                    return RedirectToAction("Index", new RouteValueDictionary(
                        new { Controller = "Home", Action = "Index", Id = currentEmp.Id }));
                }
                else
                {
                    TempData["Msg"] = "Login Failed ";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception E1)
            {
                TempData["Msg"] = "Login Failed " + E1.Message;
                return RedirectToAction("Index");
            }
        }        
    }
}