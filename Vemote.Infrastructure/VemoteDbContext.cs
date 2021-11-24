using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vemote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemote.Infrastructure
{
    public class VemoteDbContext : DbContext
    {
        public VemoteDbContext(DbContextOptions<VemoteDbContext> options) : base(options) { }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Users> Userss { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
/*        public DbSet<Address> Addresses { get; set; }*/

        /*     
              public DbSet<Order> Orders { get; set; }
              public DbSet<Favorite> Favorites { get; set; }
              */


        /*        public DbSet<Category> Categories { get; set; }
                public DbSet<FavoritePost> FavoritePosts { get; set; }
                public DbSet<Follow> Follows { get; set; }
                public DbSet<Image> Images { get; set; }
                public DbSet<Post> Posts { get; set; }
                public DbSet<PostType> PostTypes { get; set; }
                public DbSet<Report> Reports { get; set; }
                public DbSet<User> Users { get; set; }
                public DbSet<UserType> UserTypes { get; set; }
                public DbSet<VerifyPhone> VerifyPhones { get; set; }
                public DbSet<RefreshToken> RefreshTokens { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


/*
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");
                entity.HasKey(e => new { e.UserID, e.AddressID, e.DistrictID, e.ProvinceID, e.WardID });

            });*/

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => new { e.ID });

                entity.HasOne(d => d.CreatedBy)
                    .WithMany()
                    .HasForeignKey(d => d.CreatedByID)
                    .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(d => d.UpdatedByID)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.ToTable("ProductOrder");
                entity.HasKey(e => new { e.OrderID, e.ProductID });

                entity.HasOne(d => d.Product)
                    .WithMany(d => d.ProductOrders)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(d => d.Order)
                    .WithMany(d => d.ProductOrders)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorite");
                entity.HasKey(e => new { e.ProductID, e.UserID });

                entity.HasOne(d => d.Product)
                    .WithMany(d => d.Favorites)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(d => d.User)
                    .WithMany(d => d.Favorites)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");
                entity.HasKey(e => new { e.UserID, e.ProductID });

                entity.HasOne(d => d.Product)
                    .WithMany(d => d.Reviews)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(d => d.User)
                    .WithMany(d => d.Reviews)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });


            /*            modelBuilder.Entity<Banner>(entity =>
                        {
                            entity.ToTable("Banner");
                            entity.HasKey(e => new { e.ID });


                            entity.HasOne(d => d.CreatedBy)
                                .WithMany(d => d.BannerCreate)
                                .HasForeignKey(d => d.CreatedByID)
                                .OnDelete(DeleteBehavior.ClientCascade);

                            entity.HasOne(d => d.UpdatedBy)
                                .WithMany(d => d.BannerUpdate)
                                .HasForeignKey(d => d.UpdatedByID)
                                .OnDelete(DeleteBehavior.ClientCascade);
                        });
            */
            /*            modelBuilder.Entity<UserType>(entity =>
                        {
                            entity.ToTable("UserType");
                            entity.HasKey(e => new { e.ID });


                            entity.HasOne(d => d.CreatedBy)
                                .WithMany(d => d.UserTypeCreate)
                                .HasForeignKey(d => d.CreatedByID)
                                .OnDelete(DeleteBehavior.ClientCascade);

                            entity.HasOne(d => d.UpdatedBy)
                                .WithMany(d => d.UserTypeUpdate)
                                .HasForeignKey(d => d.UpdatedByID)
                                .OnDelete(DeleteBehavior.ClientCascade);
                        });*/



        }
    }
}

