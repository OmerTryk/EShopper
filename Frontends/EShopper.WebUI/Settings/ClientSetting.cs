namespace EShopper.WebUI.Settings
{
    public class ClientSetting
    {
        public Client VisitorClient { get; set; }
        public Client ManagerClient { get; set; }
        public Client AdminClient { get; set; }
    }
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
