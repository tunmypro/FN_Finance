//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace Finance.Models
//{
//    public partial class V_Contracts
//    {
//        [Display(Name = "รหัสสัญญา")]
//        public string ContractID { get; set; }
//        [Display(Name = "รหัสทะเบียน")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public Nullable<int> LicenseID { get; set; }
//        [Display(Name = "รหัสบัตรประชาชนผู้กู้")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string ID_Card_m { get; set; }
//        [Display(Name = "รหัสบัตรประชาชนผู้ค้ำ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string ID_Card_g { get; set; }
//        [Display(Name = "วันที่เริ่มสัญญา")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
//        public Nullable<System.DateTime> Date_Start { get; set; }
//        [Display(Name = "วันที่หมดสัญญา")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
//        public Nullable<System.DateTime> Date_End { get; set; }
//        [Display(Name = "ยอดเงิน")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public Nullable<decimal> Balance { get; set; }
//        [Display(Name = "ยอดเงินค้าง")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public Nullable<decimal> Out_Balance { get; set; }
//        [Display(Name = "ยอดจ่ายรายเดือน")]
//        public Nullable<decimal> Per_Month_Amount { get; set; }
//    }
//    [MetadataType(typeof(V_Contracts))]
//    public partial class Contracts { }

//    public partial class V_Customers
//    {
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        [Display(Name = "เลขบัตรประชาชน")]
//        [RegularExpression("([0-9]+)", ErrorMessage = "กรุณากรอกเฉพาะตัวเลข")]
//        [MinLength(13, ErrorMessage = "เลขบัตรประชาชนไม่ถูกต้อง")]
//        public string ID_Card_m { get; set; }
//        [Display(Name = "ชื่อ(กู้)")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Name_m { get; set; }
//        [Display(Name = "นามสกุล")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Lname_m { get; set; }
//        [Display(Name = "บ้านเลขที่")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Address_m { get; set; }
//        [Display(Name = "ตำบล")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string District_m { get; set; }
//        [Display(Name = "อำเภอ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Amphur_m { get; set; }
//        [Display(Name = "จังหวัด")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Province_m { get; set; }
//        [Display(Name = "รหัสไปรษณีย์")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Zipcode_m { get; set; }
//        [Display(Name = "อาชีพ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Career_m { get; set; }
//        [Display(Name = "เงินเดือน")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public Nullable<decimal> Salary_m { get; set; }
//        public Nullable<int> Status_m { get; set; }
//    }
//    [MetadataType(typeof(V_Customers))]
//    public partial class Customers { }

//    public partial class V_GuaranteeCustomers
//    {
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        [Display(Name = "เลขบัตรประชาชน")]
//        [RegularExpression("([0-9]+)", ErrorMessage = "กรุณากรอกเฉพาะตัวเลข")]
//        [MinLength(13, ErrorMessage = "เลขบัตรประชาชนไม่ถูกต้อง")]
//        public string ID_Card_g { get; set; }
//        [Display(Name = "ชื่อ(ค้ำ)")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Name_g { get; set; }
//        [Display(Name = "นามสกุล")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Lname_g { get; set; }
//        [Display(Name = "บ้านเลขที่")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Address_g { get; set; }
//        [Display(Name = "ตำบล")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string District_g { get; set; }
//        [Display(Name = "อำเภอ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Amphur_g { get; set; }
//        [Display(Name = "จังหวัด")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Province_g { get; set; }
//        [Display(Name = "รหัสไปรษณีย์")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Zipcode_g { get; set; }
//        [Display(Name = "อาชีพ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Career_g { get; set; }
//        [Display(Name = "เงินเดือน")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public Nullable<decimal> Salary_g { get; set; }
//        public Nullable<int> Status_g { get; set; }
//    }
//    [MetadataType(typeof(V_GuaranteeCustomers))]
//    public partial class GuaranteeCustomers { }

