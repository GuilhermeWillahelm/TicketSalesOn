using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TicketSalesOn.Models
{
    public class TicketSalesContext : DbContext
    {
        public TicketSalesContext(DbContextOptions<TicketSalesContext> options) : base(options) 
        { 
        }

        public DbSet<Users>? Users { get; set; } = null;
        public DbSet<MovieTheatreNetwork>? MovieTheatres { get; set; } = null;
        public DbSet<Rooms>? Rooms { get; set; }
        public DbSet<Movies>? Movies { get; set; }
        public DbSet<MovieTimes>? MoviesTimes { get; set; }
        public DbSet<ShoppingCart>? ShoppingCarts { get; set; }
        public DbSet<MovieChair>? MovieChairs { get; set; }
    }
}
