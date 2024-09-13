using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Model;

namespace project.IProductService
{
    public class Salesmanservice
    {
        private readonly HttpClient _httpClient;

        public Salesmanservice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all salesmen
        public async Task<List<Salesman>> GetSalesmenAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Salesman>>("https://localhost:7008/api/Salesman");
        }
        // Get a specific salesman by ID
        public async Task<Salesman> GetSalesmanByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Salesman>($"https://localhost:7008/api/Salesman/{id}");
        }

        // Add a new salesman
        public async Task<Salesman> AddSalesmanAsync(Salesman salesman)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7008/api/Salesman", salesman);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Salesman>();
        }
        public async Task UpdateCurrentInvoiceNumberAsync(int salesmanId, string invoiceNumber)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7008/api/Settings/UpdateInvoiceNumberForSalesman", new
            {
                SalesmanId = salesmanId,
                CurrentInvoiceNumber = invoiceNumber
            });

            response.EnsureSuccessStatusCode();

        }

        // Update an existing salesman
        public async Task UpdateSalesmanAsync(int id, Salesman salesman)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7008/api/Salesman/{id}", salesman);
            response.EnsureSuccessStatusCode();
        }

        // Delete a salesman
        public async Task DeleteSalesmanAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7008/api/Salesman/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
