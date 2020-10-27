using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trainee_project.Models
{
    public class User
    {
        public int Id{ get; set; }
        [Name("name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Name("dateofbirth")]
        [Required(ErrorMessage ="Date is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }
        [Name("married")]
        public bool Married { get; set;}
        [Name("phone")]
        [Required(ErrorMessage ="Phone number is required")]
        [Phone]
        public string Phone { get; set; }
        [Name("salary")]
        public decimal Salary { get; set; }
    }
}
