using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineClinicClient.Models;

namespace OnlineClinicClient.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/api/patients/");
        }

        // Get all patients
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            var response = await _httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Patient>>(json);
            }
            return new List<Patient>();
        }

        // Get patient by ID
        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(id.ToString());
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Patient>(json);
            }
            return null;
        }

        // Create new patient
        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            var json = JsonConvert.SerializeObject(patient);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("", content);
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Patient>(responseJson);
            }
            return null;
        }
    }
}