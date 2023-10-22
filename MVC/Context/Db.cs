using Microsoft.EntityFrameworkCore;
using MVC.Entities;

namespace MVC.Context
{
    public class Db : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<UserResource> UserResources { get; set; }

        public Db(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many ilişkiler için yapılmalı
            modelBuilder.Entity<UserResource>().HasKey(e => new { e.UserId, e.ResourceId });
            modelBuilder.Entity<User>().HasOne(user => user.Role) // foreign key olan entitylere göre kurduk ilişkileri
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId) //opsiyonel
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserResource>().HasOne(UserResource => UserResource.User)
                .WithMany(user => user.UserResource)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserResource>().HasOne(UserResource => UserResource.Resource)
                .WithMany(resource => resource.UserResource)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Resource>().HasIndex(resource => resource.Date);

            modelBuilder.Entity<User>().HasIndex(user => user.UserName).IsUnique();
        }
    }
}
