using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopper.DtoLayer.CatalogDtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
    }
}
