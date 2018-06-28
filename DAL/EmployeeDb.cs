using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDb
    {
        private WPG_ConferenceEntities db;

        public EmployeeDb()
        {
            db = new WPG_ConferenceEntities();
        }
        public IEnumerable<Employee> GetALL()
        {
            return db.Employees.ToList();
        }
        public Employee GetByID(int Id)
        {
            return db.Employees.Find(Id);
        }
        public void Insert(Employee employee)
        {
            db.Employees.Add(employee);
            Save();
        }
        public void Delete(int Id)
        {
            Employee employee = db.Employees.Find(Id);
            db.Employees.Remove(employee);
            Save();
        }
        public void Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
