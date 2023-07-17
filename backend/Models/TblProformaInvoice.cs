namespace TaskManagementSystem.Models
{
    public partial class TblProformaInvoice
    {
        public int ProformaInvNumber { get; set; }
        public int? BusinessId { get; set; }
        public DateTime? InvDate { get; set; }
        public string? InvoiceBy { get; set; }
        public DateTime? DueDate { get; set; }
        public string? InvStatus { get; set; }
        public string? InvNote { get; set; }
        public DateTime? LastModified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
