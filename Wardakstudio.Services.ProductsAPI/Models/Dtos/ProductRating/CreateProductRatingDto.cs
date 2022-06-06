namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductRating
{
    public class CreateProductRatingDto
    {
        public string AppraiserName { get; set; }

        public string Email { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }
    }
}
