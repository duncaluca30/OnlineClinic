using Newtonsoft.Json;
using OnlineClinicClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClinicClient.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/api/auth/");
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var loginRequest = new { username, password };
            var json = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(responseJson);
                return user;
            }

            return null; // login failed
        }
    }

}
