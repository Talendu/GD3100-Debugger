using System;
using System.Collections.Generic;
using System.Text;

namespace GD3100Debugger
{
	class Xmodem
	{
		public enum CtrlChar
		{
			SOH = 0x01,     //Xmodem数据头
			STX = 0x02,     //1K-Xmodem数据头
			EOT = 0x04,     //发送结束
			ACK = 0x06,     //认可响应
			NAK = 0x15,     //不认可响应
			CAN = 0x18,     //撤销传送
			ESC = 0x1b,
			CTRLZ = 0x1A,   //填充数据包
		};

		public static int SECTOR_SIZE = 128;
		
		public int CheckControlChar(char ControlChar)
		{
			switch (ControlChar)
			{
				case (char)CtrlChar.SOH:
					break;
			}
			return 0;
		}

		private void SendBuff(object Sender)
		{

		}
		public static int calcrc(byte[] ptr,int index, int count)
		{
			int crc;
			int temp = 0;
			byte i;
			int end = index + count;
			crc = 0;
			for(int j= index; j<end; j++)
			{
				temp = ptr[j];
				crc = crc ^ temp << 8;
				i = 8;
				do
				{
					if ((crc & 0x8000) != 0)
						crc = crc << 1 ^ 0x1021;
					else
						crc = crc << 1;
				} while (--i > 0);
			}
			return (crc);
		}
	}
}
