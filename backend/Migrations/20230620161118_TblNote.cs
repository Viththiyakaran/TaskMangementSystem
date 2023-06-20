using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementSystem.Migrations
{
    public partial class TblNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "tblAlarm",
                columns: table => new
                {
                    businessID = table.Column<int>(type: "int", nullable: false),
                    hardwareInfo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    alarmNote = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    installedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    installedBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblBarcodes",
                columns: table => new
                {
                    barcode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblBarco__C16E36F925518C17", x => x.barcode);
                });

            migrationBuilder.CreateTable(
                name: "tblBookkeepingDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Vendor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    billDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    BTW6 = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    BTW21 = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    tranType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    invNo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBookkeepingDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblCallLogs",
                columns: table => new
                {
                    ticketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    callType = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    businessType = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    businessID = table.Column<int>(type: "int", nullable: true),
                    serviceType = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    openDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    openBy = table.Column<int>(type: "int", nullable: true),
                    assignedTo = table.Column<int>(type: "int", nullable: true),
                    appointmentDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "('1/1/1900')"),
                    appointmentType = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true, defaultValueSql: "('No Appointment')"),
                    status = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true, defaultValueSql: "('Open')"),
                    lastUpdate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    closedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "('1/1/1900')"),
                    closedBy = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    initialNote = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    clCustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblCallL__3333C67015502E78", x => x.ticketID);
                });

            migrationBuilder.CreateTable(
                name: "tblCanceledReasons",
                columns: table => new
                {
                    ticketID = table.Column<int>(type: "int", nullable: true),
                    canceledReasons = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    canceledDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCCTV",
                columns: table => new
                {
                    businessID = table.Column<int>(type: "int", nullable: false),
                    hardwareInfo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    cctvNote = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    installedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    installedBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerBusiness",
                columns: table => new
                {
                    businessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    busName = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    busTelephone = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    busAddress = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Postcode = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    serviceTypeID = table.Column<int>(type: "int", nullable: false),
                    providedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    busNote = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    paymentMethod = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    paymentFrequent = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    amount = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    salesperson = table.Column<int>(type: "int", nullable: true),
                    noOfMonths = table.Column<int>(type: "int", nullable: true),
                    propertyNo = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    accountBalance = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValueSql: "((0))"),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    inActiveReason = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblCusto__3C08D4E20519C6AF", x => x.businessID);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerGroup",
                columns: table => new
                {
                    cusGroupID = table.Column<int>(type: "int", nullable: false),
                    cusGroupName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroup", x => new { x.cusGroupID, x.cusGroupName });
                });

            migrationBuilder.CreateTable(
                name: "tblCustomerInfo",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cusName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    cusMobile = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    cusEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cusNote = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    cusGroupID = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblCusto__B611CB9D7F60ED59", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "tblDailyTasks",
                columns: table => new
                {
                    taskID = table.Column<int>(type: "int", nullable: false),
                    taskName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastRunDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblDaily__DD5D55A202084FDA", x => x.taskID);
                });

            migrationBuilder.CreateTable(
                name: "tblDepartment",
                columns: table => new
                {
                    departmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    depName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    depDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    VAT = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    createdBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    modifiedBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblDepar__F9B8344D2A164134", x => x.departmentID);
                });

            migrationBuilder.CreateTable(
                name: "tblEstimate",
                columns: table => new
                {
                    estimateNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    businessID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    invDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    invoiceBy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    invStatus = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "('DRAFT')"),
                    invNote = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    modifiedBy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    convertedInvoice = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblEstim__1D8F310255F4C372", x => x.estimateNumber);
                });

            migrationBuilder.CreateTable(
                name: "tblHO_WebLicence",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    licIssued = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    licEnding = table.Column<DateTime>(type: "date", nullable: false),
                    issuedBy = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblHO_WebLoginRequest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Customer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblInstallation",
                columns: table => new
                {
                    ticketID = table.Column<int>(type: "int", nullable: true),
                    installationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    installer = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    jobRef = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    equipmentsDetails = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblInvoice",
                columns: table => new
                {
                    invoiceNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    businessID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    invDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    invoiceBy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    dueDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    invStatus = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true, defaultValueSql: "('DRAFT')"),
                    invNote = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    modifiedBy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    refundLink = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    proformaInvLink = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    isStandingOrder = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblInvoi__C72749EF7755B73D", x => x.invoiceNumber);
                });

            migrationBuilder.CreateTable(
                name: "tblInvoiceItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceNumber = table.Column<int>(type: "int", nullable: true),
                    productID = table.Column<int>(type: "int", nullable: true),
                    proName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    unitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    VAT = table.Column<int>(type: "int", nullable: true),
                    addedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInvoiceItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblLicence",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    computer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    licenceKey = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    licenceIssuedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    licenceExpiryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    issuedBy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    businessID = table.Column<int>(type: "int", nullable: false),
                    tillName = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLicence", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblLight",
                columns: table => new
                {
                    businessID = table.Column<int>(type: "int", nullable: false),
                    hardwareInfo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    lightNote = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    installedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    installedBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblLogNotes",
                columns: table => new
                {
                    noteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketID = table.Column<int>(type: "int", nullable: false),
                    logDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    logBy = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    status = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    assignedTo = table.Column<int>(type: "int", nullable: true),
                    appointmentType = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    appointmentDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblMobileDevices",
                columns: table => new
                {
                    UUID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CustID = table.Column<int>(type: "int", nullable: false),
                    licEnding = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblMobil__65A475E73BFFE745", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "tblMobileLicence",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    licIssued = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    licEnding = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    issuedBy = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMobileLicence", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblMobileLoginRequest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Customer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMobileLoginRequest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblMobileUsers",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CustID = table.Column<int>(type: "int", nullable: false),
                    licEnding = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    UserEmailaddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    userStatus = table.Column<int>(type: "int", nullable: false),
                    userStatusKey = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BusID = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblMobil__65A475E7214BF109", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "tblPayment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceNumber = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    paidDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    paidBy = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    receivedBy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    payNote = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    balance = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false),
                    proName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    proDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    departmentID = table.Column<int>(type: "int", nullable: false),
                    subDepartmentID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    retailPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    installerPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    costPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    createdDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    createdBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    modifiedBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblProdu__2D10D14A1CBC4616", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "tblProformaInvoice",
                columns: table => new
                {
                    proformaInvNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    businessID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    invDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    invoiceBy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    dueDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    invStatus = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true, defaultValueSql: "('DRAFT')"),
                    invNote = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    lastModified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    modifiedBy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblProfo__4A478E000C50D423", x => x.proformaInvNumber);
                });

            migrationBuilder.CreateTable(
                name: "tblSalesCallLogs",
                columns: table => new
                {
                    ticketID = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    maintenance = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    hearUs = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblServiceType",
                columns: table => new
                {
                    serviceTypeID = table.Column<int>(type: "int", nullable: false),
                    serviceTypeName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => new { x.serviceTypeID, x.serviceTypeName });
                });

            migrationBuilder.CreateTable(
                name: "tblStockAdjustment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(type: "int", nullable: true),
                    adjustment = table.Column<int>(type: "int", nullable: true),
                    reason = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    adjustedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    adjustedBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStockAdjustment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblSubDepartment",
                columns: table => new
                {
                    subDepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentID = table.Column<int>(type: "int", nullable: true),
                    subDepName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    subDepDescription = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblSubDe__ECB5B4DF30C33EC3", x => x.subDepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "tblSupport",
                columns: table => new
                {
                    supportID = table.Column<int>(type: "int", nullable: false),
                    supportName = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Support", x => new { x.supportID, x.supportName });
                });

            migrationBuilder.CreateTable(
                name: "tblTempTicketNoteUpload",
                columns: table => new
                {
                    fileName_GUID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fileName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    userName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblTempT__06000B2029E1370A", x => x.fileName_GUID);
                });

            migrationBuilder.CreateTable(
                name: "tblTicketNoteUpload",
                columns: table => new
                {
                    fileName_GUID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fileName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    noteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblTicke__06000B202DB1C7EE", x => x.fileName_GUID);
                });

            migrationBuilder.CreateTable(
                name: "tblTillInfo",
                columns: table => new
                {
                    tillName = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    businessID = table.Column<int>(type: "int", nullable: false),
                    installedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    installedBy = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    logmeinName = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    licenceKey = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true, defaultValueSql: "('')"),
                    licenceIssuedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "('2000-1-1')"),
                    licenceExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "('2000-1-1')"),
                    supportID = table.Column<int>(type: "int", nullable: false),
                    supportRenewedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    supportExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    computer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('')"),
                    barcodeScanner = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    printer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    customerDisplay = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    otherHardwareInfo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    tillNote = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    lastUpdate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    updatedBy = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    version = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Till", x => new { x.tillName, x.businessID });
                });

            migrationBuilder.CreateTable(
                name: "tblUnregisteredBusiness",
                columns: table => new
                {
                    urBusinessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urCusName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    urBusName = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    urCusPhone = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    urCusMobile = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    urCusEmail = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    urCusAddress = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    urPostcode = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    urCusNote = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    propertyNo = table.Column<int>(type: "int", nullable: true),
                    urBusCustomerID = table.Column<int>(type: "int", nullable: false),
                    isRegistered = table.Column<bool>(type: "bit", nullable: false),
                    urCusGroup = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblUnreg__986C55E421B6055D", x => x.urBusinessID);
                });

            migrationBuilder.CreateTable(
                name: "tblUserLoginHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    loginTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Attempt = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserLoginHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    userPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    userGroup = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    userGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblUsers__0DF7D34A117F9D94", x => new { x.userID, x.userName });
                });

            migrationBuilder.CreateTable(
                name: "tblVersionDownloadFailLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessID = table.Column<int>(type: "int", nullable: false),
                    TillNo = table.Column<int>(type: "int", nullable: false),
                    ExceptionMsg = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    FailedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "idxDuplicateBusinessTelephone",
                table: "tblCustomerBusiness",
                column: "busTelephone",
                unique: true,
                filter: "([busTelephone]<>'' AND [busTelephone]<>'0')");

            migrationBuilder.CreateIndex(
                name: "idxDuplicatePostcodeAndPropertyNo",
                table: "tblCustomerBusiness",
                columns: new[] { "propertyNo", "Postcode" },
                unique: true,
                filter: "([Postcode]<>'' AND [propertyNo]<>(0))");

            migrationBuilder.CreateIndex(
                name: "idxDuplicateCustomerEmail",
                table: "tblCustomerInfo",
                column: "cusEmail",
                unique: true,
                filter: "([cusEmail]<>'')");

            migrationBuilder.CreateIndex(
                name: "idxDuplicateCustomerMobile",
                table: "tblCustomerInfo",
                column: "cusMobile",
                unique: true,
                filter: "([cusMobile]<>'' AND [cusMobile]<>'0')");

            migrationBuilder.CreateIndex(
                name: "idxDuplicateLicenceKey",
                table: "tblTillInfo",
                column: "licenceKey",
                unique: true,
                filter: "([licenceKey]<>'')");

            migrationBuilder.CreateIndex(
                name: "idxDuplicateUnregisteredBusinessPhone",
                table: "tblUnregisteredBusiness",
                column: "urCusPhone",
                unique: true,
                filter: "([urCusPhone]<>'' AND [urCusPhone]<>'0')");

            migrationBuilder.CreateIndex(
                name: "idxDuplicateUnregisteredBusinessPostcodeAndPropertyNo",
                table: "tblUnregisteredBusiness",
                columns: new[] { "urPostcode", "propertyNo" },
                unique: true,
                filter: "([urPostcode]<>'' AND [propertyNo]<>(0))");

            migrationBuilder.CreateIndex(
                name: "idxDuplicateUnregisteredCustomerEmail",
                table: "tblUnregisteredBusiness",
                column: "urCusEmail",
                unique: true,
                filter: "([urCusEmail]<>'')");

            migrationBuilder.CreateIndex(
                name: "idxDuplicateUnregisteredCustomerMobile",
                table: "tblUnregisteredBusiness",
                column: "urCusMobile",
                unique: true,
                filter: "([urCusMobile]<>'' AND [urCusMobile]<>'0')");

            migrationBuilder.CreateIndex(
                name: "idxDuplicateName",
                table: "tblUsers",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "idxDuplicateUserName",
                table: "tblUsers",
                column: "userName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAlarm");

            migrationBuilder.DropTable(
                name: "tblBarcodes");

            migrationBuilder.DropTable(
                name: "tblBookkeepingDetails");

            migrationBuilder.DropTable(
                name: "tblCallLogs");

            migrationBuilder.DropTable(
                name: "tblCanceledReasons");

            migrationBuilder.DropTable(
                name: "tblCCTV");

            migrationBuilder.DropTable(
                name: "tblCustomerBusiness");

            migrationBuilder.DropTable(
                name: "tblCustomerGroup");

            migrationBuilder.DropTable(
                name: "tblCustomerInfo");

            migrationBuilder.DropTable(
                name: "tblDailyTasks");

            migrationBuilder.DropTable(
                name: "tblDepartment");

            migrationBuilder.DropTable(
                name: "tblEstimate");

            migrationBuilder.DropTable(
                name: "tblHO_WebLicence");

            migrationBuilder.DropTable(
                name: "tblHO_WebLoginRequest");

            migrationBuilder.DropTable(
                name: "tblInstallation");

            migrationBuilder.DropTable(
                name: "tblInvoice");

            migrationBuilder.DropTable(
                name: "tblInvoiceItems");

            migrationBuilder.DropTable(
                name: "tblLicence");

            migrationBuilder.DropTable(
                name: "tblLight");

            migrationBuilder.DropTable(
                name: "tblLogNotes");

            migrationBuilder.DropTable(
                name: "tblMobileDevices");

            migrationBuilder.DropTable(
                name: "tblMobileLicence");

            migrationBuilder.DropTable(
                name: "tblMobileLoginRequest");

            migrationBuilder.DropTable(
                name: "tblMobileUsers");

            migrationBuilder.DropTable(
                name: "tblPayment");

            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "tblProformaInvoice");

            migrationBuilder.DropTable(
                name: "tblSalesCallLogs");

            migrationBuilder.DropTable(
                name: "tblServiceType");

            migrationBuilder.DropTable(
                name: "tblStockAdjustment");

            migrationBuilder.DropTable(
                name: "tblSubDepartment");

            migrationBuilder.DropTable(
                name: "tblSupport");

            migrationBuilder.DropTable(
                name: "tblTempTicketNoteUpload");

            migrationBuilder.DropTable(
                name: "tblTicketNoteUpload");

            migrationBuilder.DropTable(
                name: "tblTillInfo");

            migrationBuilder.DropTable(
                name: "tblUnregisteredBusiness");

            migrationBuilder.DropTable(
                name: "tblUserLoginHistory");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblVersionDownloadFailLog");
        }
    }
}
