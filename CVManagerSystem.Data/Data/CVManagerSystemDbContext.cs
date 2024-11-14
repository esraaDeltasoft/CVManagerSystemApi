using CVManagerSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagerSystem.Data.Data
{
    public class CVManagerSystemDbContext : DbContext
    {
        public CVManagerSystemDbContext(DbContextOptions<CVManagerSystemDbContext> options) : base(options) { }

        public DbSet<CV> CVs { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<ExperienceInformation> ExperienceInformations { get; set; }
    }
}
