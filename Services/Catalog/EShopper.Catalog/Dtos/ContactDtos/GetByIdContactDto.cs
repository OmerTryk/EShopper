namespace E_Shopper.Catalog.Dtos.ContactDtos
{
    public class GetByIdContactDto
    {
        public string ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; } 
        public bool IsRead { get; set; }
    }
}
