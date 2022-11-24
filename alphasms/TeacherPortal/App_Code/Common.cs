using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherPortal.App_Code
{
    public class Common
    {
        public enum ModuleNames
        {
            DT = 1,
            G = 2,
            E = 3,
            T = 4,
            LIFE = 5
        }

        public enum Randomization
        {
            Randomize = 1,
            Prioritize = 2,
            Sequential = 3,
        }
        public static string ReplaceSpecialCharacters(string str)
        {
            string[] chars = new string[] { ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
            //Iterate the number of times based on the String array length.
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], "-");
                }
            }
            return str;
        }
        public static string CalculateYourAge(DateTime Dob)
        {
            string ageString = "";
            DateTime Now = DateTime.Now;
            int _Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime _DOBDateNow = Dob.AddYears(_Years);
            int _Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (_DOBDateNow.AddMonths(i) == Now)
                {
                    _Months = i;
                    break;
                }
                else if (_DOBDateNow.AddMonths(i) >= Now)
                {
                    _Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(_DOBDateNow.AddMonths(_Months)).Days;
            if (_Years > 1)
                ageString = _Years + " Years ";
            else
                ageString = _Years + " Year ";
            if (_Months > 1)
                ageString += _Months + " Months ";
            else
                ageString += _Months + " Month ";
            if (Days > 1)
                ageString += Days + " Days ";
            else
                ageString += Days + " Day ";
            return ageString;
            //return _Years + " Years " + _Months + " Months " + Days + " Days";
        }
        public static string CalculateTestAge(DateTime Dob, DateTime TestDate)
        {
            string ageString = "";
            DateTime Now = new DateTime(TestDate.Year, TestDate.Month, TestDate.Day, 13, 0, 0);
            int Years = 0;
            Years = new DateTime(TestDate.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            ageString = Years + " yr, ";
            ageString += Months + " m, ";
            ageString += Math.Abs(Days) + " d";
            return ageString;
        }
        //public static string CalculateTestAge(DateTime Dob, DateTime TestDate)
        //{
        //    string ageString = "";
        //    DateTime Now = Dob;// DateTime.Now;
        //    try
        //    {
        //        int _Years = new DateTime(DateTime.Now.Subtract(TestDate).Ticks).Year - 1;
        //        DateTime _DOBDateNow = TestDate.AddYears(_Years);
        //        int _Months = 0;
        //        for (int i = 1; i <= 12; i++)
        //        {
        //            if (_DOBDateNow.AddMonths(i) == Now)
        //            {
        //                _Months = i;
        //                break;
        //            }
        //            else if (_DOBDateNow.AddMonths(i) >= Now)
        //            {
        //                _Months = i - 1;
        //                break;
        //            }
        //        }
        //        int Days = Now.Subtract(_DOBDateNow.AddMonths(_Months)).Days;
        //        ageString = _Years + " yr, ";
        //        ageString += _Months + " m, ";
        //        ageString += Math.Abs(Days) + " d";
        //    }catch(Exception ex)
        //    {
        //        ageString = "___yr,___m,___d";
        //    }
        //    return ageString;
        //    //return _Years + " Years " + _Months + " Months " + Days + " Days";
        //}
        public static int CalculateDays(DateTime fromDate, DateTime toDate)
        {
            TimeSpan difference = toDate - fromDate;
            return difference.Days;
        }
    }
}