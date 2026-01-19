using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization; // <--- 1. Add this namespace

namespace OnlineClinicClient.Models
{
    public class User
    {
        [JsonPropertyName("id")] // Optional, but good practice
        public int Id { get; set; }

        [JsonPropertyName("username")] // Sends "username" instead of "Username"
        public string Username { get; set; }

        [JsonPropertyName("password")] // Sends "password" instead of "Password"
        public string Password { get; set; }

        [JsonPropertyName("role")] // Sends "role" instead of "Role"
        public string Role { get; set; }

        // Objects are usually fine, but you can tag them too if needed
        [JsonPropertyName("doctor")]
        public Doctor Doctor { get; set; }

        [JsonPropertyName("patient")]
        public Patient Patient { get; set; }
    }
}