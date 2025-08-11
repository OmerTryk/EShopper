namespace EShopper.Basket.Dtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public List<BasketItemDto> BasketItemDtos { get; set; }
        public decimal TotalPrice { get => BasketItemDtos.Sum(x => x.Quantity * x.Price); }
    }
}
