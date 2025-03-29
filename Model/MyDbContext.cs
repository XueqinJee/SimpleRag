using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyDbContext : DbContext
    {

        public DbSet<Knowledge> Knowledge { get; set; }
    }
}
