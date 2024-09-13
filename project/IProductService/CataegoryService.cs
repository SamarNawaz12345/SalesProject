using project.Components.Pages;
using project.Model;

namespace project.Services
{
    public class CataegoryService
    {
        private readonly HttpClient _httpClient;
        public CataegoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // Get all categories
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Category>>("https://localhost:7008/api/Category");
        }

        // Add a new category
        public async Task<Category> AddCategoryAsync(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7008/api/Category", category);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Category>();
        }

        // Update an existing category
        public async Task UpdateCategoryAsync(int id, Category category)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7008/{id}", category);
            response.EnsureSuccessStatusCode();
        }

        // Delete a category
        public async Task DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7008/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
