using MarketoWatchStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.DAL
{
    public class MarketoDbContext : DbContext
    {
        public MarketoDbContext(DbContextOptions<MarketoDbContext> options) : base(options) { }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Display> Displays { get; set; }
        public DbSet<PowerSource> PowerSources { get; set; }
        public DbSet<SpecialType> SpecialTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductColour> ProductColours { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
