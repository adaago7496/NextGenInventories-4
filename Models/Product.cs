namespace NextGenInventories_4.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        [Display(Name ="Description")]
        public string ProductDescription { get; set; }

    }
}
