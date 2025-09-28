using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "Please enter a medication name.")]
        [StringLength(100, ErrorMessage = "Medication name cannot exceed 100 characters.")]
        public string MedicationName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a fill status.")]
        public string FillStatus { get; set; } = "New";

        [Required(ErrorMessage = "Please enter a cost.")]
        [Range(0.01, 1000, ErrorMessage = "Cost must be greater than 0.")]
        public decimal? Cost { get; set; }

        [Required]
        public DateTime RequestTime { get; set; }
    }
}
