namespace TaskManagementSystem.Models
{
    public partial class TblPayment
    {
        public int Id { get; set; }
        public int? InvoiceNumber { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? PaidBy { get; set; }
        public string? ReceivedBy { get; set; }
        public string? PayNote { get; set; }
        public decimal? Balance { get; set; }
    }
}
