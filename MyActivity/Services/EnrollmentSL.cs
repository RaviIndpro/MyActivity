using MyActivity.Data;
using MyActivity.Models;

namespace MyActivity.Services
{
    public class EnrollmentSL
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentSL(ApplicationDbContext context)
        {
            _context = context;
        }



        public bool CreateEnrollment(ActivityEnrollment employeeActivity)
        {
            try
            {
                _context.ActivityEnrollments.Add(employeeActivity);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEnrollment(ActivityEnrollment employeeActivity)
        {
            try
            {

                var enr = _context.ActivityEnrollments.Where(x => x.Id == employeeActivity.Id).FirstOrDefault();
                if (enr != null)
                {
                    _context.ActivityEnrollments.Remove(enr);
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

        public bool UpdateEnrollment(ActivityEnrollment employeeActivity)
        {
            try
            {
                var enr = _context.ActivityEnrollments.Where(x => x.Id == employeeActivity.Id).FirstOrDefault();
                if (enr != null)
                {

                    enr.Id = employeeActivity.Id;
                    enr.Id = employeeActivity.Id;
                    

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

        public ActivityEnrollment GetEnrollment(int id)
        {
            try
            {
                var enr = _context.ActivityEnrollments.Where(x => x.Id == id).FirstOrDefault();
                if (enr != null)
                {
                    return enr;
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

        public IList<ActivityEnrollment> AllEnrollment()
        {
            try
            {
                List<ActivityEnrollment> enr = _context.ActivityEnrollments.ToList();
                if (enr != null)
                {
                    return enr;
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
