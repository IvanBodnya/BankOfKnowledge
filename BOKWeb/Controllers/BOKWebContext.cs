using BOKWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOKWeb.Controllers
{
    public class BOKWebContext : DbContext
    {
        public BOKWebContext(DbContextOptions<BOKWebContext> options) : base(options)
        {
        }

        public DbSet<PostingModel> PostingModels { get; set; }
    }
}
