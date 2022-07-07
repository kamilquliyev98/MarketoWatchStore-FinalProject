using MarketoWatchStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.DAL
{
    public class MarketoDbContext : IdentityDbContext<AppUser>
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
        public DbSet<ServicePolicy> ServicePolicies { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AdsBanner> AdsBanners { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CompareList> CompareLists { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
