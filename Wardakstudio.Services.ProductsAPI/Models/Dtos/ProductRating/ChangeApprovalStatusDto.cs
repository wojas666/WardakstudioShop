using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductRating
{
    public class ChangeApprovalStatusDto : BaseDto
    {
        public bool? IsApproved { get; set; }
    }
}
