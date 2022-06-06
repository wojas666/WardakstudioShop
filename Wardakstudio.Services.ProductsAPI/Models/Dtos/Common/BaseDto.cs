namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Common
{
    public abstract class BaseDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
