namespace JinnHouse.DAL.EFHouseContext
{
    using Entities.Entities;
    using Entities.Entities.Audio;
    using Entities.Entities.Fan;
    using Entities.Entities.Video;
    using Entities.Entities.Web;
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Linq;

    public class HouseContext : DbContext
    {
        // Your context has been configured to use a 'HouseContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'JinnHouse.DAL.HouseContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HouseContext' 
        // connection string in the application configuration file.
        public HouseContext(string connectionName) : base(GetConnectionString(connectionName))
        {
            Database.SetInitializer(new HouseDbInitializer());
            Database.Initialize(false);
        }

        public HouseContext()
            : base("HouseContext")
        {
        }

        public DbSet<TV> TVs { get; set; }

        public DbSet<Oven> Ovens { get; set; }

        public DbSet<AudioSystem> AudioSystems { get; set; }

        public DbSet<Conditioner> Conditioners { get; set; }

        public DbSet<Router> Routers { get; set; }

        private static string GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}