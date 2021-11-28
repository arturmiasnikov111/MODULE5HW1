using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MODULE5HW1
{
    public class Starter
    {
        public Task Run()
        {
            var request = new Requests.Requests();
            var tasks = new List<Task>();
            tasks.Add(Task.Run(async () => await request.GetUsers()));
            tasks.Add(Task.Run(async () => await request.GetSingleUser()));
            tasks.Add(Task.Run(async () => await request.GetSingleUserNotFound()));
            tasks.Add(Task.Run(async () => await request.GetResources()));
            tasks.Add(Task.Run(async () => await request.GetSingleResource()));
            tasks.Add(Task.Run(async () => await request.CreateEmployee()));
            tasks.Add(Task.Run(async () => await request.UpdateEmployee()));
            tasks.Add(Task.Run(async () => await request.PatchEmployee()));
            tasks.Add(Task.Run(async () => await request.DeleteEmployee()));
            tasks.Add(Task.Run(async () => await request.RegisterSuccesfull()));
            tasks.Add(Task.Run(async () => await request.RegisterUnsuccesfull()));
            tasks.Add(Task.Run(async () => await request.Login()));
            tasks.Add(Task.Run(async () => await request.LoginUnsuccesfull()));
            tasks.Add(Task.Run(async () => await request.DelayedResponse()));

            var result = Task.WhenAll(tasks);
            return result;
        }
    }
}