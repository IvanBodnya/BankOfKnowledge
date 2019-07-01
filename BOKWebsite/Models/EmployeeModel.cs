using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BOKWebsite.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee's Id")]
        public int ID { get; set; }

        [Display(Name = "Employee's first name")]
        public string FirstName { get; set; }

        [Display(Name = "Employee's last name")]
        public string LastName { get; set; }
    }
}
