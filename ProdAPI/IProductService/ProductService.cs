using project.Model;

namespace ProdAPI.IProductService
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>("https://localhost:7008/api/Prod");
            return response;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Product>($"https://localhost:7008/api/Prod/{id}");
            return response;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7008/api/Prod", product);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7008/api/Prod/{product.Id}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7008/api/Prod/{id}");
            return response.IsSuccessStatusCode;
        }
     

    }
}
