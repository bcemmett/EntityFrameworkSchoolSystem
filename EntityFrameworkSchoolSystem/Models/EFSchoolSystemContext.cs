using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EntityFrameworkSchoolSystem.Models.Mapping;

namespace EntityFrameworkSchoolSystem.Models
{
    public partial class EFSchoolSystemContext : DbContext
    {
        static EFSchoolSystemContext()
        {
            Database.SetInitializer<EFSchoolSystemContext>(null);
        }

        public EFSchoolSystemContext()
            : base("Name=EFSchoolSystemContext")
        {
        }

        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PupilMap());
            modelBuilder.Configurations.Add(new SchoolMap());
        }
    }
}
