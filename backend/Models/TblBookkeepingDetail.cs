namespace TaskManagementSystem.Models
{
    public partial class TblBookkeepingDetail
    {
        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Vendor { get; set; } = null!;
        public DateTime BillDate { get; set; }
        public decimal Total { get; set; }
        public decimal Btw6 { get; set; }
        public decimal Btw21 { get; set; }
        public string TranType { get; set; } = null!;
        public string InvNo { get; set; } = null!;
    }
}
