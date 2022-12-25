namespace PaginationWebApplication.Services
{
    public class ProductHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _domain;
        private const int c_ProductCountInOnePage = 5;

        public ProductHttpClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("product_client");
            _domain = configuration.GetSection("Domain").Value!;
        }

        // ТАК НЕ ДЕЛАЙТЕ!!!111!11
        public async Task<int?> GetProductCountAsync()
        {
            var result = await GetProductsAsync();

            if (result == null)
            {
                return null;
            }
            return result.Count / c_ProductCountInOnePage + 1;
        }

        public async Task<List<Product>?> GetProductsAsync()
        {
            var result = await _httpClient.GetAsync($"{_domain}/api/v1/product/all");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<List<Product>>();
            }

            return null;
        }

        public async Task<List<Product>?> GetPageAsync(int page)
        {
            if (page == 0)
            {
                return null;
            }

            int from = (c_ProductCountInOnePage * (page - 1)) + 1;
            int to = page * c_ProductCountInOnePage;

            var result = await _httpClient.GetAsync($"{_domain}/api/v1/product/range?from={from}&to={to}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<List<Product>>();
            }

            return null;
        }
    }
}
