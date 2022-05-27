using System.Data.Entity;
using WinFormsEntityFrameWork.models;

namespace WinFormsEntityFrameWork
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        
        
        /*
         *  в файле App.config
         *  <connectionStrings>
         *     <add name="PGConnectionString" connectionString="Server=localhost;Port=5432;User Id=postgres;Password=admin;Database=proekt;" providerName="Npgsql" />
         *  </connectionStrings>
         */
        public EmployeeContext() : base(nameOrConnectionString: "PGConnectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}