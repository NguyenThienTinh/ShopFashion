using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopFashion.Models;

namespace ShopFashion.Data
{
    public class ShopFashionContext : DbContext
    {
        public ShopFashionContext (DbContextOptions<ShopFashionContext> options)
            : base(options)
        {
        }

        public DbSet<ShopFashion.Models.Fashion> Fashion { get; set; }
    }
}
