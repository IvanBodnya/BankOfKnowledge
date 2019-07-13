using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BOKWebsite.Models
{
    public class VIPModel
    {
        public string OwnerID { get; set; }
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [Display(Name = "Password")] 
        public string Password { get; set; }
    }
}
