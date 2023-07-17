namespace TaskManagementSystem.Models
{
    public partial class TblInvoiceItem
    {
        public int Id { get; set; }
        public int? InvoiceNumber { get; set; }
        public int? ProductId { get; set; }
        public string? ProName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public int? Vat { get; set; }
        public DateTime? AddedDate { get; set; }
    }
}
