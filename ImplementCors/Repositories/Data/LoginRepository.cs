using ImplementCors.Base.Urls;
using NETCore.Models;
using NETCore.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCors.Repositories.Data
{
    public class LoginRepository : GeneralRepository<Account, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;


        public LoginRepository(Address address, string request="Accounts/") : base(address,request)
        {
            this.address = address;
            this.request = request;
            this.httpClient = new HttpClient { 
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<JWTokenVM> Auth(LoginVM login) {
            JWTokenVM tokenVM = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(login),
                    Encoding.UTF8, "application/json"
                );
            var result = await httpClient.PostAsync(request + "login", content);

            string apiResponse = await result.Content.ReadAsStringAsync();
            tokenVM = JsonConvert.DeserializeObject<JWTokenVM>(apiResponse);
            return tokenVM;
        }
    }
}
