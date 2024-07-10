using CreditBusinessLayer.Services.Abstractions;
using CreditBusinessLayer.Services.Concretes;
using CreditEntityLayer.DTOs.Customer;
using CreditEntityLayer.DTOs.Guarantor;
using Microsoft.AspNetCore.Mvc;

namespace CreditApp.Controllers
{
    public class GuarantorController : Controller
    {
        private readonly IGuarantorService _guarantorService;

        public GuarantorController(IGuarantorService guarantorService)
        {
            _guarantorService = guarantorService;
        }

        public async Task<IActionResult> Index()
        {
            var guarantors= await _guarantorService.GetAllGuarantors();

            return View(guarantors);
        }

        [HttpGet]
        public async Task<IActionResult> GuarantorDetails(int? id)
        {
            if (id is null)
                return BadRequest();

            var guarantorDetails = await _guarantorService.GetGuarantorByIdAsync(id);
            if (guarantorDetails is null)
                return NotFound();

            return View(guarantorDetails);
        }

        [HttpGet]
        public IActionResult AddGuarantor(int? loanId)
        {
            if (loanId == null)
                return BadRequest();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuarantor(GuarantorAddDto guarantorAddDto)
        {
            if(guarantorAddDto is null)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(ModelState);

            var guarantor = await _guarantorService.AddGuarantorAsync(guarantorAddDto);

            if (guarantor == "null")
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
