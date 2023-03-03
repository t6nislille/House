using Microsoft.EntityFrameworkCore;
using ProjectHouse.Core.Domain;

namespace ProjectHouse.Data
{
    public class ProjectHouseContext :DbContext
    {
        public ProjectHouseContext(DbContextOptions<ProjectHouseContext> options)
        : base(options) { }

        public DbSet<House> Houses { get; set; }
    }
}
