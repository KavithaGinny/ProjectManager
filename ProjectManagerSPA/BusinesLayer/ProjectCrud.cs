using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerSPA.BusinesLayer
{
    public class ProjectCrud
    {
        public class ProjectCrud
        {
            /// <summary>
            /// Getting All the Project Information from the database
            /// </summary>
            /// <returns>List of Project</returns>
            public IEnumerable<Project> GetAllProject()
            {
                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    return PM.Projects.ToList();
                }
            }
            /// <summary>
            /// Getting the specific Task from the database
            /// </summary>
            /// <param name="ProjectId">ProjectId</param>
            /// <returns>Project</returns>
            public Project GetProject(int ProjectId)
            {

                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    Project i = PM.Projects.Where(x => x.ProjectId == ProjectId).FirstOrDefault();
                    return i;
                }
            }
            /// <summary>
            /// Add a particular Project to database
            /// </summary>
            /// <param name="i">Project</param>
            /// <returns>Status of the Operation</returns>
            public Project AddProject(Project i)
            {
                try
                {
                    using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                    {
                        PM.Configuration.ProxyCreationEnabled = false;
                        PM.Projects.Add(i);
                        PM.SaveChanges();

                        return i;
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            /// <summary>
            /// Update a particular Project to database.
            /// </summary>
            /// <param name="i">Project</param>
            /// <returns>Status of The Project</returns>
            public Project UpdateProject(Project i)
            {
                try
                {
                    using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                    {
                        PM.Configuration.ProxyCreationEnabled = false;
                        Project value = PM.Projects.Where(x => x.ProjectId == i.ProjectId).FirstOrDefault();
                        value.Priority = i.Priority;
                        value.StartDate = i.StartDate;
                        value.EndDate = i.EndDate;
                        value.ProjectDescription = i.ProjectDescription;
                        value.ManagerUserId = i.ManagerUserId;
                        PM.SaveChanges();
                        return value;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            /// <summary>
            /// Remove Project from the database
            /// </summary>
            /// <param name="ProjectId">ProjectId</param>
            /// <returns>Status of the Operation</returns>

            public Project RemoveProject(int ProjectId)
            {
                try
                {
                    using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                    {
                        PM.Configuration.ProxyCreationEnabled = false;
                        Project I = PM.Projects.Where(x => x.ProjectId == ProjectId).FirstOrDefault();

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
            /// Check if Project exist or not
            /// </summary>
            /// <param name="ProjectId"></param>
            /// <returns></returns>
            public bool IsProjectExist(int ProjectId)
            {

                using (ProjectManagerModel1Container PM = new ProjectManagerModel1Container())
                {
                    PM.Configuration.ProxyCreationEnabled = false;
                    bool Result = PM.Projects.Count(x => x.ProjectId == ProjectId) > 0;
                    return Result;
                }
            }
        }
}