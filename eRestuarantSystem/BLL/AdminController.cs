using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional NameSpaces
using eRestuarantSystem.DAL;
using eRestuarantSystem.DAL.Entities;
using eRestuarantSystem.DAL.DTOs;
using eRestuarantSystem.DAL.POCOs;
using System.ComponentModel; // object Data Sources
#endregion
namespace eRestuarantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        #region Queries
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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReservationsByDate> GetReservationsByDate(string reservationDate)
        {
            using (var context = new eRestaurantContext())
            {
                //Linq is not very playfull or cooperative with 
                //Date Time

                //extract the year, month and day ourselfs
                //out of the passed parameter value
                int theYear = (DateTime.Parse(reservationDate)).Year;
                int theMonth = (DateTime.Parse(reservationDate)).Month;
                int theDay = (DateTime.Parse(reservationDate)).Day;

                var results = from eventItem in context.SpecialEvents
                            orderby eventItem.Description
                            select new ReservationsByDate() //a new instance for each specialEvent row on the table
                            {
                                Description = eventItem.Description,
                                Reservations = from row in eventItem.Reservations
                                               where row.ReservationDate.Year == theYear
                                               && row.ReservationDate.Month == theMonth
                                               && row.ReservationDate.Day == theDay
                                               select new ReservationDetail() // a new instance for each reservation of a particular specialEvent code.
                                               {
                                                   CustomerName = row.CustomerName,
                                                   ReservationDate = row.ReservationDate,
                                                   NumberInParty = row.NumberInParty,
                                                   ContactPhone = row.ContactPhone,
                                                   ReservationStatus = row.ReservationStatus
                                               }
                            };
                return results.ToList();
            }
        }
        #endregion

        #region Add, Update, Delete of CRUD for CQRS

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void SpecialEvents_ADD(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                /* These methods are executed using an instance level item
                 * set up a instance pointer and initialize to null */
                SpecialEvent added = null;
                // setup the command to execute the add
                added = context.SpecialEvents.Add(item);
                // command is not executed until it is actually saved.
                context.SaveChanges();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]

        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                // Indicate the updating item instance
                // alter the Modified Status flag for this instance
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State = System.Data.Entity.EntityState.Modified;

                // command is not executed until it is actually saved.
                context.SaveChanges();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]

        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                // Lookup the instance and record if found
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);

                // Setup the command to execute the delete
                context.SpecialEvents.Remove(existing);

                //command is not executed until it is actually saved.
                context.SaveChanges();

            }
        }


        #endregion
    }
}
