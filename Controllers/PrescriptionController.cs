using Microsoft.AspNetCore.Mvc;
using Assignment4.Models;
using System;

namespace Assignment4.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly PrescriptionContext context;

        public PrescriptionController(PrescriptionContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.FillStatusList = new[] { "New", "Filled", "Pending" };
            return View("Edit", new Prescription
            {
                FillStatus = "New",
                RequestTime = DateTime.Now
            });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.FillStatusList = new[] { "New", "Filled", "Pending" };
            var prescription = context.Prescriptions.Find(id);
            return View(prescription);
        }

        [HttpPost]
        public IActionResult Edit(Prescription prescription)
        {
            ViewBag.FillStatusList = new[] { "New", "Filled", "Pending" };

            if (ModelState.IsValid)
            {
                if (prescription.PrescriptionId == 0)
                {
                    prescription.RequestTime = DateTime.Now;
                    context.Prescriptions.Add(prescription);
                }
                else
                {
                    context.Prescriptions.Update(prescription);
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (prescription.PrescriptionId == 0) ? "Add" : "Edit";
                return View(prescription);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prescription = context.Prescriptions.Find(id);
            return View(prescription);
        }

        [HttpPost]
        public IActionResult Delete(Prescription prescription)
        {
            context.Prescriptions.Remove(prescription);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
