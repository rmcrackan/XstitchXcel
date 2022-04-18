using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XstitchXcelWinFormsLib.Panels;

namespace XstitchXcelWinFormsLib
{
	public static class ControlsExtensions
	{
		public static List<T> GetChildrenByType<T>(this Control control)
		{
			var list = new List<T>();
			getChildrenByType(control, list);
			return list;
		}
		private static void getChildrenByType<T>(Control control, List<T> list)
		{
			if (control is T toolControl)
				list.Add(toolControl);

			foreach (var c in control.Controls.Cast<Control>())
				getChildrenByType(c, list);
		}

		/// <summary>
		/// set enable for each control in form, not on Form/"this" (which would freezes the form itself in place)
		/// </summary>
		public static void EnableUI(this Control control) => setEnableOnChildrenRecursive(control, true);
		public static void DisableUI(this Control control) => setEnableOnChildrenRecursive(control, false);

		/// <summary>Recursively set enable on this control's children but not on this control itself</summary>
		private static void setEnableOnChildrenRecursive(Control control, bool enable)
		{
			foreach (var c in control.Controls.Cast<Control>())
				setEnableRecursive(c, enable);
		}

		/// <summary>Recursively set enable on this control and its children</summary>
		private static void setEnableRecursive(Control control, bool enable)
		{
			// these handle themselves. don't dig deeper
			if (control is _ToolControlsBase toolControlsBase)
			{
				toolControlsBase.SetEnable(enable);
				return;
			}

			foreach (var c in control.Controls.Cast<Control>())
				setEnableRecursive(c, enable);

			// these are containers. don't freeze them. do traverse.
			// later add these containers and their elements. eg: TabControl has TabPage elements
			// - FlowLayoutPanel
			// - GroupBox
			// - SplitContainer
			// - TableLayoutPanel
			if (control is not TabControl &&
				control is not TabPage &&
				control is not Panel &&
				control is not __ToolPaneBase)
				control.Enabled = enable;
		}
	}
}
