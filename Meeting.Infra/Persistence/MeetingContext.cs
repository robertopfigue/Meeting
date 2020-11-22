using Meeting.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Meeting.Infra.Persistence
{
    public class MeetingContext : DbContext
    {
        public MeetingContext() : base("root")
        {
           
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Room> Rooms { get; set; }

        public IDbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.AddFromAssembly(typeof(MeetingContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
