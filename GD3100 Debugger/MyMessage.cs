using System;
using System.Collections.Generic;
using System.Text;

namespace GD3100Debugger
{
	class MyMessage
	{
		public int what;
		public object obj;

		public MyMessage()
		{

		}
		public MyMessage(int what)
		{
			this.what = what;
		}
		public MyMessage(int what, object obj)
		{
			this.what = what;
			this.obj = obj;
		}
		public void SetObj(object obj)
		{
			this.obj = obj;
		}
		public object GetObj()
		{
			return this.obj;
		}
		public void SetWhat(int what)
		{
			this.what = what;
		}
		public int GetWhat()
		{
			return this.what;
		}
	}
}
