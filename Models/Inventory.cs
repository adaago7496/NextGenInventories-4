using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NextGenInventories_4.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        public string UserId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
