namespace TaskManagementSystem.Models
{
    public partial class TblBarcode
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Barcode { get; set; } = null!;
    }
}
