using DesignPattern.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS; initial catalog=DesignPattern4; integrated security=true;");
        }

        //bağlantı adresleri tanımlanır
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Process> Processes { get; set; }
    }
}
