using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblCustomerBusiness
    {
        public int BusinessId { get; set; }
        public int CustomerId { get; set; }
        public string BusName { get; set; } = null!;
        public string? BusTelephone { get; set; }
        public string? BusAddress { get; set; }
        public string? Postcode { get; set; }
        public int ServiceTypeId { get; set; }
        public DateTime? ProvidedDate { get; set; }
        public string? BusNote { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentFrequent { get; set; }
        public decimal? Amount { get; set; }
        public int? Salesperson { get; set; }
        public int? NoOfMonths { get; set; }
        public int? PropertyNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? AccountBalance { get; set; }
        public bool? IsActive { get; set; }
        public string? InActiveReason { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
