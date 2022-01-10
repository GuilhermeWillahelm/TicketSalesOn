using System.ComponentModel.DataAnnotations;

namespace TicketSalesOn.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Pass { get; set; }
    }
}
