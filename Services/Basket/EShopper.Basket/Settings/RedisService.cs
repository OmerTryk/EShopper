using StackExchange.Redis;

namespace EShopper.Basket.Settings
{
    public class RedisService
    {
        public string _host { get; set; }
        public int _port { get; set; }
        private ConnectionMultiplexer _connection;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connection = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDatabase(int db = 1) => _connection.GetDatabase(0);
    }
}
