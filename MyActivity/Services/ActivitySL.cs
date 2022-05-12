using MyActivity.Data;
using MyActivity.Models;

namespace MyActivity.Services
{
    public class ActivitySL
    {
        private readonly ApplicationDbContext _context;

        public ActivitySL(ApplicationDbContext context)
        {
            _context = context;
        }



        public bool CreateActivity(EmployeeActivity activityMaster)
        {
            try
            {
                _context.EmployeeActivities.Add(activityMaster);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteActivity(EmployeeActivity activityMaster)
        {
            try
            {

                var act = _context.EmployeeActivities.Where(x => x.Id == activityMaster.Id).FirstOrDefault();
                if (act != null)
                {
                    _context.EmployeeActivities.Remove(act);
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

        public bool UpdateActivity(EmployeeActivity activityMaster)
        {
            try
            {
                var act = _context.EmployeeActivities.Where(x => x.Id == activityMaster.Id).FirstOrDefault();
                if (act != null)
                {

                    act.ActivityName = activityMaster.ActivityName;

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

        public EmployeeActivity GetActivity(int id)
        {
            try
            {
                var act = _context.EmployeeActivities.Where(x => x.Id == id).FirstOrDefault();
                if (act != null)
                {
                    return act;
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

        public IList<EmployeeActivity> AllActivity()
        {
            try
            {
                List<EmployeeActivity> act = _context.EmployeeActivities.ToList();
                if (act != null)
                {
                    return act;
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
