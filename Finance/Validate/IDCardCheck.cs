using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Models
{
    public static class CheckIDCard
    {
        public static bool IsValidCheckPersonId(string pid)
        {
            char[] numberChars = pid.ToCharArray();

            int total = 0;
            int mul = 13;

            for (int i = 0; i < numberChars.Length - 1; i++)
            {
                int.TryParse(numberChars[i].ToString(), out var num);
                total = total + num * mul;
                mul = mul - 1;
            }
            var mod = total % 11;
            var nsub = 11 - mod;
            var mod2 = nsub % 10;
            int.TryParse(numberChars[12].ToString(), out var numberChars12);
            if (mod2 != numberChars12)
                return false;
            return true;
        }
    }
}