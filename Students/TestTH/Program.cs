using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestTH
{
    class Program
    {
        private static object ntpMesage;

        public static object OriginateTimeUtcTick { get; private set; }

        static void Main(string[] args)
        {
            try
            {
                ExamForNtp01 exam = new ExamForNtp01();
                string FormatDateTime = "dd/MM/yyyy HH:mm:ss.fff";
                const string ntpServer = "time.windows.com";
                IPAddress[] addresses = Dns.GetHostEntry(ntpServer).AddressList;

                IPEndPoint ipEndPoint = new IPEndPoint(addresses[0], 123);

                byte[] ntpData = new byte[48];
                ntpData[0] = 0x1B;
                DateTime OriginateSendTimestamp = System.DateTime.Now;//T1
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    socket.Connect(ipEndPoint);
                    socket.ReceiveTimeout = 3000;
                    socket.Send(ntpData);
                    socket.Receive(ntpData);
                    socket.Close();
                }
                DateTime OriginateReceiveTimestamp = new DateTime(exam.GetNtpMessage("Quangliemcn6","Quangliem3173@",442,31838,OriginateTimeUtcTick,ntpMesage); //T4
                byte Position = 32;  
                DateTime ReceiveTimestamp = DateTimeParser(ntpData, Position).ToLocalTime(); //T2
                Position = 40;
                DateTime TransmitTimestamp = DateTimeParser(ntpData, Position).ToLocalTime(); //T3
                long Theta = (long)Math.Round(((ReceiveTimestamp.Ticks - OriginateSendTimestamp.Ticks) + (TransmitTimestamp.Ticks - OriginateReceiveTimestamp.Ticks)) / 2.0, 0, MidpointRounding.AwayFromZero);
                DateTime FinalDateTime = OriginateReceiveTimestamp.AddTicks(Theta);
                DateTimeUtils.SetDateTime(FinalDateTime.ToUniversalTime());
               
                exam.Submit("Quangliemcn6", "Quangliem3173@", 442, 31838, OriginateSendTimestamp, ReceiveTimestamp, TransmitTimestamp, OriginateReceiveTimestamp, DifferentTicks, DateTimeAfterSynchronize);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\n Press any key to end...");
            Console.ReadKey();
        }
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                                         ((x & 0x0000ff00) << 8) +
                                         ((x & 0x00ff0000) >> 8) +
                                         ((x & 0xff000000) >> 24));
        }
        static DateTime DateTimeParser(byte[] ntpData, byte Position)
        {
            DateTime RetVal = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            try
            {
                ulong intPart = BitConverter.ToUInt32(ntpData, Position);
                ulong fractPart = BitConverter.ToUInt32(ntpData, Position + 4);
                                                                              
                intPart = SwapEndianness(intPart);
                fractPart = SwapEndianness(fractPart);
                ulong milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
                
                RetVal = RetVal.AddMilliseconds((long)milliseconds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RetVal;
        }
    }
    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Millisecond;
    };
    public class DateTimeUtils
    {
        [DllImport("kernel32.dll")]
        private extern static void GetSystemTime(ref SystemTime lpSystemTime);
        [DllImport("kernel32.dll")]
        private extern static uint SetSystemTime(ref SystemTime lpSystemTime);
        public static void SetDateTime(DateTime mDateTime)
        {
            try
            {
                SystemTime systime = new SystemTime();
                systime.Year = (ushort)mDateTime.Year;
                systime.Month = (ushort)mDateTime.Month;
                systime.DayOfWeek = (ushort)mDateTime.DayOfWeek;
                systime.Day = (ushort)mDateTime.Day;
                systime.Hour = (ushort)mDateTime.Hour;
                systime.Minute = (ushort)mDateTime.Minute;
                systime.Second = (ushort)mDateTime.Second;
                systime.Millisecond = (ushort)mDateTime.Millisecond;
                SetSystemTime(ref systime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}    