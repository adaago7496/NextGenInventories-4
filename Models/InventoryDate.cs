using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

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
        [Display(Name ="Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        [Display(Name ="Date Modified")]
        [DataType(DataType.Date)]
        public DateTime? DateModified { get; set; }
    }
}
