using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BOKWeb.Models
{
    [Table("Posting")]
    public class PostingModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Creation date")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Post description")]
        public string Description { get; set; }

        [Display(Name = "Approx. min to read")]
        public string MinToRead { get; set; }
    }
}
