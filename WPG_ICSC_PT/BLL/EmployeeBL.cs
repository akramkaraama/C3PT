using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBL
    {
        private EmployeeDb employeeDb;

        public EmployeeBL()
        {
            employeeDb = new EmployeeDb();
        }
        public IEnumerable<Employee> GetALL()
        {
            return employeeDb.GetALL();
        }
        public Employee GetByID(int Id)
        {
            return employeeDb.GetByID(Id);
        }
        public void Insert(Employee employee)
        {
            employeeDb.Insert(employee);
        }
        public void Delete(int Id)
        {
            employeeDb.Delete(Id);
        }
        public void Update(Employee employee)
        {
            employeeDb.Update(employee);
        }
    }
}
