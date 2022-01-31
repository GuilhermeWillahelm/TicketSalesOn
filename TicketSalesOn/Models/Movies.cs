using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSalesOn.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string TitleMovie { get; set; } = string.Empty;
        public string ImageMovie { get; set; } = string.Empty;
        public DateTime PremiereDate { get; set; }
        public DateTime PreviewDate { get; set; }
    }
}
