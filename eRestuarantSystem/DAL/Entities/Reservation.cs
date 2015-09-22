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
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        [Required]
        [StringLength(30,MinimumLength=5)]
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        [Required, Range(1,16)]
        public int NumberInParty { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
        [Required]
        [StringLength(1)]
        public string ReservationStatus { get; set; }
        [StringLength(1)]
        public string EventCode { get; set; }

        //Navigation Properties
        public virtual SpecialEvent Event { get; set;}

        /* the Reservations Table (sql) is a many to many relationshipto the Tables table(sql)
         Sql solves this problem by having an associate table that has a compound primary key 
         * created form Reservations and Tables.
         We will not be creating an entity for this associated table
         Instead we will create an overload map in our DbContect class
         However, we can still create the virtual navigation progerty to accomondate this relationship*/

        public virtual ICollection<Table> Tables { get; set; }
    }
}
