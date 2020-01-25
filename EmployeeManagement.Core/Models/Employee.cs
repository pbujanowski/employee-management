using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Core.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public string Address { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        [JsonProperty(ItemIsReference = true)]
        public City City { get; set; }

        public string PostalCode { get; set; }
        
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }

        [JsonProperty(ItemIsReference = true)]
        public Job Job { get; set; }

        [Required]
        [JsonProperty]
        public DateTime EmploymentDate { get; set; }

        [JsonConstructor]
        public Employee()
        {
            EmploymentDate = DateTime.Now;
        }
    }
}
