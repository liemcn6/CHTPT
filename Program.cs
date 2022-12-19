using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			string FormatDateTime = "dd/MM/yyyy HH:mm:ss.fff";
			byte[] ntpData = new byte[48];
			long OriginateTimeUtcTick = 0;

            //DateTime OriginateSendTimestamp = System.DateTime.Now; //T1     

            ExamForNtp01 m_examwebservice = new ExamForNtp01();
			string name = "Ligirk";
			string pass = "Nguyenthean99@";
			string rev = m_examwebservice.GetNtpMessage(name, pass, 442, 31824, ref OriginateTimeUtcTick, ref ntpData);
			Console.WriteLine(rev);

			byte Position = 24; //Received Time 
			 DateTime OriginateSendTimestamp = DateTimeParser(ntpData, Position).ToLocalTime(); // T1
			// DateTime OriginateReceiveTimestamp = System.DateTime.Now; //T4
			DateTime OriginateReceiveTimestamp = new DateTime(OriginateTimeUtcTick).ToLocalTime(); // T4
			Position = 32;
			DateTime ReceiveTimestamp = DateTimeParser(ntpData, Position).ToLocalTime(); //T2
            Position = 40;
			DateTime TransmitTimestamp = DateTimeParser(ntpData, Position).ToLocalTime(); //T3
			long Theta = (long)Math.Round(((ReceiveTimestamp.Ticks - OriginateSendTimestamp.Ticks) + (TransmitTimestamp.Ticks - OriginateReceiveTimestamp.Ticks)) / 2.0, 0, MidpointRounding.AwayFromZero);
			DateTime FinalDateTime = OriginateReceiveTimestamp.AddTicks(Theta);

            rev = m_examwebservice.Submit(name, pass, 442, 31824, OriginateSendTimestamp, ReceiveTimestamp, TransmitTimestamp, OriginateReceiveTimestamp, Theta, FinalDateTime);
            Console.WriteLine(rev);

            Console.WriteLine("T1: " + OriginateSendTimestamp.ToString(FormatDateTime));
			Console.WriteLine("T2: " + ReceiveTimestamp.ToString(FormatDateTime));
			Console.WriteLine("T3: " + TransmitTimestamp.ToString(FormatDateTime));
			Console.WriteLine("T4: " + OriginateReceiveTimestamp.ToString(FormatDateTime));
			Console.WriteLine("Theta: " + Theta.ToString());
			Console.WriteLine("Final: " + FinalDateTime.ToString(FormatDateTime));

			Console.ReadKey();
		}



		//---------------------------------------------------------------------------
		static uint SwapEndianness(ulong x)
		{
			return (uint)(((x & 0x000000ff) << 24) +
										 ((x & 0x0000ff00) << 8) +
										 ((x & 0x00ff0000) >> 8) +
										 ((x & 0xff000000) >> 24));
		}
		//---------------------------------------------------------------------------
		static DateTime DateTimeParser(byte[] ntpData, byte Position)
		{
			DateTime RetVal = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);//**UTC** time
			try
			{
				ulong intPart = BitConverter.ToUInt32(ntpData, Position);//Get the seconds part
				ulong fractPart = BitConverter.ToUInt32(ntpData, Position + 4);//Get the seconds fraction
																			   //Convert From big-endian to little-endian
				intPart = SwapEndianness(intPart);
				fractPart = SwapEndianness(fractPart);
				ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
				//Max Integer  0xffffffff
				//            +         1
				//            0x100000000L
				RetVal = RetVal.AddMilliseconds((long)milliseconds);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return RetVal;
		}
	}
}
