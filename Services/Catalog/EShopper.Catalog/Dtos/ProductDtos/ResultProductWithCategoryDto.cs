using EShopper.Catalog.Entities;

namespace E_Shopper.Catalog.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
