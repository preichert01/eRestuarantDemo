using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional NameSpaces
using eRestuarantSystem.DAL;
using eRestuarantSystem.DAL.Entities;
using System.ComponentModel; // object Data Sources
#endregion
namespace eRestuarantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvents_List()
        {
            // connect to our DbContext class in the DAL
            // create and instance of the class.
            // we will use a transaction to hold our query
            using (var context = new eRestaurantContext())
            {
                // method syntax
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();
                //Query Syntax
                var results = from item in context.SpecialEvents
                              orderby item.Description 
                                  select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> GetReservationsByEventCode(string eventcode)
        {
            // connect to our DbContext class in the DAL
            // create and instance of the class.
            // we will use a transaction to hold our query
            using (var context = new eRestaurantContext())
            {
                //Query Syntax
                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventcode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;
                return results.ToList();
            }
        }
    }
}
