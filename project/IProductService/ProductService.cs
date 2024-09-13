using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using project.Model;

namespace project.IProductService
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<Category> GetCategoryByIdAsync(int categoryId)
        //{
        //    var response = await _httpClient.GetAsync($"http://localhost:7008/api/categories/{categoryId}"); // Call Category API
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadFromJsonAsync<Category>();
        //}
        // Search products by first character
        // Method to search products by first letter
        
        public async Task<List<Product>> SearchProductsAsync(string query)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7008/api/Prod/search?query={query}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Product>>();
        }
        public async Task UpdateProductQuantityAsync(int productId, int updatedQuantity)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7008/api/Prod/{productId}/updateQuantity", new { Quantity = updatedQuantity });

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to update the product quantity.");
            }
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
