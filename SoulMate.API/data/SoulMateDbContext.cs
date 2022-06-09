using Microsoft.EntityFrameworkCore;

namespace SoulMate.API.data
{
    public class SoulMateDbContext : DbContext
    {
        public SoulMateDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Soulmate> SoulMates { get; set; }
        public DbSet<Country> Countries { get; set; }
  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "India",
                CountryCode = "IND"
            },
                new Country
                {
                    Id = 2,
                    Name = "United Kingdoms",
                    CountryCode = "UK"
                }
            );
        modelBuilder.Entity<Soulmate>().HasData(
          new Soulmate
          {
              Id = 1,
              Name = "Zakaria",
              Age = 26,
              Gender = 'M',
              CountryId=1

          },
                new Soulmate
                {
                    Id = 2,
                    Name = "Mary",
                    Age = 25,
                    Gender='F',
                    CountryId=2

                }
           );


    }
}
}