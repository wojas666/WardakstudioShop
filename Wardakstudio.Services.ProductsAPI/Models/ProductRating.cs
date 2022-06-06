using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductRating
    {
        [Key]
        public int Id { get; set; }

        public string AppraiserName { get; set; }

        public string Email { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public Product Product { get; set; }

        public DateTime RatingDate { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public bool IsApproved { get; set; }
    }
}
