using Microsoft.AspNetCore.Mvc;
using Assignment4.Models;
using System.Collections.Generic;

namespace Assignment4.Controllers
{
    public class HomeController : Controller
    {
        private readonly PrescriptionContext _context;

        public HomeController(PrescriptionContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Get all prescriptions
            List<Prescription> prescriptions = _context.Prescriptions.ToList();
            return View(prescriptions);
        }
    }
}
