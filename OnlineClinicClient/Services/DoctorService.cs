using Newtonsoft.Json;
using OnlineClinicClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineClinicClient.Services
{
    public class DoctorService
    {
        private readonly HttpClient _httpClient;

        public DoctorService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/api/doctors/");
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            var response = await _httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Doctor>>(json);
            }
            return new List<Doctor>();
        }
    }
}