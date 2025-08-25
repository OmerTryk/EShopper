namespace E_Shopper.Catalog.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
    }
}
