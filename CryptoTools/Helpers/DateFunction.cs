using System;
using System.Globalization;

namespace CryptoTools.Helpers
{
    public class DateFunction
    {
        public static string[] MonthNames =
            {"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"};

        public static string[] DayNames = {"یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه"};
        private static readonly int[] MonthLen = {31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29};

        public static int[,] HshSumOfDays =
        {
            {0, 31, 62, 93, 124, 155, 186, 216, 246, 276, 306, 336, 365},
            {0, 31, 62, 93, 124, 155, 186, 216, 246, 276, 306, 336, 366}
        };

        public static int[,] GrgSumOfDays =
        {
            {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365},
            {0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366}
        };

        public static string GetTime()
        {
            return DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + ":" +
                   DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + ":" + DateTime.Now
                       .Second.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
        }

        public static long GetFullDate()
        {
            var today = TodayShamsiInt();
            var thisTime = GetTimeStringFormat();

            return long.Parse(today.ToString() + thisTime.ToString());
        }

        public static string GetTimeStringFormat()
        {
            return GetTimeFromIntClean(GetTimeInt());
        }

        /// <summary>
        /// زمان متنی بدون کاراکنر
        /// </summary>
        /// <param name="intTime"></param>
        /// <returns></returns>
        public static string GetTimeFromIntClean(object intTime)
        {
            /*
             02:33   233
             00:33   33
             22:33   2233
             
             */
            if (intTime == null)
                return string.Empty;
            var time = intTime.ToString();
            if (time.Length == 3)
            {
                time = "0" + time;
            }
            if (time.Length == 2)
                time = "00" + time;
            if (time.Length == 4)
                return (time.Substring(0, 2) + time.Substring(2, 2));
            return string.Empty;
        }

