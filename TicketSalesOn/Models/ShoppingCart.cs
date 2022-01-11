namespace TicketSalesOn.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public virtual Users? Users { get; set; }
        public virtual Rooms? Rooms { get; set; }
        public virtual MovieTimes? MovieTimes { get; set; }
        public string? TicketType { get; set; }
        public string? PaymentType { get; set; }
        public State state { get; set; }

        public enum State
        {
            Approved = 1,
            Disapproved = 0
        }
    }
}
