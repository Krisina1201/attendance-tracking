using Demo.Domain.ModesDAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.RemoteDatabase
{
    public class RemoteDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=45.67.56.214;Port=5421;Username=user23;Database=user23;Password=Njx4mFby"
                );
        }

        public DbSet<GroupDAO> Groups { get; set; }
        public DbSet<UserDAO> Users { get; set; }
        public DbSet<PresenceDAO> Presences { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<GroupDAO>().HasKey(group =>  group.Id);
            modelBuilder.Entity<GroupDAO>().Property(group => group.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserDAO>().HasKey(user => user.Guid);
            modelBuilder.Entity<GroupDAO>().HasKey(group => group.Id);
            modelBuilder.Entity<PresenceDAO>().HasKey(presence => new
            {
                presence.userGuid,
                presence.Date,
                presence.IsAttedance,
                presence.LessonNumber
            });
        }
    }
}
