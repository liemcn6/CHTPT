using System;
using System.Collections.Generic;

namespace bakerley
{
    public class Program
    {
        static void Main(string[] args)
        {
			//Tinh trung binh
			string dp = "2021-07-12 14:23:31.439";
			List<string> tv = new List<string>();
			tv.Add("2021-07-12 14:22:30.669");
			tv.Add("2021-07-12 14:24:32.319");
			tv.Add("2021-07-12 14:22:30.446");

			string FormatDateTime = "yyyy-MM-dd HH:mm:ss.fff";

			List<DateTime> thanhvien = new List<DateTime>();
			DateTime dieuphoi = DateTime.ParseExact(dp, FormatDateTime,
									   System.Globalization.CultureInfo.InvariantCulture);
			for (int i = 0; i < tv.Count; i++)
			{
				DateTime myDate = DateTime.ParseExact(tv[i], FormatDateTime,
									   System.Globalization.CultureInfo.InvariantCulture);
				thanhvien.Add(myDate);
			}
			long dem = 0;
			List<long> chinh = new List<long>();
			for (int i = 0; i < thanhvien.Count; i++)
			{
				dem += thanhvien[i].Ticks - dieuphoi.Ticks;
				chinh.Add((thanhvien[i].Ticks - dieuphoi.Ticks) / 10000);
			}
			double num = tv.Count + 1;
			long Theta = (long)Math.Round((dem / 10000) / num, 0, MidpointRounding.AwayFromZero);
			Console.WriteLine("Dieu phoi: " + Theta);

			for (int i = 0; i < chinh.Count; i++)
			{
				Console.WriteLine("Thanh vien " + (i + 1) + ": " + (Theta - chinh[i]));
			}
			DateTime dongbo = dieuphoi.AddTicks(Theta * 10000);
			Console.WriteLine("Sau khi dong bo: " + dongbo.ToString("yyyy-MM-dd HH:mm:ss.fff"));
		}
	}
    
}
