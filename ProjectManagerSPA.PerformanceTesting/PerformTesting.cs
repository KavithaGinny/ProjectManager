using System;
using System.Collections.Generic;
using System.Linq;
using NBench;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerSPA.Controllers;
using ProjectManagerSPA.Models;
using System.Web;

namespace ProjectManagerSPA.PerformanceTesting
{
    public class PerformTesting
    {
        private const string AddCounterName = "Add Counter";
        private Counter addCounter;

        private const int AcceptMinGetThroughput = 200000;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            addCounter = context.GetCounter(AddCounterName);
        }
        [PerfBenchmark(RunMode = RunMode.Throughput,TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName,MustBe.LessThan, AcceptMinGetThroughput)]
        public void GetUsersThroughput_ThroughputMode(BenchmarkContext context)
        {
            UsersController uc = new UsersController();
            IQueryable<User> users = uc.GetUsers();
            addCounter.Increment();
        }
        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.LessThan, AcceptMinGetThroughput)]
        public void GetTasksThroughput_ThroughputMode(BenchmarkContext context)
        {
            TasksController tc = new TasksController();
            IQueryable<Models.Task> users = tc.GetTasks();
            addCounter.Increment();
        }
        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.LessThan, AcceptMinGetThroughput)]
        public void GetProjectThroughput_ThroughputMode(BenchmarkContext context)
        {
            ProjectsController pc = new ProjectsController();
            IQueryable<Project> prjs = pc.GetProjects();
            addCounter.Increment();
        }
        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.LessThan, AcceptMinGetThroughput)]
        public void GetParentTasksThroughput_ThroughputMode(BenchmarkContext context)
        {
            ParentTasksController ptc = new ParentTasksController();
            IQueryable<ParentTask> ptasks = ptc.GetParentTasks();
            addCounter.Increment();
        }
    }   
    
}
