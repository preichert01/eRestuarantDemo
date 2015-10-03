using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Name spaces
using System.Collections;
#endregion
namespace eRestuarantSystem.DAL.DTOs
{
    public class ReservationsByDate
    {
        public string Description { get; set; }
        // the next variable will hold a collection 
        // of resevation rows.
        public IEnumerable Reservations { get; set; }
    }
}
