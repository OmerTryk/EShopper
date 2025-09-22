using EShopper.DtoLayer.CatalogDtos.OfferDtos;

namespace EShopper.WebUI.Services.CatalogService.OfferServices
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
