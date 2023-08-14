using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using sunguIntegration.Dal.Entities;
using sunguIntegration.Dal.Models;

namespace sunguIntegration.Dal;
public class TrendyolContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<TrendyolUserInfo> TrendyolUserInfos { get; set; }
    public DbSet<TrendyolCategory> TrendyolCategories { get; set; }
    public DbSet<TrendyolBrand> TrendyolBrands { get; set; }
    public DbSet<TrendyolProduct> TrendyolProducts { get; set; }
    public DbSet<TrendyolDeliveryOption> TrendyolDeliveryOptions { get; set; }
    public DbSet<TrendyolAttribute> TrendyolAttributes { get; set; }
    public DbSet<TrendyolImage> TrendyolImages { get; set; }
    public DbSet<TrendyolProvider> TrendyolProviders { get; set; }
    public DbSet<BatchResultResponse> BatchResultResponses { get; set; }



    public TrendyolContext(DbContextOptions options) : base(options)
    {

    }

    public TrendyolContext()
    {

    }
}