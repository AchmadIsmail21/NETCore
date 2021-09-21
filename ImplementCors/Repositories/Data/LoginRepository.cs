using ImplementCors.Base.Urls;
using NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImplementCors.Repositories.Data
{
    public class LoginRepository : GeneralRepository<Person, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public LoginRepository(Address address, HttpClient httpClient, string request="Persons/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            this.httpClient = new HttpClient { 
                BaseAddress = new Uri(address.link)
            };
        }
    }
}
