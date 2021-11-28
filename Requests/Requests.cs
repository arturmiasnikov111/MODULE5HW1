using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MODULE5HW1.Models;
using MODULE5HW1.Requests.Abstractions;

namespace MODULE5HW1.Requests
{
    public class Requests : IRequests
    {
        public async Task<ListData<User>> GetUsers()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/users?page=2");
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ListData<User>>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<SingleData<User>> GetSingleUser()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/users/2");
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<SingleData<User>>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<SingleData<User>> GetSingleUserNotFound()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/users/23");
                Console.WriteLine(result.StatusCode);
                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<SingleData<User>>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<ListData<Resources>> GetResources()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/unknown");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ListData<Resources>>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<SingleData<Resources>> GetSingleResource()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/unknown/2");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<SingleData<Resources>>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<SingleData<Resources>> GetSingleResourceNotFound()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/unknown/23");

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<SingleData<Resources>>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<Employee> CreateEmployee()
        {
            using (var httpClient = new HttpClient())
            {
                var payload = new Employee
                {
                    Name = "morpheus",
                    Job = "leader"
                };

                var httpMessage = new HttpRequestMessage();
                httpMessage.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                httpMessage.RequestUri = new Uri(@"https://reqres.in/api/users");

                var result = await httpClient.PostAsync(httpMessage.RequestUri, httpMessage.Content);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Employee>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<Employee> UpdateEmployee()
        {
            using (var httpClient = new HttpClient())
            {
                var payload = new Employee
                {
                    Name = "morpheus",
                    Job = "zion president"
                };

                var httpMessage = new HttpRequestMessage();
                httpMessage.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                httpMessage.RequestUri = new Uri(@"https://reqres.in/api/users/2");

                var result = await httpClient.PutAsync(httpMessage.RequestUri, httpMessage.Content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Employee>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<Employee> PatchEmployee()
        {
            using (var httpClient = new HttpClient())
            {
                var payload = new Employee
                {
                    Name = "morpheus",
                    Job = "zion president"
                };

                var httpMessage = new HttpRequestMessage();
                httpMessage.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                httpMessage.RequestUri = new Uri(@"https://reqres.in/api/users/2");

                var result = await httpClient.PatchAsync(httpMessage.RequestUri, httpMessage.Content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Employee>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<Employee> DeleteEmployee()
        {
            using (var httpClient = new HttpClient())
            {
                var httpMessage = new HttpRequestMessage();
                httpMessage.RequestUri = new Uri(@"https://reqres.in/api/users/2");

                var result = await httpClient.DeleteAsync(httpMessage.RequestUri);

                if (result.StatusCode == HttpStatusCode.NoContent)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Employee>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<Register> RegisterSuccesfull()
        {
            var payload = new Register
            {
                Email = "eve.holt@reqres.in",
                Password = "pistol"
            };

            string uri = @"https://reqres.in/api/register";

            var result = await Authorization(payload, uri, HttpStatusCode.OK);
            return result;
        }

        public async Task<Register> RegisterUnsuccesfull()
        {
            var payload = new Register
            {
                Email = "eve.holt@reqres.in"
            };

            string uri = @"https://reqres.in/api/register";

            var result = await Authorization(payload, uri, HttpStatusCode.BadRequest);
            return result;
        }

        public async Task<Register> Login()
        {
            var payload = new Register
            {
                Email = "eve.holt@reqres.in",
                Password = "cityslicka"
            };

            string uri = @"https://reqres.in/api/login";

            var result = await Authorization(payload, uri, HttpStatusCode.OK);
            return result;
        }

        public async Task<Register> LoginUnsuccesfull()
        {
            var payload = new Register
            {
                Email = "peter@klaven"
            };

            string uri = @"https://reqres.in/api/login";

            var result = await Authorization(payload, uri, HttpStatusCode.BadRequest);
            return result;
        }

        public async Task<Register> Authorization(Register payload, string requestedUri, HttpStatusCode httpStatusCode)
        {
            using (var httpClient = new HttpClient())
            {

                var httpMessage = new HttpRequestMessage();
                httpMessage.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                httpMessage.RequestUri = new Uri(requestedUri);

                var result = await httpClient.PostAsync(httpMessage.RequestUri, httpMessage.Content);

                if (result.StatusCode == httpStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Register>(content);
                }

                throw new AggregateException();
            }
        }

        public async Task<ListData<Resources>> DelayedResponse()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync(@"https://reqres.in/api/users?delay=3");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ListData<Resources>>(content);
                }

                throw new AggregateException();
            }
        }
    }
}