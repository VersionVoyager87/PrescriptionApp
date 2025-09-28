using Microsoft.EntityFrameworkCore;
using System;

namespace Assignment4.Models
{
    public class PrescriptionContext : DbContext
    {
        public PrescriptionContext(DbContextOptions<PrescriptionContext> options)
            : base(options)
        { }

        public DbSet<Prescription> Prescriptions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    PrescriptionId = 1,
                    MedicationName = "Atorvastatin",
                    FillStatus = "New",
                    Cost = 19.99m,
                    RequestTime = new DateTime(2025, 9, 1, 9, 0, 0)
                },
                new Prescription
                {
                    PrescriptionId = 2,
                    MedicationName = "Metformin",
                    FillStatus = "Filled",
                    Cost = 12.50m,
                    RequestTime = new DateTime(2025, 9, 5, 14, 30, 0)
                },
                new Prescription
                {
                    PrescriptionId = 3,
                    MedicationName = "Lisinopril",
                    FillStatus = "Pending",
                    Cost = 8.75m,
                    RequestTime = new DateTime(2025, 9, 10, 8, 15, 0)
                }
            );
        }
    }
}
