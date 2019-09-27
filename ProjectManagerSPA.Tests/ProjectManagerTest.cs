using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ProjectManagerSPA.Controllers;
using System.Collections.Generic;
using ProjectManagerSPA.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;

namespace ProjectManagerSPA.Tests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        [Test]
        public void TestGetUsersMethod()
        {
            UsersController uc = new UsersController();
            IQueryable<User> users = uc.GetUsers();            
            Assert.IsNotNull(users);
        }
        [Test]
        public void TestPostUsersMethod()
        {
            UsersController uc = new UsersController();
            User user = new User();
            user.FirstName = "Ram";
            user.LastName = "Vignesh";            
            user.EmployeeID = "1000";
            IHttpActionResult httpActionResult = uc.PostUser(user);
            var posResult = httpActionResult as CreatedAtRouteNegotiatedContentResult<User>;
            Assert.IsNotNull(posResult);

        }
        [Test]
        public void TestGetUserMethod()
        {
            UsersController uc = new UsersController();
            IHttpActionResult httpActionResult = uc.GetUser(1);
            var posResult = httpActionResult as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(posResult);
            Assert.IsNotNull(posResult.Content);
            Assert.AreEqual(1, posResult.Content.UserID);

        }
        [Test]
        public void TestPutUserMethod()
        {
            UsersController uc = new UsersController();
            
            IHttpActionResult actionResult = uc.PutUser(1,new User { UserID=1, FirstName = "Ram",LastName="Vignesh",EmployeeID="1000" });
            var contentResult = actionResult as NegotiatedContentResult<User>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("1000", contentResult.Content.EmployeeID);
        }
        [Test]
        public void TestDeleteUserMethod()
        {
            UsersController uc = new UsersController();
            IHttpActionResult httpActionResult = uc.DeleteUser(4);


            var posResult = httpActionResult as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(posResult);
            Assert.IsNotNull(posResult.Content);
            Assert.AreEqual(4, posResult.Content.UserID);

        }

        [Test]
        public void TestGetTasksMethod()
        {
            TasksController tc = new TasksController();
            IQueryable<Task> tasks = tc.GetTasks();
            Assert.IsNotNull(tasks);
        }
        [Test]
        public void TestGetProjectsMethod()
        {
            ProjectsController pc = new ProjectsController();
            IQueryable<Project> projects = pc.GetProjects();
            Assert.IsNotNull(projects);
        }
        [Test]
        public void TestGetParentTasksMethod()
        {
            ParentTasksController ptc = new ParentTasksController();
            IQueryable<ParentTask> parentTasks = ptc.GetParentTasks();
            Assert.IsNotNull(parentTasks);
        }
    }
}
