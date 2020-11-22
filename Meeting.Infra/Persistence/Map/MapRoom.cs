using Meeting.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Meeting.Infra.Persistence.Map
{
    public class MapRoom : EntityTypeConfiguration<Room>
    {
        public MapRoom()
        {
            ToTable("Room");

            Property(p => p.Number).IsRequired();
        }
    }
}
