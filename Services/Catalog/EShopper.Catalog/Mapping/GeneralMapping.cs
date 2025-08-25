using AutoMapper;
using E_Shopper.Catalog.Dtos.AboutDtos;
using E_Shopper.Catalog.Dtos.CatagoryDtos;
using E_Shopper.Catalog.Dtos.CategoryDtos;
using E_Shopper.Catalog.Dtos.ContactDtos;
using E_Shopper.Catalog.Dtos.FeatureDtos;
using E_Shopper.Catalog.Dtos.FeatureSliderDtos;
using E_Shopper.Catalog.Dtos.OfferDtos;
using E_Shopper.Catalog.Dtos.ProductDetailDtos;
using E_Shopper.Catalog.Dtos.ProductDtos;
using E_Shopper.Catalog.Dtos.VendorBrandDtos;
using E_Shopper.Catalog.Entities;
using EShopper.Catalog.Entities;

namespace E_Shopper.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ResultProductDetailByProductId>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();

            CreateMap<Offer, ResultOfferDto>().ReverseMap();
            CreateMap<Offer, CreateOfferDto>().ReverseMap();
            CreateMap<Offer, UpdateOfferDto>().ReverseMap();
            CreateMap<Offer, GetByIdOfferDto>().ReverseMap();

            CreateMap<VendorBrand, GetByIdVendorBrandDto>().ReverseMap();
            CreateMap<VendorBrand, CreateVendorBrandDto>().ReverseMap();
            CreateMap<VendorBrand, UpdateVendorBrandDto>().ReverseMap();
            CreateMap<VendorBrand, ResultVendorBrandDto>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();

            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();


        }
    }
}
