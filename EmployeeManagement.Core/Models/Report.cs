using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Core.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        [Required]
        [JsonProperty(ItemIsReference = true)]
        public Employee Employee { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime ModificationDate { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string HtmlSource { get; set; }

        [Required]
        public bool IsPrinted { get; set; }

        [JsonConstructor]
        public Report()
        {
            CreationDate = DateTime.Now;
            ModificationDate = DateTime.Now;
            IsPrinted = false;
        }
    }
}
