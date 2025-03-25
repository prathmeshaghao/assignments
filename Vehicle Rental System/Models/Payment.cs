﻿namespace Vehicle_Rental_System.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }

        // Navigation Property
        public Booking Booking { get; set; }
    }
}
