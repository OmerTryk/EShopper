using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopper.Shipping.DtoLayer.Dtos.CargoCustomerDtos
{
    public class UpdateCargoCustomerDto
    {
        public int CargoCustomerId { get; set; }
        public int CargoCustomerName { get; set; }
        public int CargoCustomerSurname { get; set; }
        public int CargoCustomerEmail { get; set; }
        public int CargoCustomerPhone { get; set; }
        public int CargoCustomerDistrict { get; set; }
        public int CargoCustomerCity { get; set; }
        public int CargoCustomerAddress { get; set; }
    }
}
