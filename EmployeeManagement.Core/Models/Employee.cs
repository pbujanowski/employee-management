using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Core.Models
{
    public class Employee : IDataErrorInfo
    {
        [Key]
        [Required]
        [JsonProperty]
        public int Id { get; set; }

        [Required]
        [JsonProperty]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty]
        public string LastName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [Required]
        [JsonProperty]
        public string Job { get; set; }

        [Required]
        [JsonProperty]
        public decimal Salary { get; set; }

        [Required]
        [JsonProperty]
        public DateTime EmploymentDate { get; set; }

        [Required]
        [JsonProperty]
        public int ExperienceYears { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Dictionary<string, string> Errors { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string this[string columnName] { get { return ValidateProperty(columnName); } }

        [NotMapped]
        [JsonIgnore]
        public string Error { get { return null; } }

        private string ValidateProperty(string propertyName)
        {
            string result = string.Empty;
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.IsNullOrWhiteSpace(FirstName))
                        result += "Imię nie może być puste!" + Environment.NewLine;
                    break;
            }
            if (!string.IsNullOrWhiteSpace(result))
                Errors.Add(propertyName, result);
            else
                Errors.Remove(propertyName);
            return result;
        }

        [JsonConstructor]
        public Employee()
        {
            Errors = new Dictionary<string, string>();
            EmploymentDate = DateTime.Now;
        }
    }
}
