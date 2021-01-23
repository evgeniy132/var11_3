using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConsoleApp1
{
    class EmployeeContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Engineer> Engineers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Doctor>().Property(d => d.Specialization).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Name).HasMaxLength(128);
            modelBuilder.Entity<Engineer>().Map((e) =>
            {
                e.MapInheritedProperties();
                e.ToTable("Engineers");
            });
            modelBuilder.Entity<Doctor>().Map((e) =>
            {
                e.MapInheritedProperties();
                e.ToTable("Doctors");
            });
            modelBuilder.Entity<Employee>().Property(c => c.Id).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }

}

