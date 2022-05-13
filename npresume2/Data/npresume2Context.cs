#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using npresume2.Model;

namespace npresume2.Data
{
    public class npresume2Context : DbContext
    {
        public npresume2Context (DbContextOptions<npresume2Context> options)
            : base(options)
        {
        }

        public DbSet<npresume2.Model.NpRegistration> NpRegistration { get; set; }
    }
}
