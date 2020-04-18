using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Core.Models
{
    public class Duty
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(ExecutiveEmployee))]
        [Required]
        public int ExecutiveEmployeeId { get; set; }

        [Required]
        [JsonProperty(ItemIsReference = true)]
        public Employee ExecutiveEmployee { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [JsonProperty]
        public DateTime? Deadline { get; set; }

        [JsonProperty]
        public DateTime? BeginDate { get; set; }

        [JsonProperty]
        public DateTime? EndDate { get; set; }

        [Required]
        public bool IsDone { get; set; }

        [JsonConstructor]
        public Duty()
        {
            OrderDate = DateTime.Now;
            Deadline = null;
            BeginDate = null;
            EndDate = null;
            IsDone = false;
        }
    }
}