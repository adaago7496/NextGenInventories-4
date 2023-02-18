using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NextGenInventories_4.Models
{
    public class InventoryDate
    {
        public int InventoryDateId { get; set; }

        public string UserId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        [ValidateNever]
        public DateTime? DateAdded { get; set; }
        [DataType(DataType.Date)]
        [ValidateNever]
        public DateTime? DateModified { get; set; }
    }
}
