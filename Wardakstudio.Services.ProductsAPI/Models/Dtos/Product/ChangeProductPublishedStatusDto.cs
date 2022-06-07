using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Product
{
    public class ChangeProductPublishedStatusDto : BaseDto
    {
        public bool? IsPublished { get; set; }
    }
}
