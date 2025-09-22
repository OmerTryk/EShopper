using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopper.DtoLayer.CatalogDtos.OfferDtos
{
    public class GetByIdOfferDto
    {
        public string OfferId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }
}