//    public partial class V_License
//    {
//        [Display(Name = "ไอดีทะเบียน")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public int LicenseID { get; set; }
//        [Display(Name = "ทะเบียนรถ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string LicensePlate { get; set; }
//        [Display(Name = "ชื่อรถ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string LicenseName { get; set; }
//        [Display(Name = "สาขาที่เก็บ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string KeepAddressID { get; set; }
//        [Display(Name = "ตำบล")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string District_l { get; set; }
//        [Display(Name = "อำเภอ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Amphur_l { get; set; }
//        [Display(Name = "จังหวัด")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Province_l { get; set; }
//        [Display(Name = "รหัสไปรษณีย์")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Zipcode_l { get; set; }
//        public Nullable<int> LicenseType { get; set; }
//        public Nullable<int> LicenseStatusID { get; set; }
//    }
//    [MetadataType(typeof(V_License))]
//    public partial class License { }

//    public partial class V_LicenseStatusDisplay
//    {
//        [Display(Name = "ไอดีสถานะ")]
//        public int LicenseStatusID { get; set; }
//        [Display(Name = "สถานะรถ")]
//        public string LicenseStatusName { get; set; }
//    }
//    [MetadataType(typeof(V_LicenseStatusDisplay))]
//    public partial class LicenseStatusDisplay { }

//    public partial class V_LicenseTypes
//    {
//        [Display(Name = "ไอดีประเภท")]
//        public int LicenseType { get; set; }
//        [Display(Name = "ประเภทรถ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string InterestName { get; set; }
//        [Display(Name = "อัตตราดอกเบี้ย")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public Nullable<decimal> InterestRate { get; set; }
//    }
//    [MetadataType(typeof(V_LicenseTypes))]
//    public partial class LicenseTypes { }

//    public partial class V_Payments
//    {
//        [Display(Name = "รหัสรายการ")]
//        public string PaymentID { get; set; }
//        [Display(Name = "รหัสบัตรประชาชน")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string ID_Card_m { get; set; }
//        [Display(Name = "ผู้ทำรายการ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string NameUser { get; set; }
//        [Display(Name = "รหัสสัญญา")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public int ContractID { get; set; }
//        [Display(Name = "วันที่ทำรายการ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
//        public Nullable<System.DateTime> PaymentDate { get; set; }
//        [Display(Name = "จำนวนเงินที่จ่าย")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public Nullable<decimal> Payment_Money { get; set; }
//    }
//    [MetadataType(typeof(V_Payments))]
//    public partial class Payments { }

//    public partial class V_StatusCustomer
//    {
//        [Display(Name = "ไอดีสถานะ")]
//        public int StatusID { get; set; }
//        [Display(Name = "สถานะ")]
//        public string StatusType { get; set; }
//    }
//    [MetadataType(typeof(V_StatusCustomer))]
//    public partial class StatusCustomer { }

//    public partial class V_StatusUser
//    {
//        [Display(Name = "ไอดีสถานะ")]
//        public int StatusUser1 { get; set; }
//        [Display(Name = "ระดับ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string StatusName { get; set; }
//    }
//    [MetadataType(typeof(V_StatusUser))]
//    public partial class V_StatusUser { }

//    public partial class V_User_Finance
//    {
//        [Display(Name = "ไอดีผู้ใช้งาน")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public int UserID { get; set; }
//        [Display(Name = "ชื่อผู้ใช้งาน")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Username { get; set; }
//        [Display(Name = "พาสเวิร์ด")]
//        [DataType(DataType.Password)]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Password { get; set; }
//        [Display(Name = "ชื่อ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Name { get; set; }
//        [Display(Name = "นามสกุล")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
//        public string Lname { get; set; }
//        [Display(Name = "ระดับ")]
//        public Nullable<int> StatusUser { get; set; }
//    }
//    [MetadataType(typeof(V_User_Finance))]
//    public partial class User_Finance { }

//    public partial class V_title
//    {
//        [Display(Name = "รหัสคำนำหน้า")]
//        public int titleid { get; set; }
//        [Display(Name = "คำนำหน้าชื่อ")]
//        public string titlename { get; set; }
//    }
//    [MetadataType(typeof(V_title))]
//    public partial class title { }
//}