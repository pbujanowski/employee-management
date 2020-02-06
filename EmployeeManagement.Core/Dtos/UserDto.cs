using EmployeeManagement.Core.Models;
using Newtonsoft.Json;

namespace EmployeeManagement.Core.Dtos
{
    public class UserDto
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Username { get; set; }

        [JsonProperty(ItemIsReference = true)]
        public Employee Employee { get; set; }

        [JsonProperty]
        public string Token { get; set; }
    }
}