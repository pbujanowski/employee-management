using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        [JsonProperty(ItemIsReference = true)]
        public Employee Employee { get; set; }

        public UserPermission Permission { get; set; }
    }
}
