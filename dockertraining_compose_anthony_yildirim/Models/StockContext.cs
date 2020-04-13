using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using MySql.Data.EntityFrameworkCore.Infraestructure;

namespace dockertraining_compose_anthony_yildirim.Models
{
    public class StockContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        public StockContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = optionsBuilder.Options.GetExtension<MySQLOptionsExtension>().ConnectionString;
            //optionsBuilder.UseMySQL(connectionString);
        }
    }
}
