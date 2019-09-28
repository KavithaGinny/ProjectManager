using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSPA.BusinesLayer
{
    public class ParentTaskCrud
    {
        /// <summary>
        /// Getting All the Parent Information from the database
        /// </summary>
        /// <returns>List of Parent</returns>
        public IEnumerable<ParentTask> GetAllParentTask()
        {
            using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
            {
                PM.Configuration.ProxyCreationEnabled = false;
                return PM.ParentTasks.ToList();
            }
        }
        /// <summary>
        /// Getting the specific Task from the database
        /// </summary>
        /// <param name="ParentTaskId">ParentTaskId</param>
        /// <returns>Parent</returns>
        public ParentTask GetParentTask(int ParentTaskId)
        {

            using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
            {
                PM.Configuration.ProxyCreationEnabled = false;
                ParentTask i = PM.ParentTasks.Where(x => x.ParentId == ParentTaskId).FirstOrDefault();
                return i;
            }
        }
        /// <summary>
        /// Add a particular Parent to database
        /// </summary>
        /// <param name="i">Parent</param>
        /// <returns>Status of the Operation</returns>
        public ParentTask AddParentTask(ParentTask i)
        {
            try
            {
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    PM.ParentTasks.Add(i);
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
        /// Update a particular ParentTask to database.
        /// </summary>
        /// <param name="i">ParentTask</param>
        /// <returns>Status of The ParentTask</returns>
        public ParentTask UpdateParentTask(ParentTask i)
        {
            try
            {
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    ParentTask value = PM.ParentTasks.Where(x => x.ParentId == i.ParentId).FirstOrDefault();
                    value.ParentTask1 = i.ParentTask1;
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
        /// Remove Parent from the database
        /// </summary>
        /// <param name="ParentTaskId">ParentTaskId</param>
        /// <returns>Status of the Operation</returns>
        public ParentTask RemoveParentTask(int ParentTaskId)
        {
            try
            {
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    ParentTask I = PM.ParentTasks.Where(x => x.ParentId == ParentTaskId).FirstOrDefault();

                    PM.Entry(I).State = System.Data.Entity.EntityState.Deleted;
                    PM.SaveChanges();
                    return I;
                }


            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Check if ParentTask exist or not
        /// </summary>
        /// <param name="ParentTaskId"></param>
        /// <returns></returns>
        public bool IsParentTaskExist(int ParentTaskId)
        {

            using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
            {
                PM.Configuration.ProxyCreationEnabled = false;
                bool Result = PM.ParentTasks.Count(x => x.ParentId == ParentTaskId) > 0;
                return Result;
            }
        }
    }
}