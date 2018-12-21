using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Models
{
    public class ConvertDate
    {
        public DateTime ThaiDate(DateTime? Mydate)
        {
            string userDate = String.Format("{0:dd/MM/yyyy}", Mydate);

            var cultureEN = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            DateTime dt = DateTime.ParseExact(userDate, "dd/MM/yyyy", cultureEN);

            var cultureTH = System.Globalization.CultureInfo.CreateSpecificCulture("th-TH");

            DateTime thaidate = dt;

            return thaidate;
        }
    }
}