using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
{
    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAlarm> TblAlarms { get; set; } = null!;
        public virtual DbSet<TblBarcode> TblBarcodes { get; set; } = null!;
        public virtual DbSet<TblBookkeepingDetail> TblBookkeepingDetails { get; set; } = null!;
        public virtual DbSet<TblCallLog> TblCallLogs { get; set; } = null!;
        public virtual DbSet<TblCanceledReason> TblCanceledReasons { get; set; } = null!;
        public virtual DbSet<TblCctv> TblCctvs { get; set; } = null!;
        public virtual DbSet<TblCustomerBusiness> TblCustomerBusinesses { get; set; } = null!;
        public virtual DbSet<TblCustomerGroup> TblCustomerGroups { get; set; } = null!;
        public virtual DbSet<TblCustomerInfo> TblCustomerInfos { get; set; } = null!;
        public virtual DbSet<TblDailyTask> TblDailyTasks { get; set; } = null!;
        public virtual DbSet<TblDepartment> TblDepartments { get; set; } = null!;
        public virtual DbSet<TblEstimate> TblEstimates { get; set; } = null!;
        public virtual DbSet<TblHoWebLicence> TblHoWebLicences { get; set; } = null!;
        public virtual DbSet<TblHoWebLoginRequest> TblHoWebLoginRequests { get; set; } = null!;
        public virtual DbSet<TblInstallation> TblInstallations { get; set; } = null!;
        public virtual DbSet<TblInvoice> TblInvoices { get; set; } = null!;
        public virtual DbSet<TblInvoiceItem> TblInvoiceItems { get; set; } = null!;
        public virtual DbSet<TblLicence> TblLicences { get; set; } = null!;
        public virtual DbSet<TblLight> TblLights { get; set; } = null!;
        public virtual DbSet<TblLogNote> TblLogNotes { get; set; } = null!;
        public virtual DbSet<TblMobileDevice> TblMobileDevices { get; set; } = null!;
        public virtual DbSet<TblMobileLicence> TblMobileLicences { get; set; } = null!;
        public virtual DbSet<TblMobileLoginRequest> TblMobileLoginRequests { get; set; } = null!;
        public virtual DbSet<TblMobileUser> TblMobileUsers { get; set; } = null!;
        public virtual DbSet<TblPayment> TblPayments { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblProformaInvoice> TblProformaInvoices { get; set; } = null!;
        public virtual DbSet<TblSalesCallLog> TblSalesCallLogs { get; set; } = null!;
        public virtual DbSet<TblServiceType> TblServiceTypes { get; set; } = null!;
        public virtual DbSet<TblStockAdjustment> TblStockAdjustments { get; set; } = null!;
        public virtual DbSet<TblSubDepartment> TblSubDepartments { get; set; } = null!;
        public virtual DbSet<TblSupport> TblSupports { get; set; } = null!;
        public virtual DbSet<TblTempTicketNoteUpload> TblTempTicketNoteUploads { get; set; } = null!;
        public virtual DbSet<TblTicketNoteUpload> TblTicketNoteUploads { get; set; } = null!;
        public virtual DbSet<TblTillInfo> TblTillInfos { get; set; } = null!;
        public virtual DbSet<TblUnregisteredBusiness> TblUnregisteredBusinesses { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<TblUserLoginHistory> TblUserLoginHistories { get; set; } = null!;
        public virtual DbSet<TblVersionDownloadFailLog> TblVersionDownloadFailLogs { get; set; } = null!;
        public virtual DbSet<ViSelectAllBusiness> ViSelectAllBusinesses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TC_Backoffice_Test;Integrated Security=True;User ID=sa;Password=anymouse;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<TblAlarm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblAlarm");

                entity.Property(e => e.AlarmNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("alarmNote");

                entity.Property(e => e.BusinessId).HasColumnName("businessID");

                entity.Property(e => e.HardwareInfo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("hardwareInfo");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InstalledBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("installedBy")
                    .IsFixedLength();

                entity.Property(e => e.InstalledDate)
                    .HasColumnType("datetime")
                    .HasColumnName("installedDate");
            });

            modelBuilder.Entity<TblBarcode>(entity =>
            {
                entity.HasKey(e => e.Barcode)
                    .HasName("PK__tblBarco__C16E36F925518C17");

                entity.ToTable("tblBarcodes");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("barcode");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("productID");
            });

            modelBuilder.Entity<TblBookkeepingDetail>(entity =>
            {
                entity.ToTable("tblBookkeepingDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BillDate)
                    .HasColumnType("datetime")
                    .HasColumnName("billDate");

                entity.Property(e => e.Btw21)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("BTW21");

                entity.Property(e => e.Btw6)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("BTW6");

                entity.Property(e => e.InvNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("invNo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Total).HasColumnType("decimal(15, 4)");

                entity.Property(e => e.TranType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tranType")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.Vendor)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCallLog>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__tblCallL__3333C67015502E78");

                entity.ToTable("tblCallLogs");

                entity.Property(e => e.TicketId).HasColumnName("ticketID");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("appointmentDate")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.AppointmentType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("appointmentType")
                    .HasDefaultValueSql("('No Appointment')")
                    .IsFixedLength();

                entity.Property(e => e.AssignedTo).HasColumnName("assignedTo");

                entity.Property(e => e.BusinessId).HasColumnName("businessID");

                entity.Property(e => e.BusinessType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("businessType")
                    .IsFixedLength();

                entity.Property(e => e.CallType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("callType")
                    .IsFixedLength();

                entity.Property(e => e.ClCustomerId).HasColumnName("clCustomerID");

                entity.Property(e => e.ClosedBy)
                    .HasColumnName("closedBy")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClosedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("closedDate")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.InitialNote)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("initialNote");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastUpdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OpenBy).HasColumnName("openBy");

                entity.Property(e => e.OpenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("openDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ServiceType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("serviceType")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('Open')")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblCanceledReason>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblCanceledReasons");

                entity.Property(e => e.CanceledDate)
                    .HasColumnType("datetime")
                    .HasColumnName("canceledDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CanceledReasons)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("canceledReasons");

                entity.Property(e => e.TicketId).HasColumnName("ticketID");
            });

            modelBuilder.Entity<TblCctv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblCCTV");

                entity.Property(e => e.BusinessId).HasColumnName("businessID");

                entity.Property(e => e.CctvNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("cctvNote");

                entity.Property(e => e.HardwareInfo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("hardwareInfo");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InstalledBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("installedBy")
                    .IsFixedLength();

                entity.Property(e => e.InstalledDate)
                    .HasColumnType("datetime")
                    .HasColumnName("installedDate");
            });

            modelBuilder.Entity<TblCustomerBusiness>(entity =>
            {
                entity.HasKey(e => e.BusinessId)
                    .HasName("PK__tblCusto__3C08D4E20519C6AF");

                entity.ToTable("tblCustomerBusiness");

                entity.HasIndex(e => e.BusTelephone, "idxDuplicateBusinessTelephone")
                    .IsUnique()
                    .HasFilter("([busTelephone]<>'' AND [busTelephone]<>'0')");

                entity.HasIndex(e => new { e.PropertyNo, e.Postcode }, "idxDuplicatePostcodeAndPropertyNo")
                    .IsUnique()
                    .HasFilter("([Postcode]<>'' AND [propertyNo]<>(0))");

                entity.Property(e => e.BusinessId).HasColumnName("businessID");

                entity.Property(e => e.AccountBalance)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("accountBalance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.BusAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("busAddress");

                entity.Property(e => e.BusName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("busName");

                entity.Property(e => e.BusNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("busNote");

                entity.Property(e => e.BusTelephone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("busTelephone")
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.InActiveReason)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("inActiveReason");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NoOfMonths).HasColumnName("noOfMonths");

                entity.Property(e => e.PaymentFrequent)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("paymentFrequent")
                    .IsFixedLength();

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("paymentMethod")
                    .IsFixedLength();

                entity.Property(e => e.Postcode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PropertyNo).HasColumnName("propertyNo");

                entity.Property(e => e.ProvidedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("providedDate");

                entity.Property(e => e.Salesperson).HasColumnName("salesperson");

                entity.Property(e => e.ServiceTypeId).HasColumnName("serviceTypeID");
            });

            modelBuilder.Entity<TblCustomerGroup>(entity =>
            {
                entity.HasKey(e => new { e.CusGroupId, e.CusGroupName })
                    .HasName("PK_CustomerGroup");

                entity.ToTable("tblCustomerGroup");

                entity.Property(e => e.CusGroupId).HasColumnName("cusGroupID");

                entity.Property(e => e.CusGroupName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cusGroupName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblCustomerInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__tblCusto__B611CB9D7F60ED59");

                entity.ToTable("tblCustomerInfo");

                entity.HasIndex(e => e.CusEmail, "idxDuplicateCustomerEmail")
                    .IsUnique()
                    .HasFilter("([cusEmail]<>'')");

                entity.HasIndex(e => e.CusMobile, "idxDuplicateCustomerMobile")
                    .IsUnique()
                    .HasFilter("([cusMobile]<>'' AND [cusMobile]<>'0')");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("createdBy")
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.CusEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cusEmail");

                entity.Property(e => e.CusGroupId).HasColumnName("cusGroupID");

                entity.Property(e => e.CusMobile)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cusMobile")
                    .IsFixedLength();

                entity.Property(e => e.CusName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cusName");

                entity.Property(e => e.CusNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("cusNote");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblDailyTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__tblDaily__DD5D55A202084FDA");

                entity.ToTable("tblDailyTasks");

                entity.Property(e => e.TaskId)
                    .ValueGeneratedNever()
                    .HasColumnName("taskID");

                entity.Property(e => e.LastRunDate)
                    .HasColumnType("date")
                    .HasColumnName("lastRunDate");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("taskName");
            });

            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__tblDepar__F9B8344D2A164134");

                entity.ToTable("tblDepartment");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("createdBy")
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("depDescription");

                entity.Property(e => e.DepName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("depName");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("modifiedBy")
                    .IsFixedLength();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Vat).HasColumnName("VAT");
            });

            modelBuilder.Entity<TblEstimate>(entity =>
            {
                entity.HasKey(e => e.EstimateNumber)
                    .HasName("PK__tblEstim__1D8F310255F4C372");

                entity.ToTable("tblEstimate");

                entity.Property(e => e.EstimateNumber).HasColumnName("estimateNumber");

                entity.Property(e => e.BusinessId)
                    .HasColumnName("businessID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConvertedInvoice)
                    .HasColumnName("convertedInvoice")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvDate)
                    .HasColumnType("datetime")
                    .HasColumnName("invDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvNote)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("invNote");

                entity.Property(e => e.InvStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("invStatus")
                    .HasDefaultValueSql("('DRAFT')")
                    .IsFixedLength();

                entity.Property(e => e.InvoiceBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("invoiceBy")
                    .IsFixedLength();

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasColumnName("lastModified")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("modifiedBy")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblHoWebLicence>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblHO_WebLicence");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IssuedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("issuedBy");

                entity.Property(e => e.LicEnding)
                    .HasColumnType("date")
                    .HasColumnName("licEnding");

                entity.Property(e => e.LicIssued)
                    .HasColumnType("date")
                    .HasColumnName("licIssued")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblHoWebLoginRequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblHO_WebLoginRequest");

                entity.Property(e => e.Customer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblInstallation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblInstallation");

                entity.Property(e => e.EquipmentsDetails)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("equipmentsDetails");

                entity.Property(e => e.InstallationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("installationDate");

                entity.Property(e => e.Installer)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("installer")
                    .IsFixedLength();

                entity.Property(e => e.JobRef)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("jobRef")
                    .IsFixedLength();

                entity.Property(e => e.TicketId).HasColumnName("ticketID");
            });

            modelBuilder.Entity<TblInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNumber)
                    .HasName("PK__tblInvoi__C72749EF7755B73D");

                entity.ToTable("tblInvoice");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoiceNumber");

                entity.Property(e => e.BusinessId)
                    .HasColumnName("businessID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dueDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvDate)
                    .HasColumnType("datetime")
                    .HasColumnName("invDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvNote)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("invNote");

                entity.Property(e => e.InvStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("invStatus")
                    .HasDefaultValueSql("('DRAFT')")
                    .IsFixedLength();

                entity.Property(e => e.InvoiceBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("invoiceBy")
                    .IsFixedLength();

                entity.Property(e => e.IsStandingOrder).HasColumnName("isStandingOrder");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasColumnName("lastModified")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("modifiedBy")
                    .IsFixedLength();

                entity.Property(e => e.ProformaInvLink)
                    .HasColumnName("proformaInvLink")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RefundLink)
                    .HasColumnName("refundLink")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblInvoiceItem>(entity =>
            {
                entity.ToTable("tblInvoiceItems");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("addedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoiceNumber");

                entity.Property(e => e.ProName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proName");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("unitPrice");

                entity.Property(e => e.Vat).HasColumnName("VAT");
            });

            modelBuilder.Entity<TblLicence>(entity =>
            {
                entity.ToTable("tblLicence");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BusinessId).HasColumnName("businessID");

                entity.Property(e => e.Computer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("computer");

                entity.Property(e => e.IssuedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("issuedBy")
                    .IsFixedLength();

                entity.Property(e => e.LicenceExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("licenceExpiryDate");

                entity.Property(e => e.LicenceIssuedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("licenceIssuedDate");

                entity.Property(e => e.LicenceKey)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("licenceKey");

                entity.Property(e => e.TillName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tillName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblLight>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblLight");

                entity.Property(e => e.BusinessId).HasColumnName("businessID");

                entity.Property(e => e.HardwareInfo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("hardwareInfo");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InstalledBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("installedBy")
                    .IsFixedLength();

                entity.Property(e => e.InstalledDate)
                    .HasColumnType("datetime")
                    .HasColumnName("installedDate");

                entity.Property(e => e.LightNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("lightNote");
            });

            modelBuilder.Entity<TblLogNote>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblLogNotes");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("appointmentDate");

                entity.Property(e => e.AppointmentType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("appointmentType")
                    .IsFixedLength();

                entity.Property(e => e.AssignedTo).HasColumnName("assignedTo");

                entity.Property(e => e.LogBy).HasColumnName("logBy");

                entity.Property(e => e.LogDate)
                    .HasColumnType("datetime")
                    .HasColumnName("logDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.NoteId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("noteID");

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.Property(e => e.TicketId).HasColumnName("ticketID");
            });

            modelBuilder.Entity<TblMobileDevice>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PK__tblMobil__65A475E73BFFE745");

                entity.ToTable("tblMobileDevices");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UUID");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.LicEnding)
                    .HasColumnType("date")
                    .HasColumnName("licEnding")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMobileLicence>(entity =>
            {
                entity.ToTable("tblMobileLicence");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IssuedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("issuedBy");

                entity.Property(e => e.LicEnding)
                    .HasColumnType("date")
                    .HasColumnName("licEnding")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LicIssued)
                    .HasColumnType("date")
                    .HasColumnName("licIssued")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UUID");
            });

            modelBuilder.Entity<TblMobileLoginRequest>(entity =>
            {
                entity.ToTable("tblMobileLoginRequest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Customer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UUID")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblMobileUser>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__tblMobil__65A475E7214BF109");

                entity.ToTable("tblMobileUsers");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BusId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BusID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.LicEnding)
                    .HasColumnType("date")
                    .HasColumnName("licEnding")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserEmailaddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatus).HasColumnName("userStatus");

                entity.Property(e => e.UserStatusKey)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userStatusKey");
            });

            modelBuilder.Entity<TblPayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblPayment");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoiceNumber");

                entity.Property(e => e.PaidBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("paidBy")
                    .IsFixedLength();

                entity.Property(e => e.PaidDate)
                    .HasColumnType("datetime")
                    .HasColumnName("paidDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PayNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("payNote");

                entity.Property(e => e.ReceivedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("receivedBy")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tblProdu__2D10D14A1CBC4616");

                entity.ToTable("tblProducts");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("productID");

                entity.Property(e => e.CostPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("costPrice");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("createdBy")
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.InstallerPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("installerPrice");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("modifiedBy")
                    .IsFixedLength();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("proDescription");

                entity.Property(e => e.ProName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proName");

                entity.Property(e => e.RetailPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("retailPrice");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SubDepartmentId)
                    .HasColumnName("subDepartmentID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblProformaInvoice>(entity =>
            {
                entity.HasKey(e => e.ProformaInvNumber)
                    .HasName("PK__tblProfo__4A478E000C50D423");

                entity.ToTable("tblProformaInvoice");

                entity.Property(e => e.ProformaInvNumber).HasColumnName("proformaInvNumber");

                entity.Property(e => e.BusinessId)
                    .HasColumnName("businessID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dueDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvDate)
                    .HasColumnType("datetime")
                    .HasColumnName("invDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvNote)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("invNote");

                entity.Property(e => e.InvStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("invStatus")
                    .HasDefaultValueSql("('DRAFT')")
                    .IsFixedLength();

                entity.Property(e => e.InvoiceBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("invoiceBy")
                    .IsFixedLength();

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasColumnName("lastModified")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("modifiedBy")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblSalesCallLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblSalesCallLogs");

                entity.Property(e => e.HearUs)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hearUs");

                entity.Property(e => e.Maintenance)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("maintenance");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.TicketId).HasColumnName("ticketID");
            });

            modelBuilder.Entity<TblServiceType>(entity =>
            {
                entity.HasKey(e => new { e.ServiceTypeId, e.ServiceTypeName })
                    .HasName("PK_ServiceType");

                entity.ToTable("tblServiceType");

                entity.Property(e => e.ServiceTypeId).HasColumnName("serviceTypeID");

                entity.Property(e => e.ServiceTypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("serviceTypeName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblStockAdjustment>(entity =>
            {
                entity.ToTable("tblStockAdjustment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdjustedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("adjustedBy")
                    .IsFixedLength();

                entity.Property(e => e.AdjustedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("adjustedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Adjustment).HasColumnName("adjustment");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("reason");
            });

            modelBuilder.Entity<TblSubDepartment>(entity =>
            {
                entity.HasKey(e => e.SubDepartmentId)
                    .HasName("PK__tblSubDe__ECB5B4DF30C33EC3");

                entity.ToTable("tblSubDepartment");

                entity.Property(e => e.SubDepartmentId).HasColumnName("subDepartmentID");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SubDepDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("subDepDescription");

                entity.Property(e => e.SubDepName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subDepName");
            });

            modelBuilder.Entity<TblSupport>(entity =>
            {
                entity.HasKey(e => new { e.SupportId, e.SupportName })
                    .HasName("PK_Support");

                entity.ToTable("tblSupport");

                entity.Property(e => e.SupportId).HasColumnName("supportID");

                entity.Property(e => e.SupportName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("supportName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblTempTicketNoteUpload>(entity =>
            {
                entity.HasKey(e => e.FileNameGuid)
                    .HasName("PK__tblTempT__06000B2029E1370A");

                entity.ToTable("tblTempTicketNoteUpload");

                entity.Property(e => e.FileNameGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fileName_GUID");

                entity.Property(e => e.FileName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("fileName");

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<TblTicketNoteUpload>(entity =>
            {
                entity.HasKey(e => e.FileNameGuid)
                    .HasName("PK__tblTicke__06000B202DB1C7EE");

                entity.ToTable("tblTicketNoteUpload");

                entity.Property(e => e.FileNameGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fileName_GUID");

                entity.Property(e => e.FileName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("fileName");

                entity.Property(e => e.NoteId).HasColumnName("noteID");
            });

            modelBuilder.Entity<TblTillInfo>(entity =>
            {
                entity.HasKey(e => new { e.TillName, e.BusinessId })
                    .HasName("PK_Till");

                entity.ToTable("tblTillInfo");

                entity.HasIndex(e => e.LicenceKey, "idxDuplicateLicenceKey")
                    .IsUnique()
                    .HasFilter("([licenceKey]<>'')");

                entity.Property(e => e.TillName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tillName")
                    .IsFixedLength();

                entity.Property(e => e.BusinessId).HasColumnName("businessID");

                entity.Property(e => e.BarcodeScanner)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("barcodeScanner");

                entity.Property(e => e.Computer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("computer")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerDisplay)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customerDisplay");

                entity.Property(e => e.InstalledBy)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("installedBy")
                    .IsFixedLength();

                entity.Property(e => e.InstalledDate)
                    .HasColumnType("datetime")
                    .HasColumnName("installedDate");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastUpdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LicenceExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("licenceExpiryDate")
                    .HasDefaultValueSql("('2000-1-1')");

                entity.Property(e => e.LicenceIssuedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("licenceIssuedDate")
                    .HasDefaultValueSql("('2000-1-1')");

                entity.Property(e => e.LicenceKey)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("licenceKey")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LogmeinName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("logmeinName");

                entity.Property(e => e.OtherHardwareInfo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("otherHardwareInfo");

                entity.Property(e => e.Printer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("printer");

                entity.Property(e => e.SupportExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("supportExpiryDate");

                entity.Property(e => e.SupportId).HasColumnName("supportID");

                entity.Property(e => e.SupportRenewedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("supportRenewedDate");

                entity.Property(e => e.TillNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("tillNote");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("updatedBy")
                    .IsFixedLength();

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("version")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TblUnregisteredBusiness>(entity =>
            {
                entity.HasKey(e => e.UrBusinessId)
                    .HasName("PK__tblUnreg__986C55E421B6055D");

                entity.ToTable("tblUnregisteredBusiness");

                entity.HasIndex(e => e.UrCusPhone, "idxDuplicateUnregisteredBusinessPhone")
                    .IsUnique()
                    .HasFilter("([urCusPhone]<>'' AND [urCusPhone]<>'0')");

                entity.HasIndex(e => new { e.UrPostcode, e.PropertyNo }, "idxDuplicateUnregisteredBusinessPostcodeAndPropertyNo")
                    .IsUnique()
                    .HasFilter("([urPostcode]<>'' AND [propertyNo]<>(0))");

                entity.HasIndex(e => e.UrCusEmail, "idxDuplicateUnregisteredCustomerEmail")
                    .IsUnique()
                    .HasFilter("([urCusEmail]<>'')");

                entity.HasIndex(e => e.UrCusMobile, "idxDuplicateUnregisteredCustomerMobile")
                    .IsUnique()
                    .HasFilter("([urCusMobile]<>'' AND [urCusMobile]<>'0')");

                entity.Property(e => e.UrBusinessId).HasColumnName("urBusinessID");

                entity.Property(e => e.IsRegistered).HasColumnName("isRegistered");

                entity.Property(e => e.PropertyNo).HasColumnName("propertyNo");

                entity.Property(e => e.UrBusCustomerId).HasColumnName("urBusCustomerID");

                entity.Property(e => e.UrBusName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("urBusName");

                entity.Property(e => e.UrCusAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("urCusAddress");

                entity.Property(e => e.UrCusEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("urCusEmail");

                entity.Property(e => e.UrCusGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("urCusGroup")
                    .IsFixedLength();

                entity.Property(e => e.UrCusMobile)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("urCusMobile")
                    .IsFixedLength();

                entity.Property(e => e.UrCusName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("urCusName");

                entity.Property(e => e.UrCusNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("urCusNote");

                entity.Property(e => e.UrCusPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("urCusPhone")
                    .IsFixedLength();

                entity.Property(e => e.UrPostcode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("urPostcode")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.UserName })
                    .HasName("PK__tblUsers__0DF7D34A117F9D94");

                entity.ToTable("tblUsers");

                entity.HasIndex(e => e.Name, "idxDuplicateName")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "idxDuplicateUserName")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userName")
                    .IsFixedLength();

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UserGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userGroup");

                entity.Property(e => e.UserGuid).HasColumnName("userGuid");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userPassword");
            });

            modelBuilder.Entity<TblUserLoginHistory>(entity =>
            {
                entity.ToTable("tblUserLoginHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("loginTime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblVersionDownloadFailLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblVersionDownloadFailLog");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.ExceptionMsg)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FailedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<ViSelectAllBusiness>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VI_SelectAllBusiness");

                entity.Property(e => e.BType)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("bType");

                entity.Property(e => e.BusAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("busAddress");

                entity.Property(e => e.BusName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("busName");

                entity.Property(e => e.BusTelephone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("busTelephone")
                    .IsFixedLength();

                entity.Property(e => e.BusinessId).HasColumnName("businessID");

                entity.Property(e => e.CusMobile)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cusMobile")
                    .IsFixedLength();

                entity.Property(e => e.CusName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cusName");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