        public static int GetTimeInt()
        {
            // return Convert.ToInt32(DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + DateTime.Now.Second.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'));
            return Convert.ToInt32(DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') +
                                   DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'));
        }

        public static int? GetYearDiff(string date)
        {
            if (string.IsNullOrEmpty(date))
                return null;
            var year = Convert.ToInt16(date.Substring(0, 4));
            var yearNow = Convert.ToInt16(TodayShamsi().Substring(0, 4));
            return yearNow - year;
        }

        public static int GetMonthLen(int year, int monthIndex)
        {
            if (monthIndex == 12)
                if (HshIsLeap(year))
                    return 30;
                else
                    return 29;
            return MonthLen[monthIndex - 1];
        }

        public static string TodayShamsi()
        {
            return ToShamsiString(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public static int TodayShamsiInt()
        {
            return ToShamsiInt(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private static bool GrgIsLeap(int year)
        {
            return ((year % 4) == 0 && ((year % 100) != 0 || (year % 400) == 0));
        }

        private static bool HshIsLeap(int year)
        {
            year = (year - 474) % 128;
            year = ((year >= 30) ? 0 : 29) + year;
            year = year - Convert.ToInt32(Math.Floor((double) year / 33)) - 1;
            return ((year % 4) == 0);
        }

        public static int FindDiff(string otherDate)
        {
            string today = TodayShamsi();
            if (String.CompareOrdinal(otherDate, today) >= 0)
                return FindDiff(today, otherDate);
            return FindDiff(otherDate, today);
        }

        public static int FindDiff(string beginDate, string endDate)
        {
            int bDay, bMonth, bYear, eDay, eMonth, eYear;
            if (!IsValidDate(beginDate) || !IsValidDate(endDate))
                //throw new Exception ("ÊÇÑíÎ æÑæÏí ãÚÊÈÑ äãí ÈÇÔÏ");
                return 0;
            try
            {
                bDay = Convert.ToInt16(beginDate.Substring(8, 2));
                bMonth = Convert.ToInt16(beginDate.Substring(5, 2));
                bYear = Convert.ToInt16(beginDate.Substring(0, 4));
                eDay = Convert.ToInt16(endDate.Substring(8, 2));
                eMonth = Convert.ToInt16(endDate.Substring(5, 2));
                eYear = Convert.ToInt16(endDate.Substring(0, 4));
            }
            catch
            {
                //throw new Exception ("ÊÇÑíÎ æÑæÏí ãÚÊÈÑ äãí ÈÇÔÏ");
                return 0;
            }
            int result = (eYear - bYear) * 360 + (eMonth - bMonth) * 30 + eDay - bDay;
            if (result < 0)
                //throw new Exception("ÊÇÑíÎ ÔÑæÚ ÇÒ ÊÇÑíÎ ÇíÇä ÈÒÑÊÑ ãí ÈÇÔÏ");
                return 0;
            return result;
        }

        public static DateTime ShamsiToMiladi(string shamsiDate)
        {
            var c = new PersianCalendar();
            return c.ToDateTime(Convert.ToInt32(shamsiDate.Substring(0, 4)),
                Convert.ToInt32(shamsiDate.Substring(5, 2)), Convert.ToInt32(shamsiDate.Substring(8, 2)), 0, 0, 0, 0);
        }

        public static string ToGregorian(int hshYear, int hshMonth, int hshDay)
        {
            int grgYear = hshYear + 621;
            int grgMonth = 0, grgDay = 0;

            bool hshLeap = HshIsLeap(hshYear);
            bool grgLeap = GrgIsLeap(grgYear);

            int hshElapsed = HshSumOfDays[hshLeap ? 1 : 0, hshMonth - 1] + hshDay;
            int grgElapsed;

            if (hshMonth > 10 || (hshMonth == 10 && hshElapsed > 286 + (grgLeap ? 1 : 0)))
            {
                grgElapsed = hshElapsed - (286 + (grgLeap ? 1 : 0));
                grgLeap = GrgIsLeap(++grgYear);
            }
            else
            {
                hshLeap = HshIsLeap(hshYear - 1);
                grgElapsed = hshElapsed + 79 + (hshLeap ? 1 : 0) - (GrgIsLeap(grgYear - 1) ? 1 : 0);
            }

            for (int i = 1; i <= 12; i++)
            {
                if (GrgSumOfDays[grgLeap ? 1 : 0, i] >= grgElapsed)
                {
                    grgMonth = i;
                    grgDay = grgElapsed - GrgSumOfDays[grgLeap ? 1 : 0, i - 1];
                    break;
                }
            }

            return PadOut(grgYear) + "/" + PadOut(grgMonth) + "/" + PadOut(grgDay);
        }

        public static string PadOut(int input)
        {
            return (input.ToString(CultureInfo.InvariantCulture).Length == 1)
                ? "0" + input
                : input.ToString(CultureInfo.InvariantCulture);
        }

        public static int ToShamsiInt(int grgYear, int grgMonth, int grgDay)
        {
            int hshDay;
            int hshYear;
            int hshMonth;
            ToShamsi(grgYear, grgMonth, grgDay, out hshMonth, out hshDay, out hshYear);
            return Convert.ToInt32(PadOut(hshYear) + PadOut(hshMonth) + PadOut(hshDay));
        }

        public static string ToShamsiString(int grgYear, int grgMonth, int grgDay)
        {
            int hshDay;
            int hshYear;
            int hshMonth;
            ToShamsi(grgYear, grgMonth, grgDay, out hshMonth, out hshDay, out hshYear);
            return PadOut(hshYear) + "/" + PadOut(hshMonth) + "/" + PadOut(hshDay);
        }

        public static void ToShamsi(int grgYear, int grgMonth, int grgDay, out int hshMonth, out int hshDay,
            out int hshYear)
        {
            hshYear = grgYear - 621;
            hshMonth = 0;
            hshDay = 0;

            bool grgLeap = GrgIsLeap(grgYear);
            bool hshLeap = HshIsLeap(hshYear - 1);

            int hshElapsed;

            int grgElapsed = GrgSumOfDays[(grgLeap ? 1 : 0), grgMonth - 1] + grgDay;
            int xmasToNorooz = (hshLeap && grgLeap) ? 80 : 79;

            if (grgElapsed <= xmasToNorooz)
            {
                hshElapsed = grgElapsed + 286;
                hshYear--;
                if (hshLeap && !grgLeap)
                    hshElapsed++;
            }
            else
            {
                hshElapsed = grgElapsed - xmasToNorooz;
                hshLeap = HshIsLeap(hshYear);
            }

            for (int i = 1; i <= 12; i++)
            {
                if (HshSumOfDays[(hshLeap ? 1 : 0), i] >= hshElapsed)
                {
                    hshMonth = i;
                    hshDay = hshElapsed - HshSumOfDays[(hshLeap ? 1 : 0), i - 1];
                    break;
                }
            }
        }

        public static string AddDay(string baseDate, int value)
        {
            if (!IsValidDate(baseDate))
                return baseDate;
            string miladiBase = ToGregorian(Convert.ToInt16(baseDate.Substring(0, 4)),
                Convert.ToInt16(baseDate.Substring(5, 2)), Convert.ToInt16(baseDate.Substring(8, 2)));
            var t = new DateTime(Convert.ToInt16(miladiBase.Substring(0, 4)),
                Convert.ToInt16(miladiBase.Substring(5, 2)), Convert.ToInt16(miladiBase.Substring(8, 2)));
            t = t.AddDays(value);
            return ToShamsiString(t.Year, t.Month, t.Day);
        }

        public static string AddDayBank(string baseDate, int value)
        {
            if (!IsValidDate(baseDate))
                return baseDate;
            if (value < 0)
                return SubtractDayBank(baseDate, value * -1);
            int baseDay = Convert.ToInt32(baseDate.Substring(8, 2));
            int baseMonth = Convert.ToInt32(baseDate.Substring(5, 2));
            int baseYear = Convert.ToInt32(baseDate.Substring(0, 4));
            int addDay = value % 30;
            int addMonth = ((value - addDay) % 360) / 30;
            int addYear = value / 360;

            int retDay = baseDay + addDay;
            if (retDay > 30)
            {
                retDay = retDay - 30;
                addMonth++;
            }
            int retMonth = baseMonth + addMonth;
            if (retMonth > 12)
            {
                retMonth = retMonth - 12;
                addYear++;
            }
            int retYear = baseYear + addYear;
            return retYear + "/" + retMonth.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + "/" +
                   retDay.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
        }

        public static string SubtractDayBank(string baseDate, int value)
        {
            if (value < 0)
                return AddDayBank(baseDate, value * -1);
            if (!IsValidDate(baseDate))
                return baseDate;
            int baseDay = Convert.ToInt32(baseDate.Substring(8, 2));
            int baseMonth = Convert.ToInt32(baseDate.Substring(5, 2));
            int baseYear = Convert.ToInt32(baseDate.Substring(0, 4));
            int addDay = value % 30;
            int addMonth = ((value - addDay) % 360) / 30;
            int addYear = value / 360;

            int retDay = baseDay - addDay;
            if (retDay < 1)
            {
                retDay = 30 + retDay;
                addMonth++;
            }

            int retMonth = baseMonth - addMonth;
            if (retMonth < 1)
            {
                retMonth = 12 + retMonth;
                addYear++;
            }
            int retYear = baseYear - addYear;
            return retYear + "/" + retMonth.ToString().Trim().PadLeft(2, '0') + "/" +
                   retDay.ToString().Trim().PadLeft(2, '0');
        }

        public static string DayToDate(int value)
        {
            if (value == 0)
                return "00/00/00";
            int y = value / 360;
            int m = (value - y * 360) / 30;
            int d = (value - y * 360 - m * 30);
            return y.ToString().PadLeft(2, '0') + "/" + m.ToString().PadLeft(2, '0') + "/" +
                   d.ToString().PadLeft(2, '0');
        }

        public static int ToDateInt(string persianDate)
        {
            return Int32.Parse(persianDate.Replace("/", ""));
        }

        public static bool IsValidDate(string value)
        {
            if (value.Trim() == string.Empty)
                return true;
            if (value.Length != 10) return false;
            if (value.Substring(4, 1) != "/") return false;
            if (value.Substring(7, 1) != "/") return false;
            if (!HrString.IsNumber(value.Replace("/", ""))) return false;
            int bDay = Convert.ToInt16(value.Substring(8, 2));
            int bMonth = Convert.ToInt16(value.Substring(5, 2));
            int bYear = Convert.ToInt16(value.Substring(0, 4));

            if (bDay < 0 || bDay > 31 || bMonth < 0 || bMonth > 12 || bYear < 1200)
                return false;
            return true;
        }

        public static string GetFirstDayOfyear(string value)
        {
            return value.Substring(0, 4) + "/01/01";
        }

        public static int DateToDay(string len)
        {
            if (HrString.IsNumber(len))
                return Convert.ToInt32(len);
            try
            {
                string[] s = len.Split("/".ToCharArray());
                return Convert.ToInt32(s[2]) + (30 * Convert.ToInt32(s[1])) + (360 * Convert.ToInt32(s[0]));
            }
            catch
            {
                return 0;
            }
        }

        public static bool IsValidDateLen(string value)
        {
            if (value.Length != 8) return false;
            if (value.Substring(2, 1) != "/") return false;
            if (value.Substring(5, 1) != "/") return false;
            if (!HrString.IsNumber(value.Replace("/", ""))) return false;
            int bDay = Convert.ToInt16(value.Substring(6, 2));
            int bMonth = Convert.ToInt16(value.Substring(3, 2));
            int bYear = Convert.ToInt16(value.Substring(0, 2));

            if (bDay < 0 || bDay > 99 || bMonth < 0 || bMonth > 99 || bYear < 0 || bYear > 99)
                return false;
            return true;
        }

        public static bool IsLowerFromNow(string pDate)
        {
            return string.Compare(pDate, TodayShamsi()) < 0;
        }

        internal static string IntToDate(int date)
        {
            if (date.ToString().Length != 8)
                return string.Empty;
            return date.ToString().Substring(0, 4) + @"\" + date.ToString().Substring(4, 2) + @"\" +
                   date.ToString().Substring(6, 2);
        }

        public static int? GetDateIntFromString(string dateString)
        {
            if (dateString == null)
                return null;
            try
            {
                var dateArray = dateString.Split("/".ToCharArray());
                if (dateArray.Length == 3)
                {
                    if (dateArray[1].Length == 1)
                        dateArray[1] = "0" + dateArray[1];
                    if (dateArray[2].Length == 1)
                        dateArray[2] = "0" + dateArray[2];
                    return Convert.ToInt32(dateArray[0] + dateArray[1] + dateArray[2]);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string GetDateStringFromInt(object date, string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
            {
                lang = "en";
            }

            if (string.IsNullOrEmpty(date?.ToString()))
            {
                return string.Empty;
            }
            var pc = new PersianCalendar();

            var strDate = date.ToString();
            int year = Convert.ToInt32(strDate.Substring(0, 4));
            int month = Convert.ToInt32(strDate.Substring(4, 2));
            int day = Convert.ToInt32(strDate.Substring(6, 2));
            DateTime dt = new PersianCalendar().ToDateTime(year, month, day, 5, 1, 1, 1);
            if (lang != "fa")
            {
                DateTime d = new DateTime(dt.Year, dt.Month, dt.Day, 5, 1, 1, 1);
                var monthName = (new DateTimeFormatInfo()).GetMonthName(d.Month);
                var dayOfWeek = d.DayOfWeek.ToString();
                return d.Year.ToString() + " " + dayOfWeek + " " + monthName;
            }
            else
            {
                int dayofWeek = (int) pc.GetDayOfWeek(dt);
                return (DayNames[dayofWeek] + " " + day + " " + MonthNames[month - 1] + " " + year);
            }
        }

        public static string GetDateStringFromInt(object date)
        {
            return GetDateStringFromInt(date, "fa");
        }

        public static string GetDateFromIntSimple(object date)
        {
            var strDate = date.ToString();
            if (strDate.Length == 8)
                return (strDate.Substring(6, 2) + @"/" + strDate.Substring(4, 2) + "/" + strDate.Substring(0, 4));
            return string.Empty;
        }

        public static string GetDateFromInt(object date)
        {
            var strDate = date.ToString();
            if (strDate.Length == 8)
                return GetDateFromIntSimple(date);
            return string.Empty;
        }

        public static string GetDateFromIntReverse(object date)
        {
            var strDate = date.ToString();
            if (strDate.Length == 8)
                return (strDate.Substring(0, 4) + @"/" + strDate.Substring(4, 2) + "/" + strDate.Substring(6, 2))
                    ;
            return string.Empty;
        }

        public static string GetTimeFromInt(object intTime)
        {
            if (intTime == null)
                return string.Empty;
            var time = intTime.ToString();
            if (time.Length == 4)
                time = "00" + time;
            if (time.Length == 6)
                return (time.Substring(0, 2) + ":" + time.Substring(2, 2));
            return string.Empty;
        }


        public static string GetTimeFromIntSimple(object intTime)
        {
            /*
             02:33   233
             00:33   33
             22:33   2233
             
             */
            if (intTime == null)
                return string.Empty;
            var time = intTime.ToString();
            if (time.Length == 3)
            {
                time = "0" + time;
            }
            if (time.Length == 2)
                time = "00" + time;
            if (time.Length == 4)
                //return (Int32.Parse(time.Substring(0, 2) )+ ":" +Int32.Parse(time.Substring(2, 2)));
                return time.Substring(0, 2) + ":" + time.Substring(2, 2);
            return string.Empty;
        }

        public static object TodayShamsiString()
        {
            return GetDateStringFromInt(TodayShamsiInt());
        }

        public static object TimeString()
        {
            return GetTimeFromInt(GetTimeInt());
        }

        public static string GetDate(string strDate, string lang)
        {
            if (string.IsNullOrWhiteSpace(lang) || lang.Trim() == "" || lang == "fa" ||
                string.IsNullOrWhiteSpace(strDate))
            {
                return strDate;
            }
            strDate = strDate.Replace("/", "");
            int year = Convert.ToInt32(strDate.Substring(0, 4));
            int month = Convert.ToInt32(strDate.Substring(4, 2));
            int day = Convert.ToInt32(strDate.Substring(6, 2));
            DateTime dt = new PersianCalendar().ToDateTime(year, month, day, 5, 1, 1, 1);

            return dt.ToShortDateString();
        }
    }
}