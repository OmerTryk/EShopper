using E_Shopper.Catalog.Dtos.OfferDtos;

namespace E_Shopper.Catalog.Services.OfferServices
{
    public interface IOfferService
    {
        Task<List<ResultOfferDto>> GetAllOfferAsync();
        Task CreateOfferAsync(CreateOfferDto createOfferDto);
        Task UpdateOfferAsync(UpdateOfferDto updateOfferDto);
        Task DeleteOfferAsync(string id);
        Task<GetByIdOfferDto> GetByIdOfferAsync(string id);
    }
}
