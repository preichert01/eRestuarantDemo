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
    public class SpecialEvent
    {
        [Key]
        [Required(ErrorMessage="An EventCode is Required. (only one Character)")]
        [StringLength(1, ErrorMessage="Event Code is only one character in lenght.")]
        public string EventCode { get; set; }
        
        [Required(ErrorMessage="The Description is a required field.")]
        [StringLength(30,ErrorMessage="Only a max of 30 characters are acceptable.")]
        public string Description { get; set; }
        public bool Active { get; set; }

        // Navigational virtual Properties
        //this Entity is a parent to the Reservation Table
        public virtual ICollection<Reservation> Reservations { get; set; }

        // default values can be set in the class constructor.
        public SpecialEvent()
        {
            Active = true;
        }
    }
}
