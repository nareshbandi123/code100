
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using AutomationSQLdm.Base;
using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using AutomationSQLdm.Extensions;

namespace AutomationSQLdm.Extensions
{
    
   public static class Extension
	{
   	
   		public static int sleepTime = 3000;
   		public static bool ClickThis(this Ranorex.Text item)
		{
			System.Threading.Thread.Sleep(sleepTime);
			item.Click();
			System.Threading.Thread.Sleep(sleepTime);
			return true;
		}
		
		public static bool ClickThis(this Ranorex.TabPage item)
		{
			System.Threading.Thread.Sleep(sleepTime);
			item.Click();
			System.Threading.Thread.Sleep(sleepTime);
			return true;
		}
		
		public static bool ClickThis(this Ranorex.RadioButton item)
		{
			System.Threading.Thread.Sleep(sleepTime);
			item.Click();
			System.Threading.Thread.Sleep(sleepTime);
			return true;
		}
		
		public static bool ClickThis(this Ranorex.Button item)
		{
			System.Threading.Thread.Sleep(200);
			item.Click();
			System.Threading.Thread.Sleep(200);
			return true;
		}
		
		public static bool ClickThis(this Ranorex.MenuItem item)
		{
			System.Threading.Thread.Sleep(200);
			item.Click();
			System.Threading.Thread.Sleep(200);
			return true;
		}
		
		public static bool ClickThis(this Ranorex.TreeItem item)
		{
			System.Threading.Thread.Sleep(200);
			item.Click();
			System.Threading.Thread.Sleep(200);
			return true;
		}
		
		public static bool ClickThis(this Ranorex.CheckBox item)
		{
			System.Threading.Thread.Sleep(200);
			item.Click();
			System.Threading.Thread.Sleep(200);
			return true;
		}
		
		public static bool ClickThis(this Ranorex.ListItem item)
		{
			System.Threading.Thread.Sleep(200);
			item.Click();
			System.Threading.Thread.Sleep(200);
			return true;
		}
		
		public static bool TextBoxText(this Ranorex.Text item, string value)
		{
			item.TextValue = value;
			return true;
		}
		
		public static bool ClickThis(this Ranorex.Container item)
		{
			System.Threading.Thread.Sleep(200);
			item.Click();
			System.Threading.Thread.Sleep(200);
			return true;
		}
		
		public static bool RightClick(this Ranorex.Container item)
		{
			Mouse.Click(item,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			return true;
		}
		
		public static bool RightClick(this Ranorex.TreeItem item)
		{
			Mouse.Click(item,System.Windows.Forms.MouseButtons.Right, new Point(30, 10));
			return true;
		}
		
		public static bool OpenSQLdm(this Ranorex.Host host)
		{
			Config.ProcessID = host.RunApplication(Config.AppPath, "", "", true);
			return true;
		}
		
		public static bool CloseSQLdm(this Ranorex.Host host)
		{
			host.CloseApplication(Config.ProcessID);
			return true;
		}
		
	
		public static bool WaitForItemExists(this Ranorex.Core.Repository.RepoItemInfo info, int waitDuration)
		{
			try 
			{
				info.WaitForExists(new Duration(waitDuration));
				return true;
			} 
			catch 
			{
				return false;
			}
		}
		
		public static TreeItem GetChildItem(this Ranorex.TreeItem item, string key, bool expand = true)
		{
			TreeItem childItem = null;
			try 
			{
				foreach (var child in item.Items) 
				{
					if(child.Text == key)
					{
						if(expand) child.Expand();
						childItem = child;
						break;
					}
				}
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : GetChildItem : " + ex.Message);
			}
			return childItem;
		}
		
		public static TreeItem GetChildItem(this Ranorex.Tree item, string key, bool expand = true)
		{
			TreeItem childItem = null;
			try 
			{
				foreach (var child in item.Items) 
				{
					if(child.Text == key)
					{
						if(expand) child.Expand();
						childItem = child;
						break;
					}
				}
			} 
			catch(Exception ex)
			{
				throw new Exception("Failed : GetChildItem : " + ex.Message);
			}
			return childItem;
		}
	}
}
