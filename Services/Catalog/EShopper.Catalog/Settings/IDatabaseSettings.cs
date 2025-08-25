namespace E_Shopper.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string FeatureSliderCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string OfferCollectionName { get; set; }
        public string VendorBrandCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
