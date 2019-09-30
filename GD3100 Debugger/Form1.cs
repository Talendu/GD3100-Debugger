using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;

namespace GD3100Debugger
{
	public partial class Form1 : Form
	{

        public MyDelegate cfgAllRegsFormMessage;


        SerialPort serialPort = null;
		string prePortName	= null;
		
		bool isOpen = false;
		bool isShowDataInHex = false;
		bool isSendDataInHex = false;
		bool isShowSend = true;
		bool isSendNewLine = false;
		bool isAutoNewLine = false;
		bool isRegularSend = false;
		bool isSendingFile = false;
		bool isConfigPageOpend = false;
		int SendProgress = 0;

		long SendFileStartTime = 0;

		ConfigInfo.Protocols protocol;
		
		int RegularCycle = 10;
		int TransmissionCount = 0;
		int ReceiveCount		= 0;

		string SendFileName	= null;

		private List<Button> ReadButtons;
		private List<string> ConfigItems;
		private List<SerialDataReceivedEventHandler> ReceivedHandlers;

		Thread RegularSendThread	= null;
		Thread SendNormalFileThread = null;
		Thread SendXmodemFileThread = null;
		//Thread ShowMessageThread	= null;

		public const int WM_DEVICE_CHANGE = 0x219;
		public const int DBT_DEVICEARRIVAL = 0x8000;
		public const int DBT_DEVICE_REMOVE_COMPLETE = 0x8004;
		public const UInt32 DBT_DEVTYP_PORT = 0x00000003;
		[StructLayout(LayoutKind.Sequential)]
		struct DEV_BROADCAST_HDR
		{
			public UInt32 dbch_size;
			public UInt32 dbch_devicetype;
			public UInt32 dbch_reserved;
		}

		[StructLayout(LayoutKind.Sequential)]
		protected struct DEV_BROADCAST_PORT_Fixed
		{
			public uint dbcp_size;
			public uint dbcp_devicetype;
			public uint dbcp_reserved;
		}


		public Form1()
		{
			InitializeComponent();
		}

		protected override void DefWndProc(ref Message m)
		{
			if (m.Msg == WM_DEVICE_CHANGE)        // 捕获USB设备的拔出消息WM_DEVICECHANGE
			{
				switch (m.WParam.ToInt32())
				{
					case DBT_DEVICE_REMOVE_COMPLETE:    // USB拔出
						if ((!serialPort.IsOpen) && isOpen)
						{
							btnOpenCom_Click(null, null);
						}
						break;
					//case DBT_DEVICEARRIVAL:             // USB插入获取对应串口名称
					//	DEV_BROADCAST_HDR dbhdr = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam,
					//		typeof(DEV_BROADCAST_HDR));
					//	if (dbhdr.dbch_devicetype == DBT_DEVTYP_PORT)
					//	{
					//		string portName = Marshal.PtrToStringUni((IntPtr)(m.LParam.ToInt32()
					//			+ Marshal.SizeOf(typeof(DEV_BROADCAST_PORT_Fixed))));
					//		Console.WriteLine("Port '" + portName + "' arrived.");
					//	}
					//	break;
				}
			}
			base.DefWndProc(ref m);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//this.MaximumSize = this.Size;
			//this.MinimumSize = this.Size;
			//this.MaximizeBox = false;
			ReadButtons = new List<Button>();
			ConfigItems = new List<string>();
			ReceivedHandlers = new List<SerialDataReceivedEventHandler>();
			this.serialPort = new SerialPort();
			
			foreach (string baud in ConfigInfo.Bauds)
			{
				cbxBoud.Items.Add(baud);
			}

			foreach (string stopbit in Enum.GetNames(typeof(ConfigInfo.StopBits)))
			{
				cbxStopBit.Items.Add(stopbit);
			}

			foreach (string parity in Enum.GetNames(typeof(ConfigInfo.Parity)))
			{
				cbxVerify.Items.Add(parity);
			}

			foreach (string protocol in Enum.GetNames(typeof(ConfigInfo.Protocols)))
			{
				cbxProtocol.Items.Add(protocol);
			}

			cbxBoud.SelectedItem = "115200";
			cbxStopBit.SelectedIndex = 0;
			cbxVerify.SelectedIndex = 0;
			cbxProtocol.SelectedIndex = (int)ConfigInfo.Protocols.Normal;

            tbxCycle.Text = RegularCycle.ToString();

			serialPort.DataBits = 8;
			serialPort.ReadTimeout = 1000000/11520;
			serialPort.DataReceived += new SerialDataReceivedEventHandler(serialDataReceive);
			ReceivedHandlers.Add(serialDataReceive);

			GetSerialPort();
			if (cbxComPort.Items.Count > 0)
			{
				cbxComPort.SelectedIndex = 0;
			}
            cfgAllRegsFormMessage = new MyDelegate(cfgAllRegsFormMessageHandle);
            //ShowMessageThread = new Thread(
            //	new ParameterizedThreadStart(ShowMessage));
        }

