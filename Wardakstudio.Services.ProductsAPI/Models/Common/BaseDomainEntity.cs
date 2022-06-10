using System.ComponentModel.DataAnnotations;

namespace Wardakstudio.Services.ProductsAPI.Models.Common
{
    public abstract class BaseDomainEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime LastDateModified { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
