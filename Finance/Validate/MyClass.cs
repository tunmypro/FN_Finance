using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Finance.Models
{
    public class MyClass
    {
        public HttpPostedFileBase Mypic1 { get; set; }
        public HttpPostedFileBase Mypic2 { get; set; }
        [Display(Name = "รหัสบัตรประชาชน")]
        public string tempid { get; set; }
        [Display(Name = "ชื่อ")]
        public string tempname { get; set; }
        [Display(Name = "นามสกุล")]
        public string templname { get; set; }
        [Display(Name = "สถานะลูกค้า")]
        public string tempstatus { get; set; }
        [Display(Name = "ประเภท")]
        public string tempshow { get; set; }
        [Display(Name = "ชื่อ")]
        public string tempname2 { get; set; }
        [Display(Name = "นามสกุล")]
        public string templname2 { get; set; }
        [Display(Name = "สถานะลูกค้า")]
        public string tempstatus2 { get; set; }
        [Display(Name = "ประเภท")]
        public string tempshow2 { get; set; }
        [Display(Name = "ทะเบียนรถ")]
        public string liname { get; set; }
        [Display(Name = "รหัสทะเบียน")]
        public int liid { get; set; }
        [Display(Name = "สถานะทะเบียน")]
        public string litempstatus { get; set; }
        [Display(Name = "ยอดเงินค้าง")]
        public string bala { get; set; }
        [Display(Name = "ยอดจ่ายต่อเดือน")]
        public string outbala { get; set; }
        [Display(Name = "เงินทอน")]
        public string chabala { get; set; }
        [Display(Name = "กรอกเลขสัญญา")]
        public string searchcus { get; set; }
        [Display(Name = "คลิกจ่าย!")]
        public string getdata { get; set; }
        [Display(Name = "ยอดค้าง")]
        public string bdate { get; set; }
    }
}