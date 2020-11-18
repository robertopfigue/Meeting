using Meeting.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Meeting.Infra.Persistence.Map
{
    public class MapUser : EntityTypeConfiguration<User>
    {
        public MapUser()
        {
            ToTable("User");

            Property(p => p.Name.FirstName).HasMaxLength(50).IsRequired().HasColumnName("FirstName");
            Property(p => p.Name.LastName).HasMaxLength(50).IsRequired().HasColumnName("LastName");
            Property(p => p.Email.Address).HasMaxLength(50).IsRequired();
            Property(p => p.Senha).IsRequired();
        }
    }
}
