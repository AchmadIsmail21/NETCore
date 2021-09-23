using ImplementCors.Base.Urls;
using ImplementCors.Controllers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NETCore.ViewModel;
using Newtonsoft.Json;
using NETCore.Models;
using System.Text;
using System.Net;

namespace ImplementCors.Repositories.Data
{
    public class PersonRepository : GeneralRepository<Person, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        public PersonRepository(Address address, string request = "Persons/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }


        public async Task<List<RegisterVM>> GetAllProfile() {
            List<RegisterVM> registers = new List<RegisterVM>();
            using (var response = await httpClient.GetAsync(request + "GetAllProfile")) {
                string apiResponse = await response.Content.ReadAsStringAsync();
                registers = JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return registers;
        }

        public async Task<RegisterVM> GetById(string nik) {
            RegisterVM register = new RegisterVM();

            using (var response = await httpClient.GetAsync(request + "GetById/" + nik)) {
                string apiResponse = await response.Content.ReadAsStringAsync();
                register = JsonConvert.DeserializeObject<RegisterVM>(apiResponse);
            }
            return register;
        }
        /*public HttpStatusCode Register(RegisterVM register)
        {

            *//*StringContent content = new StringContent(JsonConvert.SerializeObject(register)
                , Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync(address.link + request + "Register", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                register = JsonConvert.DeserializeObject<RegisterVM>(apiResponse);

            }

            return register;*//*

            StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(request + "Register", content).Result;
            return result.StatusCode;
        }*/

        public String RegisterPerson(RegisterVM registerVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(request + "Register", content).Result.Content.ReadAsStringAsync().Result;


            return response;
        }
    }
}
