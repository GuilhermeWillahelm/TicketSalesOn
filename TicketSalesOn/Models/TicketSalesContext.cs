using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TicketSalesOn.Models
{
    public class TicketSalesContext : DbContext
    {
        public TicketSalesContext(DbContextOptions<TicketSalesContext> options) : base(options) 
        { 
        }

        public DbSet<Users> Users { get; set; } = null;
    }
}
