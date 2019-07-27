using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Core.Models
{
    public class Duty
    {
        [Key]
        [Required]
        [JsonProperty]
        public int Id { get; set; }

        [ForeignKey(nameof(ExecutiveEmployee))]
        [Required]
        public int ExecutiveEmployeeId { get; set; }

        [Required]
        [JsonProperty(ItemIsReference = true)]
        public Employee ExecutiveEmployee { get; set; }

        [Required]
        [JsonProperty]
        public string Description { get; set; }

        [Required]
        [JsonProperty]
        public DateTime OrderDate { get; set; }

        [JsonProperty]
        public DateTime? Deadline { get; set; }

        [JsonProperty]
        public DateTime? EndDate { get; set; }

        [Required]
        [JsonProperty]
        public bool IsDone { get; set; }

        [JsonConstructor]
        public Duty()
        {
            Deadline = null;
            EndDate = null;
            IsDone = false;
        }
    }
}
