using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class  EmployeeSecurity
    {
        WPG_ConferenceEntities _db = new WPG_ConferenceEntities();

        public bool Login(string userName , string password)
        {
            var userFound = IsUserExsist(userName, password);
            return userFound;
        }

        public bool IsUserExsist(string userName, string userPassword)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Email.ToLower() == userName.ToLower() && x.Password == userPassword);
            return emp != null;
        }

      public bool IsAdmin(string userName)
        {
            return false;
        }
        public bool IsBusinessExec(string userName)
        {
            return false;
        }

        public bool IsExecutive(string userName)
        {
            return false;
        }

        public bool IsLeasingAgent(string userName)
        {
            return false;
        }

    }
}
