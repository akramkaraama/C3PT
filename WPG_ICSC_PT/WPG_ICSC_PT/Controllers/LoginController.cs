using BOL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Diagnostics;

namespace WPG_ICSC_PT.Controllers
{
    public class LoginController : Controller
    {
        EmployeeSecurity empSecurty = new EmployeeSecurity();


        // GET: /Security/Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn(Employee employee)
        {
            try
            {
                var isUserValid = empSecurty.Login(employee.Email, employee.Password);
                if (isUserValid)
                {
                    ViewBag.Name = employee.Email;
                    return RedirectToAction("Index", "Home");
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