using System.ComponentModel.DataAnnotations.Schema;

namespace DOTNET_6.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsBooked { get; set; }

        [NotMapped]
        public User BookedBy { get; set; }

    }
}
