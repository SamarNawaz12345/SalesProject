namespace project.Model
{
    public class Invoice
    {
        public int CurrentInvoiceNumber { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public int PurchasedQuantity { get; set; }
        public decimal TotalIncludingTax
        {
            get
            {
                // Calculate total including tax
                return (Price * PurchasedQuantity) + Tax;
            }
        }
        // Calculated property for total amount without tax
        public decimal TotalAmount
        {
            get
            {
                return Price * PurchasedQuantity;
            }
        }
    }
}
