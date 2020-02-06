using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Core.Models
{
    public class EmployeeAppraisal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        [Required]
        [JsonProperty(ItemIsReference = true)]
        public Employee Employee { get; set; }

        [Required]
        public AppraisalValue Value { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [JsonConstructor]
        public EmployeeAppraisal()
        {
            IssueDate = DateTime.Now;
        }
    }
}