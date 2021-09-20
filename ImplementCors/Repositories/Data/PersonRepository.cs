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

namespace ImplementCors.Repositories.Data
{
    public class PersonRepository : GeneralRepository<Person, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor contextAccessor;
        public PersonRepository(Address address, string request = "Persons/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            contextAccessor = new HttpContextAccessor();
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
    }
}
