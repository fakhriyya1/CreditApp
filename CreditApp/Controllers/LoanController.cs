using CreditBusinessLayer.Services.Abstractions;
using CreditBusinessLayer.Services.Concretes;
using CreditEntityLayer.DTOs.Loan;
using CreditEntityLayer.Entities;
using CreditEntityLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Drawing;

namespace CreditApp.Controllers
{

    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IPdfService _pdfService;
        private readonly ICustomerService _customerService;
        private readonly ILoanCalculatorService _loanCalculatorService;

        public LoanController(ILoanService loanService, ILoanCalculatorService loanCalculatorService, IPdfService pdfService, ICustomerService customerService)
        {
            _loanService = loanService;
            _loanCalculatorService = loanCalculatorService;
            _pdfService = pdfService;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var loansDto = await _loanService.GetAllLoansAsync();

            return View(loansDto);
        }

        [HttpGet]
        public IActionResult AddLoan(int? customerId)
        {
            ViewBag.CurrencyList = Enum.GetValues(typeof(Currency)).Cast<Currency>()
                                    .Select(e => new SelectListItem
                                    {
                                        Value = ((int)e).ToString(),
                                        Text = e.ToString()
                                    }).ToList();

            if (customerId is null)
                return BadRequest();

            var model = new LoanDetailAddDto
            {
                CustomerId = customerId.Value
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddLoan(LoanDetailAddDto loanDetailAdd)
        {
            ViewBag.CurrencyList = Enum.GetValues(typeof(Currency)).Cast<Currency>()
                                   .Select(e => new SelectListItem
                                   {
                                       Value = ((int)e).ToString(),
                                       Text = e.ToString()
                                   }).ToList();

            if (loanDetailAdd is null || loanDetailAdd.CustomerId == 0)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(loanDetailAdd);

            var loan = await _loanService.AddLoanAsync(loanDetailAdd);
            if (loan == "null")
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ViewAmortization(int id)
        {
            var result = await _loanCalculatorService.CalculateLoan(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> PendingRequests()
        {
            var loans = await _loanService.GetPendingLoansAsync();

            return View(loans);
        }

        [HttpGet]
        public async Task<IActionResult> Approve(int? id)
        {
            if (id is null)
                return BadRequest();

            var loan = await _loanService.ApproveRequest((int)id);
            if (loan == "null")
                return NotFound();

            return RedirectToAction(nameof(PendingRequests));
        }

        [HttpPost]
        public async Task<IActionResult> Decline(int? id, string reason)
        {
            if (id is null)
                return BadRequest();

            var loan = await _loanService.DeclineRequest((int)id, reason);
            if (loan == "null")
                return NotFound();

            return RedirectToAction(nameof(PendingRequests));
        }

        public async Task<IActionResult> DownloadPdf(int id)
        {
            var loanResult = await _loanCalculatorService.CalculateLoan(id);

            MemoryStream stream = _pdfService.GenerateLoanPdf(loanResult);

            return File(stream, "application/pdf", "AmortizationTable.pdf");
        }
    }
}

