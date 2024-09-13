using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using project.Data;

namespace ProdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly AppDbContext _context; // Inject the DbContext
        private static string _invoiceNumber = "00000000"; // Default value
        public SettingsController(AppDbContext context)
        {
            _context = context;
        }


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(new { InvoiceNumber = _invoiceNumber });
        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Fetch the first Salesman record from the database
            var salesman = await _context.Salesmens.FirstOrDefaultAsync();

            if (salesman == null)
            {
                return NotFound("Salesman not found.");
            }

            // Get the SetInvoiceNumber from the Salesman table, and if it's null, use the default value "00000000"
            var invoiceNumber = salesman.SetInvoiceNumber ?? "00000000";

            // Return the invoice number to be used in the settings page
            return Ok(new { InvoiceNumber = invoiceNumber });
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceSettings settings)
        {
            if (settings == null || settings.InvoiceNumber.Length != 8)
            {
                return BadRequest("Invalid invoice number.");
            }

            // Update the default invoice number
            _invoiceNumber = settings.InvoiceNumber;

            // Now update the Salesman table with this invoice number
            var salesman = await _context.Salesmens.FirstOrDefaultAsync();
            if (salesman == null)
            {
                return NotFound("Salesman not found.");
            }

            // Set the new invoice number in the Salesman table
            salesman.SetInvoiceNumber = _invoiceNumber;

            // Save changes to the database
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database update failed: {ex.Message}");
            }

            return Ok("Invoice number updated and saved to Salesman.");
        }

        /// Update
        [HttpPost("UpdateInvoiceNumberForSalesman")]
        public async Task<IActionResult> UpdateInvoiceNumberForSalesman([FromBody] UpdateInvoiceRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.CurrentInvoiceNumber))
            {
                return BadRequest("Invalid request.");
            }

            var salesman = await _context.Salesmens.FindAsync(request.SalesmanId);
            if (salesman == null)
            {
                return NotFound("Salesman not found.");
            }

            // Update the invoice number for the salesman
            salesman.CurrentInvoiceNumber = request.CurrentInvoiceNumber;

            // Save changes
            await _context.SaveChangesAsync();

            return Ok("Invoice number updated.");
        }

        public class UpdateInvoiceRequest
        {
            public int SalesmanId { get; set; }
            public string CurrentInvoiceNumber { get; set; }
        }

        public class InvoiceSettings
        {
            public string InvoiceNumber { get; set; }
        }
    }
}
