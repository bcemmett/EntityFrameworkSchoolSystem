using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkSchoolSystem.Models.Mapping
{
    public class PupilMap : EntityTypeConfiguration<Pupil>
    {
        public PupilMap()
        {
            // Primary Key
            this.HasKey(t => t.PupilId);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address1)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Adderss2)
                .HasMaxLength(100);

            this.Property(t => t.PostalZipCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Pupils");
            this.Property(t => t.PupilId).HasColumnName("PupilId");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Adderss2).HasColumnName("Adderss2");
            this.Property(t => t.PostalZipCode).HasColumnName("PostalZipCode");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.SchoolId).HasColumnName("SchoolId");

            // Relationships
            this.HasRequired(t => t.School)
                .WithMany(t => t.Pupils)
                .HasForeignKey(d => d.SchoolId);

        }
    }
}
