using System;
using System.Collections.Generic;
using System.Text;

namespace GD3100Debugger
{
	class ConfigInfo
	{
		public enum Enable
		{
			Disable = 0,
			Enable = 1,
		}
		public enum Protocols
		{
			Normal = 0,
			Xmodem = 1,
		}
		//public enum Parity
		//{
		//	Disable = 0,
		//	EVEN = 2,
		//	ODD = 3,
		//}

		public enum StopBits : int
		{
			OneBit = 0,
			TwoBit = 1,
		}

		public enum Parity
		{
			无 = 0,
			奇校验 = 2,
			偶校验 = 3,
		};

		public enum TransferMode
		{
			模式0 = 0,
			模式1 = 1,
			模式2 = 2,
		}
	public static string[] Bauds= 
		{
			"1200",
			"2400",
			"4800",
			"9600",
			"19200",
			"38400",
			"43000",
			"56000",
			"57600", 
			"115200",
			//"Custom",
		};

		public static string[] CanBauds =
		{
			"5kbps",
			"10kbps",
			"20kbps",
			"50kbps",
			"100kbps",
			"125kbps",
			"250kbps",
			"500kbps",
			"800kbps",
			"1000kbps",
			//"Custom",
		};

	}
}
