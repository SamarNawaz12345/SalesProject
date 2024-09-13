namespace project.IProductService
{
    public interface ISettingsService
    {
        Task<string> GetInvoiceNumberAsync();
        Task<bool> SetInvoiceNumberAsync(string invoiceNumber);
    }
    public class SettingService : ISettingsService
    {
        private static string _invoiceNumber = "00000000"; // Default value

        public Task<string> GetInvoiceNumberAsync()
        {
            return Task.FromResult(_invoiceNumber);
        }

        public Task<bool> SetInvoiceNumberAsync(string invoiceNumber)
        {
            if (string.IsNullOrEmpty(invoiceNumber) || invoiceNumber.Length != 8)
            {
                return Task.FromResult(false);
            }

            _invoiceNumber = invoiceNumber;
            return Task.FromResult(true);
        }

    }
}

