﻿using HealthCare.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.DataAccess.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public Specialization? Specialization { get; set; }
        [Required]
        public string? ContactNumber { get; set; }
        [Required]
        public string? OfficeAddress { get; set; }
        [Required]
        public string? UserId { get; set; }
        public List<TimeSlot>? AvailableTimeSlots { get; set; }
        public virtual AppUser? User { get; set; }
        public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
