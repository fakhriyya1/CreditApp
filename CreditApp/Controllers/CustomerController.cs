using CreditBusinessLayer.Services.Abstractions;
using CreditEntityLayer.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CreditApp.Controllers
{
	public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomersAsync();

            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDetails(int? id)
        {
            if(id is null)
                return BadRequest();

            var customerDetails=await _customerService.GetCustomerByIdAsync(id);
            if(customerDetails is null)
                return NotFound();

            return View(customerDetails);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerAddDto customerAdd)
        {
            if (customerAdd is null)
                return BadRequest("CustomerAddDto object is null");

            var customerEntity = await _customerService.Exists(customerAdd);
            if (customerEntity != null)
                ModelState.AddModelError("PIN", "This customer already exists!");

            if (!ModelState.IsValid)
                return View(customerAdd);

            await _customerService.CreateCustomerAsync(customerAdd);

            return RedirectToAction(nameof(Index));
        }
    }
}
