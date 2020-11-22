using Meeting.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Meeting.Infra.Persistence.Map
{
    public class MapSchedules : EntityTypeConfiguration<Schedule>
    {
        public MapSchedules()
        {
            ToTable("Schedule");

            Property(p => p.Title).HasMaxLength(50).IsRequired();
            Property(p => p.RoomId).IsRequired();
            HasRequired(p => p.Room).WithMany(p => p.Schedule).HasForeignKey(p => p.RoomId);
            Property(p => p.Date.InitialDate).IsRequired().HasColumnName("InicialDate");
            Property(p => p.Date.FinalDate).IsRequired().HasColumnName("FinalDate");
        }
            
    }
}
