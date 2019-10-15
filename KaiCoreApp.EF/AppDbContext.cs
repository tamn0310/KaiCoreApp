using KaiCoreApp.Data.Entities;
using KaiCoreApp.Data.Interfaces;
using KaiCoreApp.EF.Configurations;
using KaiCoreApp.EF.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace KaiCoreApp.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Advertistment> Advertistments { get; set; }
        public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
        public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementUser> AnnouncementUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogTag> BlogTag { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductQuantity> ProductQuantities { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<WholePrice> WholePrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Identity Config

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);

            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });

            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });

            #endregion Identity Config

           // modelBuilder.AddConfiguration(new TagConfiguration());
            modelBuilder.AddConfiguration(new AdvertistmentPositionConfiguration());
            modelBuilder.AddConfiguration(new BlogTagConfiguration());
            modelBuilder.AddConfiguration(new ContactDetailConfiguration());
            modelBuilder.AddConfiguration(new FooterConfiguration());
            modelBuilder.AddConfiguration(new FunctionConfiguration());
            modelBuilder.AddConfiguration(new PageConfiguration());
            modelBuilder.AddConfiguration(new ProductTagConfiguration());
            modelBuilder.AddConfiguration(new SystemConfigConfiguration());

            //base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                var changeOrAddedItem = item.Entity as IDateTracking;
                if (changeOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changeOrAddedItem.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        changeOrAddedItem.DateModified = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);
            
            return new AppDbContext(builder.Options);
        }
    }
}