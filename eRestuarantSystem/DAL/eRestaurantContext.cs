using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional NameSpaces
using eRestuarantSystem.DAL.Entities;
using System.Data.Entity;
#endregion

namespace eRestuarantSystem.DAL
{
    // this class should only be accessible from classes inside this component library
    // therefore the access level for this class will be internal

    // This Class will inherit from DbContext (EntityFramework)
    internal class eRestaurantContext : DbContext
    {
        // Create constructor which will pass the conection string name to the DbContext
        public eRestaurantContext() : base("name=EatIn")
        {

        }

        //set of mapping DbSet<T> properties
        // map an Entity do a database table
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }

        /*When overriding the OnModelCreating method it is important to 
        remember to call the base method's implementation before you exit the method */

        /* The ManyToManyNavigationPropertyConfiguration.Map method
         lets you configure the tables and columns used for this many to many relationship
         It takes a ManyToManyNavigationPropertyConfiguration instance in hwich you specify the column names by calling the MapLeftKey, 
         MapRightKey, and ToTable Methods*/
    
        /* The "left" key is the one specified in the HasMany mehtod
         The "Right" key is the one specified in the WithMany method.
         This Navigation replaces the sql associated table that breaks up 
         a many to many relationship.
         This technique should only be used if the associated table in sql has Only a compound primary key 
         and No non-key attributes*/
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(t => t.Reservations)
                .Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("ReservationID");
                    mapping.MapRightKey("TableID");
                });
            base.OnModelCreating(modelBuilder); //DO NOT REMOVE 
        }

        
    }
}
