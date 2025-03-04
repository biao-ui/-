using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        string constr = "Data Source=8.134.67.24\\IZ2ZDX6DD6KLDSZ\\MSSQL,5699;Initial Catalog=DecorationSystem2;User ID=sa;Password=huangsheng;Trust Server Certificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(constr);
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }

        public DbSet<MenuInfo> MenuInfo { get; set; }

        public DbSet<RoleMenu> RoleMenu { get; set; }

        public DbSet<Notice> Notice { get; set; }

        public DbSet<FileInfo> FileInfo { get; set; }

        public DbSet<OrdersMaterial> OrdersMaterial { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Material> Material { get; set; }

    }
}
