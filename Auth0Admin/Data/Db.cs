using System;
using Microsoft.EntityFrameworkCore;

namespace Auth0Admin.Data
{
    public class Db : DbContext
    {
        public DbSet<EventInfo> Events { get; set; }
        public DbSet<AccessToken> Tokens { get; set; }

        public Db(DbContextOptions opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AccessToken>()
                .ToTable("Tokens");

            builder.Entity<EventInfo>()
                .ToTable("Events")
                .Property(e => e._ImageUrls)
                .HasColumnName("ImageUrls");

            builder.Entity<EventInfo>().HasData(
                new EventInfo
                {
                    Id = 1,
                    Name = "Charity Ball",
                    Category = "Fundraising",
                    Description = "Spend an elegant night of dinner and dancing with us as we raise money for our new rescue farm.",
                    FeaturedImageUrl = "https://placekitten.com/500/500",
                    _ImageUrls = "[\"https://placekitten.com/500/500\", \"https://placekitten.com/500/500\", \"https://placekitten.com/500/500\"]",
                    Location = "1234 Fancy Ave.",
                    DateTime = new DateTime(2019, 12, 25, 11, 30, 00)
                },
                new EventInfo
                {
                    Id = 2,
                    Name = "Rescue Center Goods Drive",
                    Category = "Adoptions",
                    Description = "Come to our donation drive to help us replenish our stock of pet food, toys, bedding, etc. We will have live bands, games, food trucks, and much more.",
                    FeaturedImageUrl = "https://placekitten.com/500/500",
                    _ImageUrls = "[\"https://placekitten.com/500/500\"]",
                    Location = "1234 Dog Alley",
                    DateTime = new DateTime(2019, 11, 21, 12, 00, 00)
                });
        }
    }
}
