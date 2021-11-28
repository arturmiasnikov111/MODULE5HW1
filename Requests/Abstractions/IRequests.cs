using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MODULE5HW1.Models;

namespace MODULE5HW1.Requests.Abstractions
{
    public interface IRequests
    {
        public Task<ListData<User>> GetUsers();
        public Task<SingleData<User>> GetSingleUser();
        public Task<SingleData<User>> GetSingleUserNotFound();
        public Task<ListData<Resources>> GetResources();
        public Task<SingleData<Resources>> GetSingleResource();
        public Task<SingleData<Resources>> GetSingleResourceNotFound();
        public Task<Employee> CreateEmployee();
        public Task<Employee> UpdateEmployee();
        public Task<Employee> PatchEmployee();
        public Task<Employee> DeleteEmployee();
        public Task<Register> RegisterSuccesfull();
        public Task<Register> RegisterUnsuccesfull();
        public Task<Register> Login();
        public Task<Register> LoginUnsuccesfull();
        public Task<Register> Authorization(Register payload, string uri, HttpStatusCode httpStatusCode);
        public Task<ListData<Resources>> DelayedResponse();
    }
}