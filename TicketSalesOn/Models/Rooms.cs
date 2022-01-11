namespace TicketSalesOn.Models
{
    public class Rooms
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string Map { get; set; } = string.Empty;
        public virtual MovieTheatreNetwork? MovieTheatre { get; set; }
        public virtual MovieChair? MovieChair { get; set; }
    }
}
