using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<OrgUnit> OrgUnits { get; set; }
        public DbSet<Furniture> Furnituries { get; set; }
        //public DbSet<OrgUnitFurnitures> OrgUnitFurnituries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DesctopDatadb;Trusted_Connection=True;");
        }



    }

}
