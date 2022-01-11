namespace TicketSalesOn.Models
{
    public class MovieTimes
    {

        public int Id { get; set; }
        public DateTime Schedules { get; set; }
        public virtual Movies? movies { get; set; }
        public virtual Rooms? rooms { get; set; }
       
    }
}
