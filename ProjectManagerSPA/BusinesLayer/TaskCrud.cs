using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSPA.BusinesLayer
{
    public class TaskCrud
    {
        /// <summary>
        /// Getting All the Task Information from the database
        /// </summary>
        /// <returns>List of TaskInformation</returns>
        public IEnumerable<TaskInformation> GetAllTasks()
        {
            using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
            {
                PM.Configuration.ProxyCreationEnabled = false;
                return PM.TaskInformations.ToList();
            }
        }
        /// <summary>
        /// Getting the specific Task from the database
        /// </summary>
        /// <param name="TaskId">TaskId</param>
        /// <returns>TaskInformation</returns>
        public TaskInformation GetTask(int TaskId)
        {

            using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
            {
                PM.Configuration.ProxyCreationEnabled = false;
                TaskInformation i = PM.TaskInformations.Where(x => x.TaskId == TaskId).FirstOrDefault();
                return i;
            }
        }
        /// <summary>
        /// Add a particular task to database
        /// </summary>
        /// <param name="i">TaskInformation</param>
        /// <returns>Status of the Operation</returns>
        public TaskInformation AddTask(TaskInformation i)
        {
            try
            {
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    PM.TaskInformations.Add(i);
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
        /// Update a particular task to database.
        /// </summary>
        /// <param name="i">TaskInformation</param>
        /// <returns>Status of The Task</returns>
        public TaskInformation UpdateTask(TaskInformation i)
        {
            try
            {
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    TaskInformation value = PM.TaskInformations.Where(x => x.TaskId == i.TaskId).FirstOrDefault();
                    value.Priority = i.Priority;
                    value.StartDate = i.StartDate;
                    value.EndDate = i.EndDate;
                    value.ParentId = i.ParentId;

                    value.TaskDescription = i.TaskDescription;
                    value.IsTaskCompleted = i.IsTaskCompleted;
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
        /// Remove Task from the database
        /// </summary>
        /// <param name="TaskId">TaskId</param>
        /// <returns>Status of the Operation</returns>
        public TaskInformation RemoveTask(int TaskId)
        {
            try
            {
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    TaskInformation I = PM.TaskInformations.Where(x => x.TaskId == TaskId).FirstOrDefault();

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
        /// Check if task exist or not
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        public bool IsTaskExist(int TaskId)
        {

            using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
            {
                PM.Configuration.ProxyCreationEnabled = false;
                bool Result = PM.TaskInformations.Count(x => x.TaskId == TaskId) > 0;
                return Result;
            }
        }
    }
}