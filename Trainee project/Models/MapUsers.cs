using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainee_project.Models
{
    public class MapUsers:ClassMap<User>
    {
        public MapUsers()
        {
           
            Map(m => m.Name).Name("name");
            Map(m => m.DateOfBirth).Name("dateofbirth");
            Map(m => m.Married).Name("married");
            Map(m => m.Phone).Name("phone");
            Map(m => m.Salary).Name("salary");
         
        }
    }
}
