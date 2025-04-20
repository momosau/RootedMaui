using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TopFarmerDto> TopFarmers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TopFarmerDto>().HasNoKey(); // تعريف الكيان بدون مفتاح
    }

    public async Task<List<TopFarmerDto>> GetTop10FarmersByRatingAsync()
    {
        return await this.Set<TopFarmerDto>()
            .FromSqlRaw("EXEC GetTop10FarmersByRating")
            .ToListAsync();
    }

}
