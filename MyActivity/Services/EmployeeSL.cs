using MyActivity.Data;
using MyActivity.Models;

namespace MyActivity.Services
{
    public class EmployeeSL
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSL(ApplicationDbContext context)
        {
            _context = context;
        }



        public bool CreateEmployee(Employee employeeMaster)
        {
            try
            {
                _context.Employees.Add(employeeMaster);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(Employee employeeMaster)
        {
            try
            {

                var emp = _context.Employees.Where(x => x.Id == employeeMaster.Id).FirstOrDefault();
                if (emp != null)
                {
                    _context.Employees.Remove(emp);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateEmployee(Employee employeeMaster)
        {
            try
            {
                var emp = _context.Employees.Where(x => x.Id == employeeMaster.Id).FirstOrDefault();
                if (emp != null)
                {
                    //EmployeeMaster oldEmp = new EmployeeMaster();
                    //oldEmp.EmployeeID = employeeMaster.EmployeeID;
                    emp.FirstName = employeeMaster.FirstName;
                    emp.MobileNo = employeeMaster.MobileNo;
                    emp.EmailId = employeeMaster.EmailId;

                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                var emp = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
                if (emp != null)
                {
                    return emp;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList<Employee> AllEmployee()
        {
            try
            {
                List<Employee> emp = _context.Employees.ToList();
                if (emp != null)
                {
                    return emp;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
