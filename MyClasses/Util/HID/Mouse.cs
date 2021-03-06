﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Controls;

namespace AMD.Util.HID
{
	public class MouseUtil
	{
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetCursorPos(ref Win32Point pt);

		[StructLayout(LayoutKind.Sequential)]
		internal struct Win32Point
		{
			public Int32 X;
			public Int32 Y;
		};

		public static Point GetMousePosition()
		{
			Win32Point w32Mouse = new Win32Point();
			GetCursorPos(ref w32Mouse);
			return new Point(w32Mouse.X, w32Mouse.Y);
		}

		public static bool IsOver(Control sender, String name)
		{
			return (sender.Template.FindName(name, sender) as Control).IsMouseOver;
		}

		public static bool IsOver(Control sender, Control isOver)
		{
			return IsOver(sender, isOver.Name);
		}
	}
}
