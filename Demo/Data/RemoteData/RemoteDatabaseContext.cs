using Demo.Data.RemoteData.RemoteDataBase;
using Demo.Domain.ModesDAO;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.RemoteData.RemoteDataBase
{
    public class RemoteDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=45.67.56.214;Port=5421;Username=user23;Database=user23;Password=Njx4mFby");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GroupDAO>().HasKey(group => group.Id);
            modelBuilder.Entity<GroupDAO>().Property(group => group.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<UserDAO>().HasKey(user => user.Guid);
            modelBuilder.Entity<UserDAO>().Property(user => user.Guid).ValueGeneratedOnAdd();


            modelBuilder.Entity<PresenceDAO>().HasKey(presense => new
            {
                presense.Id

            });



            modelBuilder.Entity<PresenceDAO>()
               .Property(presence => presence.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<PresenceDAO>().HasOne(presence => presence.UserDao).WithMany(user => user.Presences).HasForeignKey(presence => presence.UserGuid);
        }

        public DbSet<GroupDAO> Groups { get; set; }
        public DbSet<UserDAO> Users { get; set; }
        public DbSet<PresenceDAO> PresenceDaos { get; set; }
    }
}