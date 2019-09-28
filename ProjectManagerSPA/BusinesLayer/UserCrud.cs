using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSPA.BusinesLayer
{
    public class UserCrud
    {
        /// <summary>
        /// Getting All the User Information from the database
        /// </summary>
        /// <returns>List of User</returns>
        public IEnumerable<User> GetAllUser()
        {
            using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
            {
                PM.Configuration.ProxyCreationEnabled = false;
                return PM.Users.ToList();
            }
        }
        /// <summary>
        /// Getting the specific User from the database
        /// </summary>
        /// <param name="UserId">UserId</param>
        /// <returns>User</returns>
        public User GetUser(int UserId)
        {

            using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
            {
                PM.Configuration.ProxyCreationEnabled = false;
                User i = PM.Users.Where(x => x.UserId == UserId).FirstOrDefault();
                return i;
            }
        }
        /// <summary>
        /// Add a particular User to database
        /// </summary>
        /// <param name="i">User</param>
        /// <returns>Status of the Operation</returns>
        public User AddUser(User i)
        {
            try
            {
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    PM.Users.Add(i);
                    PM.SaveChanges();

                    return i;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Update a particular User to database.
        /// </summary>
        /// <param name="i">User</param>
        /// <returns>Status of The User</returns>
        public User UpdateUser(User i)
        {
            try
            {
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    User value = PM.Users.Where(x => x.UserId == i.UserId).FirstOrDefault();
                    value.ProjectId = i.ProjectId;
                    value.LastName = i.LastName;
                    value.FirstName = i.FirstName;
                    value.EmployeeId = i.EmployeeId;
                    PM.SaveChanges();
                    return i;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Remove User from the database
        /// </summary>
        /// <param name="UserId">UserId</param>
        /// <returns>Status of the Operation</returns>
        public User RemoveUser(int UserId)
        {
            try
            {
                User I = null;
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    I = PM.Users.Where(x => x.UserId == UserId).FirstOrDefault();

                    PM.Entry(I).State = System.Data.Entity.EntityState.Deleted;
                    PM.SaveChanges();

                }
                return I;
            }

            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Check if User exist or not
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool IsUserExist(int UserId)
        {

            using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
            {
                PM.Configuration.ProxyCreationEnabled = false;
                bool Result = PM.Users.Count(x => x.UserId == UserId) > 0;
                return Result;
            }
        }
    }
}