		private void checkBoxShowInHex_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxShowInHex.CheckState == CheckState.Checked)
			{
				isShowDataInHex = true;
			} 
			else
			{
				isShowDataInHex = false;
			}
		}

		private void checkBoxAutoNewLine_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxAutoNewLine.CheckState == CheckState.Checked)
			{
				isAutoNewLine = true;
			}
			else if (checkBoxAutoNewLine.CheckState == CheckState.Unchecked)
			{
				isAutoNewLine = false;
			}
		}

		private void checkBoxSendHex_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxSendHex.CheckState == CheckState.Checked)
			{
				isSendDataInHex = true;
			}
			else
			{
				isSendDataInHex = false;
			}
		}

		private void checkBoxSendNewLine_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxSendNewLine.CheckState == CheckState.Checked)
			{
				isSendNewLine = true;
			}
			else if (checkBoxSendNewLine.CheckState == CheckState.Unchecked)
			{
				isSendNewLine = false;
			}
		}

		private void checkBoxSendRegular_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxSendRegular.CheckState == CheckState.Checked)
			{
				if (isOpen == false)
				{
					checkBoxSendRegular.Checked = false;
					return;
				}
				isRegularSend = true;
				if (RegularSendThread == null)
				{
					RegularSendThread = new Thread(new ThreadStart(RegularSenMethod));
					RegularSendThread.Start();
				}
			}
			if (checkBoxSendRegular.CheckState == CheckState.Unchecked)
			{
				isRegularSend = false;
				if (RegularSendThread != null)
				{
					RegularSendThread.Abort();
					RegularSendThread = null;
				}
			}
		}
        public enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。

            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//all device
        }

        private static string[] MulGetHardwareInfo(HardwareEnum hardType, string propKey)
        {
            List<string> strs = new List<string>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties[propKey].Value != null && hardInfo.Properties[propKey].Value.ToString().Contains("COM"))
                        {
                            strs.Add(hardInfo.Properties[propKey].Value.ToString());
                        }

                    }
                    searcher.Dispose();
                }

                return strs.ToArray();
            }
            catch
            {
                return strs.ToArray();
            }
        }

        private void GetSerialPort()   //获取串口列表  
		{
			RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
			if (keyCom != null)
			{
				string[] sSubKeys = keyCom.GetValueNames();

                //sSubKeys = MulGetHardwareInfo(HardwareEnum.Win32_PnPEntity, "Name");

                List<string> comPorts = new List<string>();
				//cbxComPort.Items.Clear();
				foreach (string sName in sSubKeys)
				{
					string sValue = (string)keyCom.GetValue(sName);
					comPorts.Add(sValue);
					if (cbxComPort.Items.Count == 0 || cbxComPort.Items.Contains(sValue) == false)
					{
						cbxComPort.Items.Add(sValue);
					}
				}
                if (cbxComPort.Items.Count > 0)
                {
                    foreach (string prePort in cbxComPort.Items)
                    {
                        if (comPorts.Contains(prePort) == false)
                        {
                            cbxComPort.Items.Remove(prePort);
                        }
                    }
                }
			}
		}

		private void cbxComPort_DropDown(object sender, EventArgs e)
		{
			GetSerialPort();
		}

		private void cbxComPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (prePortName!=null && prePortName.CompareTo(cbxComPort.Text.Trim()) == 0)
			{
				return;
			}
			prePortName = cbxComPort.Text.Trim();
			if (isOpen)
			{
				try
				{
					serialPort.Close();
					isOpen = false;
				}
				catch (Exception)
				{
					MyMessage msg = new MyMessage(3);
					msg.SetObj("\r\n错误:改变端口失败!\r\n");
					ShowMessage(msg);
				}
			}
			serialPort.PortName = cbxComPort.Text.Trim();
			if (isOpen)
			{
				try
				{
					serialPort.Open();
					isOpen = true;
				}
				catch (Exception)
				{
					MyMessage msg = new MyMessage(3);
					msg.SetObj("\r\n错误:改变端口失败!\r\n");
					ShowMessage(msg);
				}
			}
		}


		private void setBaud()
		{
			try
			{
				serialPort.BaudRate = Convert.ToInt32(cbxBoud.Text.Trim());
			}
			catch (Exception)
			{
				MyMessage msg = new MyMessage(3);
				msg.SetObj("\r\n错误:非法波特率!\r\n");
				ShowMessage(msg);
			}
		}

		private void cbxBoud_SelectedIndexChanged(object sender, EventArgs e)
		{
			setBaud();
		}

		private void cbxBoud_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				setBaud();
			}
		}

		private void cbxBoud_Leave(object sender, EventArgs e)
		{
			setBaud();
		}


		private void cbxStopBit_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxStopBit.Text.CompareTo(ConfigInfo.StopBits.OneBit.ToString()) == 0)
			{
				serialPort.StopBits = StopBits.One;
			}
			else if (cbxStopBit.Text.CompareTo(ConfigInfo.StopBits.TwoBit.ToString()) == 0)
			{
				serialPort.StopBits = StopBits.Two;
			}
		}

		private void cbxVerify_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxVerify.Text.CompareTo("无") == 0)
			{
				serialPort.Parity = Parity.None;
			} 
			else if (cbxVerify.Text.CompareTo("奇校验") == 0)
			{
				serialPort.Parity = Parity.Odd;
			}
			else if (cbxVerify.Text.CompareTo("偶校验") == 0)
			{
				serialPort.Parity = Parity.Even;
			}
		}

		private void cbxProtocol_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxProtocol.SelectedIndex == (int)ConfigInfo.Protocols.Normal)
			{
				protocol = ConfigInfo.Protocols.Normal;
			}
			else if (cbxProtocol.SelectedIndex == (int)ConfigInfo.Protocols.Xmodem)
			{
				protocol = ConfigInfo.Protocols.Xmodem;
			}
		}


		private void btnOpenCom_Click(object sender, EventArgs e)
		{
			if (serialPort.PortName == null)
			{
				return;
			}
			if (isOpen == false)
			{
				try
				{
					serialPort.Open();
					isOpen = true;
					btnOpenCom.Text = "关闭串口";

				}
				catch(Exception)
				{
					isOpen = false;
					btnOpenCom.Text = "打开串口";

					MyMessage msg = new MyMessage(3);
					msg.SetObj("\r\n错误:串口打开失败!\r\n");
					ShowMessage(msg);
				}
			}
			else
			{
				try
				{ 
					serialPort.Close();
					isOpen = false;
					btnOpenCom.Text = "打开串口";
				} catch (Exception)
				{
					MyMessage msg = new MyMessage(3);
					msg.SetObj("\r\n错误:关闭打开失败!\r\n");
					ShowMessage(msg);
				}
			}
		}

		private void btnClearData_Click(object sender, EventArgs e)
		{
			tbxData.Clear();
			TransmissionCount = 0;
			ReceiveCount = 0;
			tbxSendCount.Text = "0";
			tbxReceiveCount.Text = "0";
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if (isOpen == false )
			{
				btnOpenCom_Click(null, null);
			}
			serialDataTransmission(tbxSend.Text);
		}

		private void btnClearSend_Click(object sender, EventArgs e)
		{
			tbxSend.Text = "";
		}

		private void btnOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "F:\\ZLG\\Workspace\\GraduationDesign\\CAN2UART\\Debug";//注意这里写路径时要用c:\\而不是c:\
			if (cbxProtocol.SelectedIndex == 0)
			{
				openFileDialog.Filter = "文本文件|*.text*|所有文件|*.*";
			}
			else if (cbxProtocol.SelectedIndex == 1)
			{
				openFileDialog.Filter = "bin文件|*.bin*|文本文件|*.text*|所有文件|*.*";
			}
			openFileDialog.RestoreDirectory = true;
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				SendFileName = openFileDialog.FileName;
				textBoxFileName.Text = SendFileName;

				FileInfo fileInfo = new FileInfo(SendFileName);
				MyMessage msg = new MyMessage(3);
				msg.SetObj("文件大小:" + fileInfo.Length.ToString() + "字节\r\n");
				ShowMessage(msg);
				//byte[] filebuff = File.ReadAllBytes(SendFileName);
				//ShowBytes(filebuff, 2);
			}
		}

		private void btnSendFile_Click(object sender, EventArgs e)
		{
			if (isSendingFile == false && isOpen)
			{
				cbxProtocol.Enabled = false;
				btnSend.Enabled = false;
				btnOpenFile.Enabled = false;
				btnOpenCom.Enabled = false;
				isSendingFile = true;

				SendProgress = 0;
				pgrsBarSendPgrs.Value = 0;
				LabelProgress.Text = "0%";

				SendFileStartTime = DateTime.Now.Ticks;
				if (protocol == ConfigInfo.Protocols.Xmodem)
				{
					if (ReceivedHandlers.Contains(serialDataReceive))
					{
						serialPort.DataReceived -= serialDataReceive;
						ReceivedHandlers.Remove(serialDataReceive);
					}
					if (!ReceivedHandlers.Contains(FileSendXmodemHandle))
					{
						serialPort.DataReceived += FileSendXmodemHandle;
						ReceivedHandlers.Add(FileSendXmodemHandle);
					}
					
				}
				if (protocol == ConfigInfo.Protocols.Normal)
				{
					SendFile(SendFileName);
				}
			}
		}

		private void btnStopSendFile_Click(object sender, EventArgs e)
		{
			if (isSendingFile)
			{
				cbxProtocol.Enabled = true;
				btnSend.Enabled = true;
				btnOpenFile.Enabled = true;
				btnOpenCom.Enabled = true;

				isSendingFile = false;
				if (protocol == ConfigInfo.Protocols.Xmodem)
				{
					if (!ReceivedHandlers.Contains(serialDataReceive))
					{
						serialPort.DataReceived += serialDataReceive;
						ReceivedHandlers.Add(serialDataReceive);
					}
					if (ReceivedHandlers.Contains(FileSendXmodemHandle))
					{
						serialPort.DataReceived -= FileSendXmodemHandle;
						ReceivedHandlers.Remove(FileSendXmodemHandle);
					}
					if (SendXmodemFileThread != null)
					{
						try
						{
							SendXmodemFileThread.Abort();
							SendXmodemFileThread = null;
						}
						catch (Exception)
						{

						}
					}
				}
				else if (protocol == ConfigInfo.Protocols.Normal)
				{
					if (SendNormalFileThread != null)
					{
						try
						{
							SendNormalFileThread.Abort();
							SendNormalFileThread = null;
						}
						catch (Exception)
						{

						}
					}
				}
			}
		}


		private void tbxCycle_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\n')
			{
				try
				{
					RegularCycle = Convert.ToInt32(tbxCycle.Text);
					if (RegularCycle < 10)
					{
						RegularCycle = 10;
					}
				}
				catch (Exception)
				{
					MyMessage msg = new MyMessage(3);
					msg.SetObj("\r\n错误:错误参数!\r\n");
					ShowMessage(msg);
					RegularCycle = 1;
                    tbxCycle.Text = "1";
				}
			}
			if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void tbxCycle_Leave(object sender, EventArgs e)
		{
			try
			{
				RegularCycle = Convert.ToInt32(tbxCycle.Text);
				if (RegularCycle < 10)
				{
					RegularCycle = 10;
				}
			}
			catch (Exception)
			{
				MyMessage msg = new MyMessage(3);
				msg.SetObj("\r\n错误:错误参数!\r\n");
				ShowMessage(msg);
				RegularCycle = 1;
                tbxCycle.Text = "1";
			}
		}


		private void serialDataTransmission(string data)
		{
			if (isOpen == false)
			{
				return;
			}
			if (data == null || data.CompareTo("") == 0)
			{
				return;
			}

			if (isSendDataInHex == false)
			{
				byte[] buff;
				if (isSendNewLine)
				{
					data += "\r\n";
				}
				buff = Encoding.Default.GetBytes(data);
				if (isShowSend)
				{
					MyMessage msg = new MyMessage(1);
					msg.SetObj(Encoding.Default.GetString(buff));
					ShowMessage(msg);
				}
				TransmissionCount += buff.Length;
				tbxSendCount.Text = (TransmissionCount).ToString();
				serialPort.Write(buff, 0, buff.Length);
			}
			else
			{
				Byte[] Buff = new Byte[(tbxSend.Text.Length + 1) / 2 + 2];
				int Len = 0;
				Len = hex2num(tbxSend.Text, Buff);

				if (isSendNewLine)
				{
					Buff[Len++] = (byte)'\r';
					Buff[Len++] = (byte)'\n';
				}

				TransmissionCount += Len;
				tbxSendCount.Text = (TransmissionCount).ToString();
				serialPort.Write(Buff, 0, Len);
				if (isShowSend)
				{
					MyMessage msg = new MyMessage(1);
					msg.SetObj(tbxSend.Text);
					ShowMessage(msg);
				}
			}
		}

		private void serialDataReceive(object sender, SerialDataReceivedEventArgs e)
		{
			byte[] buff = new byte[serialPort.BytesToRead];
			serialPort.Read(buff, 0, buff.Length);
			ReceiveCount += buff.Length;
			if (isShowDataInHex)
			{
				ShowBytes(buff, 2);
			}
			else
			{
				ShowBytes(buff, 1);
			}
		}

		private void FileSendXmodemHandle(object sender, SerialDataReceivedEventArgs e)
		{
			while (isSendingFile)
			{
				if (serialPort.BytesToRead <= 0)
				{
					continue;
				}
				byte data = (byte)serialPort.ReadByte();
				switch (data)
				{
					case (byte)'C':
						SendFile(SendFileName);
						while (isSendingFile) ;
							break;
					case (byte)Xmodem.CtrlChar.CAN:
						break;
					default:
						this.Invoke((EventHandler)(delegate
						{
							ShowBytes(Encoding.Default.GetBytes(data.ToString()), 1);
						}));
						break;
				}
			}
		}

		private void ShowMessage(object msg)
		{
			MyMessage message = (MyMessage)msg;
			if (message == null || message.GetObj() == null)
			{
				return;
			}
			this.Invoke((EventHandler)(delegate
			{

				switch (message.GetWhat())
				{
					case 1:
						{
							if (checkBoxShowSend.CheckState == CheckState.Checked)
							{
								tbxData.SelectionStart = tbxData.Text.Length;
								tbxData.SelectionColor = Color.OrangeRed;
								tbxData.AppendText((string)message.GetObj());
								if (isAutoNewLine)
								{
									tbxData.AppendText("\r\n");
								}
								tbxData.ScrollToCaret();
							}
							break;
						}
					case 2:
						{
							tbxData.SelectionStart = tbxData.Text.Length;
							tbxData.SelectionColor = Color.Blue;
							tbxData.AppendText((string)message.GetObj());
							if (isAutoNewLine)
							{
								tbxData.AppendText("\r\n");
							}
							tbxData.ScrollToCaret();
							break;
						}
					case 3:
						{
							tbxData.SelectionStart = tbxData.Text.Length;
							tbxData.SelectionColor = Color.Red;
							tbxData.AppendText((string)message.GetObj());
							tbxData.AppendText("\r\n");
							tbxData.ScrollToCaret();
							break;
						}
				}
			}));
		}

		private void ShowBytes(byte[] buff, int type)
		{
			string receive = null;
			switch (type)
			{
				case 1:
					receive = Encoding.Default.GetString(buff);
					break;
				case 2:
					for (int i = 0; i < buff.Length; i++)
					{
						receive += buff[i].ToString("X2") + " ";
					}
					break;
				default:
					return;
			}
			MyMessage message = new MyMessage(2);
			message.SetObj(receive);
			this.Invoke((EventHandler)(delegate
			{
				tbxReceiveCount.Text = ReceiveCount.ToString();
				ShowMessage(message);
			}));
		}

		private void RegularSenMethod()
		{
			while (isRegularSend)
			{
				this.Invoke((EventHandler)(delegate
				{
					try
					{
						serialDataTransmission(tbxSend.Text);
						if (isOpen == false || tbxSend.Text.CompareTo("") == 0)
						{
							checkBoxSendRegular.Checked = false;
						}
					}
					catch (Exception)
					{

					}
				}));
				do
				{
					try
					{
						Thread.Sleep(RegularCycle);
					}
					catch (Exception)
					{

					}
				} while (serialPort.BytesToWrite > 0);
			}
		}

		private void SendFile(string path)
		{
			Byte[] buff = null;
			if (path == null || File.Exists(path) == false)
			{
				MyMessage msg = new MyMessage(3);
				msg.SetObj("\r\n错误:文件不存在!\r\n");
				ShowMessage(msg);
				this.Invoke((EventHandler)(delegate
				{
					btnStopSendFile_Click(null, null);
				}));
				return;
			}
			buff = File.ReadAllBytes(path);
			if (buff.Length <= 0)
			{
				MyMessage msg = new MyMessage(3);
				msg.SetObj("\r\n错误:文件为空!\r\n");
				ShowMessage(msg);
				this.Invoke((EventHandler)(delegate
				{
					btnStopSendFile_Click(null, null);
				}));
				return;
			}
			if (protocol == ConfigInfo.Protocols.Normal)
			{
				if (SendNormalFileThread == null)
				{
					SendNormalFileThread = new Thread(
						new ParameterizedThreadStart(SendFileNormalMethod));
					SendNormalFileThread.Start(buff);
				}
			}
			else if (protocol == ConfigInfo.Protocols.Xmodem)
			{
				if (SendXmodemFileThread == null)
				{
					SendXmodemFileThread = new Thread(
						new ParameterizedThreadStart(SendFileXmodemMethod));
					SendXmodemFileThread.Start(buff);
				}
			}
		}

		private void SendFileXmodemMethod(object obj)
		{
			byte[] sendbuff = (byte[])obj;
			int packages = (sendbuff.Length + 127) / 128;
			int sentpackageNum = 0;
			int index = 0;
			int buffLen = sendbuff.Length;

			while (isSendingFile && buffLen > index)
			{
				index = sentpackageNum << 7;
				sentpackageNum++;
				int packageLen = buffLen - index;

				byte[] head = { (byte)Xmodem.CtrlChar.SOH,
					(byte)(sentpackageNum & 0xFF), (byte)((~sentpackageNum) & 0xFF) };
				serialPort.Write(head, 0, 3);
				if (packageLen >= 128)
				{
					packageLen = 128;
					serialPort.Write(sendbuff, index, packageLen);
					int crcret = Xmodem.calcrc(sendbuff, index, packageLen);
					byte[] crc = new byte[2];
					crc[1] = (byte)(crcret & 0xFF);
					crc[0] = (byte)((crcret & 0xFFFF) >> 8);
					serialPort.Write(crc, 0, 2);
				}
				else if (packageLen < 128)
				{
					byte[] pack = new byte[128];
					byte fell = (byte)Xmodem.CtrlChar.CTRLZ;

					Array.Copy(sendbuff, index, pack, 0, packageLen);
					for (int i = packageLen; i < 128; i++)
					{
						pack[i] = fell;
					}
					serialPort.Write(pack, 0, 128);

					int crcret = Xmodem.calcrc(pack, 0, 128);
					byte[] crc = new byte[2];
					crc[1] = (byte)(crcret & 0xFF);
					crc[0] = (byte)((crcret & 0xFFFF) >> 8);
					serialPort.Write(crc, 0, 2);
				}
				while (isSendingFile)
				{
					if (serialPort.BytesToRead > 0)
					{
						byte ack = (byte)serialPort.ReadByte();
						if (ack == (byte)Xmodem.CtrlChar.ACK)
						{
							SendProgress = sentpackageNum * 100 / packages;
							this.Invoke((EventHandler)(delegate
							{
								LabelProgress.Text = SendProgress.ToString() + "%";
								pgrsBarSendPgrs.Value = SendProgress;
							}));
							break;
						}
						else if (ack == (byte)Xmodem.CtrlChar.CAN)
						{
							byte[] can = { (byte)Xmodem.CtrlChar.CAN };
							serialPort.Write(can, 0, 1);
							return;
						}
						else if (ack == (byte)Xmodem.CtrlChar.NAK)
						{
							sentpackageNum--;
							break;
						}
					}
				}

				if (packages == sentpackageNum)
				{
					byte[] eot = { (byte)Xmodem.CtrlChar.EOT };
					serialPort.Write(eot, 0, 1);
					while (isSendingFile)
					{
						if (serialPort.BytesToRead > 0)
						{
							this.Invoke((EventHandler)(delegate
							{
								if (serialPort.ReadByte() == (byte)Xmodem.CtrlChar.ACK)
								{
									MyMessage msg = new MyMessage(3);
									msg.SetObj("\r\n发送完成!\r\n");
									ShowMessage(msg);
								}
								else
								{
									MyMessage msg = new MyMessage(3);
									msg.SetObj("\r\n错误:发送失败!\r\n");
									ShowMessage(msg);
								}
								btnStopSendFile_Click(null, null);
							}));
						}
					}
				}

			}

		}

		private void SendFileNormalMethod(object obj)
		{
			byte[] sendbuff = (byte[])obj;
			int packages = (sendbuff.Length + 127) / 128;
			int index = 0;
			for (int i=1; i<=packages; i++)
			{
				int packetLen = sendbuff.Length - index;
				if (packetLen > 128)
				{
					packetLen = 128;
				}
				serialPort.Write(sendbuff, index, packetLen);
				index += packetLen;
				if (isSendingFile == false)
				{
					break;
				}
				SendProgress = i*100 / packages;
				this.Invoke((EventHandler)(delegate
				{
					LabelProgress.Text = SendProgress.ToString() + "%";
					pgrsBarSendPgrs.Value = SendProgress;
				}));
			}
			this.Invoke((EventHandler)(delegate
			{
				long useTime = DateTime.Now.Ticks - SendFileStartTime;
				MyMessage msg = new MyMessage(3);
				msg.SetObj("\r\n文件发送完成!\r\n文件大小:"
					+ new FileInfo(SendFileName).Length.ToString()
					+ "字节\r\n"
					+ "用时:"
					+ ((useTime) /10000000).ToString()
					+ "."
					+ ((useTime) % 10000000).ToString()
					+ "s\r\n"
					);
				ShowMessage(msg);
				btnStopSendFile_Click(null, null);
			}));
		}

		public int hex2num(string Hexs, Byte[] Buff)
		{
			Int32 Len = 0;
			Int32 HexCycle = 0;
			int value = 0;
			foreach (char Hex in Hexs)
			{
				if ('0' <= Hex && Hex <= '9')
				{
					value <<= 4;
					value += Hex - '0';
					HexCycle++;
				}
				else if ('a' <= Hex && Hex <= 'f')
				{
					value <<= 4;
					value += Hex - 'a' + 10;
					HexCycle++;
				}
				else if ('A' <= Hex && Hex <= 'F')
				{
					value <<= 4;
					value += Hex - 'A' + 10;
					HexCycle++;
				}
				else if (Hex == ' ')
				{
					if (HexCycle == 1)
					{
						HexCycle = 0;
						Buff[Len] = (Byte)value;
						value = 0;
						Len++;
					}
				}
				else
				{
					break;
				}

				if (HexCycle == 2)
				{
					HexCycle = 0;
					Buff[Len] = (Byte)value;
					value = 0;
					Len++;
				}
			}
			if (HexCycle == 1)
			{
				HexCycle = 0;
				Buff[Len] = (Byte)value;
				value = 0;
				Len++;
			}
			if (Len == 0)
			{
				Buff.Initialize();
				return 0;
			}
			return Len;
		}


		private void tabControlSendMode_Selected(object sender, TabControlEventArgs e)
		{
			if (e.TabPageIndex == 0)
			{
				if (checkBoxSendHex.CheckState == CheckState.Checked)
				{
					isSendDataInHex = true;
				}
				else
				{
					isSendDataInHex = false;
				}

				if (checkBoxAutoNewLine.CheckState == CheckState.Checked)
				{
					isSendNewLine = true;
				}
				else if (checkBoxAutoNewLine.CheckState == CheckState.Unchecked)
				{
					isSendNewLine = false;
				}
			}
			else if (e.TabPageIndex == 1)
			{
				isSendDataInHex = false;
				isSendNewLine = true;
				if (isConfigPageOpend)
				{
					return;
				}
				isConfigPageOpend = true;
				//foreach (string baud in ConfigInfo.Bauds)
				//{
				//	cbxSetUartBaud.Items.Add(baud);
				//}
				//foreach (string stopbit in Enum.GetNames(typeof(ConfigInfo.StopBits)))
				//{
				//	cbxSetUartStopBits.Items.Add(stopbit);
				//}
				//foreach (string parity in Enum.GetNames(typeof(ConfigInfo.Parity)))
				//{
				//	cbxSetUartParity.Items.Add(parity);
				//}
				//foreach (string baud in ConfigInfo.CanBauds)
				//{
				//	cbxSetCanBaud.Items.Add(baud);
				//}
				//foreach (string baud in ConfigInfo.CanBauds)
				//{
				//	cbxSetCanFDBaud.Items.Add(baud);
				//}
				//foreach (string mode in Enum.GetNames(typeof(ConfigInfo.TransferMode)))
				//{
				//	cbxSetUartTxMode.Items.Add(mode);
				//	cbxSetUartRxMode.Items.Add(mode);
				//	cbxSetCanTxMode.Items.Add(mode);
				//	cbxSetCanRxMode.Items.Add(mode);
				//}
				//cbxSetUartTxMode.Items.RemoveAt(2);
				//cbxSetUartRxMode.Items.RemoveAt(2);

				//ReadButtons.Add(btnGetUartBaud);
				//ReadButtons.Add(btnGetStopBits);
				//ReadButtons.Add(btnGetParity);
				//ReadButtons.Add(btnGetTxMode);
				//ReadButtons.Add(btnGetRxMode);

				//ReadButtons.Add(btnGetCanBaud);
				//ReadButtons.Add(btnGetCanFDBaud);
				//ReadButtons.Add(btnGetRxId);
				//ReadButtons.Add(btnGetTxId);
				//ReadButtons.Add(btnGetIdMask);

				//ReadButtons.Add(btnGetCanFDEnable);
				//ReadButtons.Add(btnGetCanTxMode);
				//ReadButtons.Add(btnGetCanRxMode);

				ConfigItems.Add("@UBAUD");
				ConfigItems.Add("@USTOP");
				ConfigItems.Add("@UPARI");
				ConfigItems.Add("@UTMODE");
				ConfigItems.Add("@URMODE");

				ConfigItems.Add("@CBAUD");
				ConfigItems.Add("@CFDBAUD");
				ConfigItems.Add("@CRXID");
				ConfigItems.Add("@CTXID");
				ConfigItems.Add("@CIDMASK");

				ConfigItems.Add("@CFDEN");
				ConfigItems.Add("@CTMODE");
				ConfigItems.Add("@CRMODE");

			}
		}

		private void tabControlSendMode_Selecting(object sender, TabControlCancelEventArgs e)
		{
			e.Cancel = isSendingFile;
		}

		private void SetCanRxModeEvent(object sender, EventArgs e)
		{
			if (!CheckIsOpen())
			{
				return;
			}
			//if (cbxSetCanRxMode.Text.Equals(ConfigInfo.TransferMode.模式0.ToString()))
			//{
			//	serialDataTransmission("AT+@CRMODE=" + "0");
			//}
			//else if (cbxSetCanRxMode.Text.Equals(ConfigInfo.TransferMode.模式1.ToString()))
			//{
			//	serialDataTransmission("AT+@CRMODE=" + "1");
			//}
			//else if (cbxSetCanRxMode.Text.Equals(ConfigInfo.TransferMode.模式2.ToString()))
			//{
			//	serialDataTransmission("AT+@CRMODE=" + "2");
			//}
		}

		private void GetConfigInfoError()
		{
			MyMessage msg = new MyMessage(3);
			msg.SetObj("获取失败\r\n");
			ShowMessage(msg);
			if (ReceivedHandlers.Contains(serialInfoReceive))
			{
				serialPort.DataReceived -= serialInfoReceive;
				ReceivedHandlers.Remove(serialInfoReceive);
			}
			if (!ReceivedHandlers.Contains(serialDataReceive))
			{
				serialPort.DataReceived += serialDataReceive;
				ReceivedHandlers.Add(serialDataReceive);
			}
		}

		private void serialInfoReceive(object sender, SerialDataReceivedEventArgs e)
		{
			//byte[] buff = new byte[serialPort.BytesToRead];
			//serialPort.Read(buff, 0, buff.Length);
			//ReceiveCount += buff.Length;
			int g_uart_rx_sta = 0;
			int __LPUSART_REC_LEN = 32;

			byte[] buff = new byte[32];
			long timeout = DateTime.Now.Ticks + 1000000;
			while ((g_uart_rx_sta & 0x8000) == 0)
			{
				if (serialPort.BytesToRead > 0)
				{
					byte Res;
					if (timeout < DateTime.Now.Ticks)
					{
						GetConfigInfoError();
						return;
					}
					Res = (byte)serialPort.ReadByte(); /* 读取接收到的数据 */

					if ((g_uart_rx_sta & 0x8000) == 0)/* 接收未完成 */
					{
						if ((g_uart_rx_sta & 0x4000) != 0)     /* 接收到了0x0d */
						{
							if (Res != 0x0a)
							{           /* 接收错误,重新开始 */
								g_uart_rx_sta = 0;
								GetConfigInfoError();
								return;
							}
							else
							{                    /* 接收完成了 */
								g_uart_rx_sta |= 0x8000;
							}
						}
						else
						{                    /* 还没收到0X0D */
							if (Res == 0x0d)
							{             /* 收到0X0D */
								g_uart_rx_sta |= 0x4000;
							}
							else
							{                    /* 接到数据 */
								buff[g_uart_rx_sta & 0X3FFF] = Res;
								g_uart_rx_sta++;
								if (g_uart_rx_sta > (__LPUSART_REC_LEN - 1))
								{ /* 接收数据错误,重新开始接收 */
									g_uart_rx_sta = 0;
								}
							}
						}
					}
				}
			}
			string receive = Encoding.Default.GetString(buff).TrimEnd('\0');
			string[] receives = receive.Split(':');

			if (receives.Length > 1
				&& receives[1].Length > 0 
				&& ConfigItems.Contains(receives[0]))
			{
				foreach(char c in receives[1])
				{

					if ('0'> c || c> '9')
					{
						GetConfigInfoError();
						return;
					}
				}
				this.Invoke((EventHandler)(delegate
				{
					MyMessage msg1 = new MyMessage(2);
					msg1.SetObj(receive);
					ShowMessage(msg1);
					//switch(ConfigItems.IndexOf(receives[0]))
					//{
					//	case 0:
					//		cbxSetUartBaud.Text = receives[1];
					//		break;
					//	case 1:
					//		if (receives[1].Equals("0"))
					//		{
					//			//cbxSetUartStopBits.SelectedIndex = 0;
					//			cbxSetUartStopBits.Text = ConfigInfo.StopBits.OneBit.ToString();
					//		}
					//		else if (receives[1].Equals("1"))
					//		{
					//			//cbxSetUartStopBits.SelectedIndex = 1;
					//			cbxSetUartStopBits.Text = ConfigInfo.StopBits.TwoBit.ToString();
					//		}
					//		else
					//		{
					//			GetConfigInfoError();
					//			return;
					//		}
					//		break;
					//	case 2:
					//		if (receives[1].Equals("0"))
					//		{
					//			//cbxSetUartParity.SelectedIndex = 0;
					//			cbxSetUartParity.Text = ConfigInfo.Parity.无.ToString();
					//		}
					//		else if (receives[1].Equals("1"))
					//		{
					//			//cbxSetUartParity.SelectedIndex = 1;
					//			cbxSetUartParity.Text = ConfigInfo.Parity.奇校验.ToString();
					//		}
					//		else if (receives[1].Equals("2"))
					//		{
					//			//cbxSetUartParity.SelectedIndex = 2;
					//			cbxSetUartParity.Text = ConfigInfo.Parity.偶校验.ToString();
					//		}
					//		else
					//		{
					//			GetConfigInfoError();
					//			return;
					//		}
					//		break;
					//	case 3:
					//		if (receives[1].Equals("0"))
					//		{
					//			//cbxSetUartTxMode.SelectedIndex = 0;
					//			cbxSetUartTxMode.Text = ConfigInfo.TransferMode.模式0.ToString();
					//		}
					//		else if (receives[1].Equals("1"))
					//		{
					//			//cbxSetUartTxMode.SelectedIndex = 1;
					//			cbxSetUartTxMode.Text = ConfigInfo.TransferMode.模式1.ToString();
					//		}
					//		else
					//		{
					//			GetConfigInfoError();
					//			return;
					//		}
					//		break;
					//	case 4:
					//		if (receives[1].Equals("0"))
					//		{
					//			//cbxSetUartRxMode.SelectedIndex = 0;
					//			cbxSetUartRxMode.Text = ConfigInfo.TransferMode.模式0.ToString();
					//		}
					//		else if (receives[1].Equals("1"))
					//		{
					//			//cbxSetUartRxMode.SelectedIndex = 1;
					//			cbxSetUartRxMode.Text = ConfigInfo.TransferMode.模式1.ToString();
					//		}
					//		else
					//		{
					//			GetConfigInfoError();
					//			return;
					//		}
					//		break;
					//	case 5:
					//		cbxSetCanBaud.Text = receives[1].Substring(0, receives[1].Length-3) + "kbps";
					//		break;
					//	case 6:
					//		cbxSetCanFDBaud.Text = receives[1].Substring(0, receives[1].Length - 3) + "kbps";
					//		break;
					//	case 7:
					//		tbxSetCanRxId.Text = "0x" + Convert.ToInt32(receives[1]).ToString("X8");
					//		break;
					//	case 8:
					//		tbxSetCanTxId.Text = "0x" + Convert.ToInt32(receives[1]).ToString("X8");
					//		break;
					//	case 9:
					//		tbxSetCanIdMask.Text = "0x" + Convert.ToInt32(receives[1]).ToString("X8");
					//		break;
					//	case 10:
					//		if (receives[1].Equals("0"))
					//		{
					//			//cbxSetCanFDEnable.SelectedIndex = 0;
					//			cbxSetCanFDEnable.Text = ConfigInfo.Enable.Disable.ToString();
					//		}
					//		else if (receives[1].Equals("1"))
					//		{
					//			//cbxSetCanFDEnable.SelectedIndex = 1;
					//			cbxSetCanFDEnable.Text = ConfigInfo.Enable.Enable.ToString();
					//		}
					//		else
					//		{
					//			GetConfigInfoError();
					//			return;
					//		}
					//		break;
					//	case 11:
					//		if (receives[1].Equals("0"))
					//		{
					//			//cbxSetCanTxMode.SelectedIndex = 0;
					//			cbxSetCanTxMode.Text = ConfigInfo.TransferMode.模式0.ToString();
					//		}
					//		else if (receives[1].Equals("1"))
					//		{
					//			//cbxSetCanTxMode.SelectedIndex = 1;
					//			cbxSetCanTxMode.Text = ConfigInfo.TransferMode.模式1.ToString();
					//		}
					//		else if (receives[1].Equals("2"))
					//		{
					//			//cbxSetCanTxMode.SelectedIndex = 2;
					//			cbxSetCanTxMode.Text = ConfigInfo.TransferMode.模式2.ToString();
					//		}
					//		else
					//		{
					//			GetConfigInfoError();
					//			return;
					//		}
					//		break;
					//	case 12:
					//		if (receives[1].Equals("0"))
					//		{
					//			//cbxSetCanRxMode.SelectedIndex = 0;
					//			cbxSetCanRxMode.Text = ConfigInfo.TransferMode.模式0.ToString();
					//		}
					//		else if (receives[1].Equals("1"))
					//		{
					//			//cbxSetCanRxMode.SelectedIndex = 1;
					//			cbxSetCanRxMode.Text = ConfigInfo.TransferMode.模式1.ToString();
					//		}
					//		else if (receives[1].Equals("2"))
					//		{
					//			//cbxSetCanRxMode.SelectedIndex = 2;
					//			cbxSetCanRxMode.Text = ConfigInfo.TransferMode.模式2.ToString();
					//		}
					//		else
					//		{
					//			GetConfigInfoError();
					//			return;
					//		}
					//		break;
					//	default:
					//		GetConfigInfoError();
					//		return;
					//}

				}));
			}
			else
			{
				GetConfigInfoError();
				return;
			}

			MyMessage msg = new MyMessage(3);
			msg.SetObj("获取成功\r\n");
			ShowMessage(msg);
			if (ReceivedHandlers.Contains(serialInfoReceive))
			{
				serialPort.DataReceived -= serialInfoReceive;
				ReceivedHandlers.Remove(serialInfoReceive);
			}
			if (!ReceivedHandlers.Contains(serialDataReceive))
			{
				serialPort.DataReceived += serialDataReceive;
				ReceivedHandlers.Add(serialDataReceive);
			}
		}

		private void GetInfoEvent(object sender, EventArgs e)
		{
			serialDataTransmission("AT+" + ConfigItems[ReadButtons.IndexOf((Button)sender)]);
			if (ReceivedHandlers.Contains(serialDataReceive))
			{
				serialPort.DataReceived -= serialDataReceive;
				ReceivedHandlers.Remove(serialDataReceive);
			}
			if (!ReceivedHandlers.Contains(serialInfoReceive))
			{
				serialPort.DataReceived += serialInfoReceive;
				ReceivedHandlers.Add(serialInfoReceive);
			}
		}

		private bool CheckIsOpen()
		{
			if (isOpen)
			{
				return true;
			}
			else
			{
				MyMessage msg = new MyMessage(3);
				msg.SetObj("请打开串口!\r\n");
				ShowMessage(msg);
				return false;
			}
		}

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lvInfantList = (ListView)sender;
            Point point = lvInfantList.PointToClient(Cursor.Position);
            ListViewItem.ListViewSubItem cell = lvInfantList.HitTest(point).SubItem;
            if (cell != null)
            {
                //MessageBox.Show(cell.Text);
                tbxData.AppendText(cell.Text);
            }
        }
        private CfgAllRegsForm setAllRegsForm;
        private void BtnCfgAllReg_Click(object sender, EventArgs e)
        {
            if (setAllRegsForm == null)
            {
                setAllRegsForm = new CfgAllRegsForm();
                setAllRegsForm.messageToMainFram = cfgAllRegsFormMessage;
            }
            setAllRegsForm.Show();
            setAllRegsForm.Select();
        }

        private void CheckedListBoxCfgEn_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox listBox = (CheckedListBox)sender;
            if (listBox.CheckedItems.Count == listBox.Items.Count)
            {
                checkBoxCfgAllEn.Checked = true;
            }
            else
            {
                checkBoxCfgAllEn.Checked = false;
            }
        }

        private void CheckBoxCfgAllEn_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            for (int i = 0; i < checkedListBoxCfgEn.Items.Count; i++)
            {
                checkedListBoxCfgEn.SetItemChecked(i, checkBox.Checked);
            }
        }

        public void cfgAllRegsFormMessageHandle(FramLoad framLoad)
        {
            MyMessage msg = new MyMessage();
            msg.SetWhat(3);
            msg.SetObj("CS:" + framLoad.ChipSelect + "\r\naddr:" + framLoad.RegAddr + "\r\ndata:" + framLoad.Data + "\r\n");
            this.ShowMessage(msg);
        }
    }
}
