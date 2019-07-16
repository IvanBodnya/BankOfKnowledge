using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOKWeb.Models
{
    public class PostingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public string MinToRead { get; set; }
    }
}
