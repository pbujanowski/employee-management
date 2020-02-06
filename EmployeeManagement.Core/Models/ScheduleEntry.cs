using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Core.Models
{
    public class ScheduleEntry
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Employee))]
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [JsonProperty(ItemIsReference = true)]
        public Employee Employee { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}