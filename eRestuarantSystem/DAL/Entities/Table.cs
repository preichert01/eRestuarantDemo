using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional NameSpaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion

namespace eRestuarantSystem.DAL.Entities
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }
        [Required, Range(1,25)]
        public byte TableNumber { get; set; } // tiny int in SQL
        public bool Smoking { get; set; }
        [Required, Range(1,8)]
        public int Capacity { get; set; }

        public bool Available { get; set; }

        //Navigation Properties
        /* the Reservations Table (sql) is a many to many relationshipto the Tables table(sql)
         Sql solves this problem by having an associate table that has a compound primary key 
         * created form Reservations and Tables.
         We will not be creating an entity for this associated table
         Instead we will create an overload map in our DbContect class
         However, we can still create the virtual navigation progerty to accomondate this relationship*/
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Table()
        {
            Available = true;
            Smoking = false;
        }
    }

}
