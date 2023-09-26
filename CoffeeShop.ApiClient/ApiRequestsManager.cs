namespace CoffeeShop.ApiClient
{
    public class ApiRequestsManager
    {
        private static ApiRequestsManager _instance;
        private static readonly object _instanceLock = new();
        private static string _baseUrl;
        private readonly HttpClient _client;
        public static ApiRequestsManager Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    return _instance ?? throw new InvalidOperationException("Not initialized");
                }
            }
            private set 
            { 
                _instance = value; 
            }
        }

        public static void Initialize(string baseUrl)
        {
            _baseUrl = baseUrl;
            _instance = new ApiRequestsManager();
        }

        private ApiRequestsManager()
        {
            _client = new HttpClient();
        }
    }
}