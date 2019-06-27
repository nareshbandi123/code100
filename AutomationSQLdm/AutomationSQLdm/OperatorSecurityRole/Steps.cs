using System;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Text;

using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using AutomationSQLdm.Extensions;
using Ranorex;
using Ranorex.Core;
using System.Threading;
using SQDLDMConstants = AutomationSQLdm.Commons.Constants; 

namespace AutomationSQLdm.OperatorSecurityRole
{
	/// <summary>
	/// Description of Steps.
	/// </summary>
	public static class Steps
	{
		public static OperatorSecurityRoleRepo repo = OperatorSecurityRoleRepo.Instance;
		public const string SNOOZEALERT_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='snoozeAllAlertsToolMenu']";
		public const string RESUMEALERT_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='resumeAllAlertsToolMenu']";
		public const string MAINTAINANCEMODE_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='MaintenanceModeButtonKey']";
		public const string UserTableRow1 = @"/form[@title~'^Idera\ SQL\ diagnostic\ mana']/statusbar[@automationid='statusBar']//container[@automationid='viewContainer']/container[@automationid='windowsFormsHostControl']//container[@controlname='_child']//container[@controlname='ApplicationSecurityView_Fill_Panel']//table[@accessiblename~'^\ \ \ \ \ \ \ System\ logins,\ whi']/row[1]";
		public static int rownum = 0;
		
		public static void SelectSnoozeAlertMenuItem()
		{ 
			try
			{
				Ranorex.MenuItem snoozeMenuItem = SNOOZEALERT_MENU;
				if(snoozeMenuItem != null) 
				{	
					snoozeMenuItem.ClickThis();
					Reports.ReportLog("Selected SnoozeAlert MenuItem", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				Reports.ReportLog("MenuItem SnoozeAlert not Selected", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectSnoozeAlertMenuItem :" + ex.Message);
			}
		}
		
		public static void ResumeAlertMenuItem()
		{ 
			try
			{
				Ranorex.MenuItem resumeAlert = RESUMEALERT_MENU;
				if(resumeAlert != null && resumeAlert.Enabled ) 
				{	
					
					resumeAlert.ClickThis();
					repo.SnoozeAlertsDialog.OkButton.ClickThis();
					Reports.ReportLog("Selected ResumeAlert MenuItem", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				Reports.ReportLog("MenuItem ResumeAlert not Selected", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ResumeAlertMenuItem :" + ex.Message);
			}
		}
		
		public static void SelectMaintainceModeMenuItem()
		{ 
			try
			{
				Ranorex.MenuItem snoozeMenuItem = MAINTAINANCEMODE_MENU;
				if(snoozeMenuItem != null) 
				{	
					snoozeMenuItem.ClickThis();
					Reports.ReportLog("Selected SelectMaintainceModeMenuItem MenuItem", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				Reports.ReportLog("MenuItem SelectMaintainceModeMenuItem not Selected", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectMaintainceModeMenuItem :" + ex.Message);
			}
		}
		
		public static void RightClickMonitoredServer()
		{ 
			try
			{
				var allServers = repo.Application.AllServers;
				repo.Application.AllServersInfo.WaitForItemExists(200000);
				Report.Info(allServers.Items.Count.ToString());
				if(allServers.Items.Count>=1)
				{
					allServers.Items[0].Click(System.Windows.Forms.MouseButtons.Right);
					Reports.ReportLog("Right Clicked First Server ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickMonitoredServer :" + ex.Message);
			}
		}
		
		public static void RightClickAllServer_MyViews()
		{ 
			try
			{
				repo.Application.MyViewsAllServersInfo.WaitForItemExists(20000);
				repo.Application.MyViewsAllServers.Click(System.Windows.Forms.MouseButtons.Right);
				Reports.ReportLog("Right Clicked All Server Under My Views ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickMonitoredServer_MyViews :" + ex.Message);
			}
		}
		
		public static void RightClickAllServer()
		{ 
			try
			{
				var allServers = repo.Application.AllServers;
				Report.Info(allServers.Items.Count.ToString());
				allServers.Click(System.Windows.Forms.MouseButtons.Right);
				Reports.ReportLog("Right Clicked All Server ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : RightClickMonitoredServer :" + ex.Message);
			}
		}
		
		public static void ClickServersInLeftPane()
		{ 
			try
			{
				repo.Application.ServersInfo.WaitForItemExists(new Duration(200000));
				repo.Application.Servers.ClickThis();
				Reports.ReportLog("Clicked Servers in Left Pane ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickServersInLeftPane :" + ex.Message);
			}
		}
		
		public static void ClickSnoozeAlertContextMenu()
		{ 
			try
			{
				repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenuInfo.WaitForItemExists(new Duration(200000));
				repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenu.ClickThis();
				Reports.ReportLog("Snooze Server Context Menu Clicked  ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickSnoozeAlertContextMenu :" + ex.Message);
			}
		}
		
		public static void ClickResumeAlertContextMenu()
		{ 
			try
			{
				repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenuInfo.WaitForItemExists(new Duration(200000));
				repo.SQLdmDesktopClient.ResumeAlerts_ContextMenu.ClickThis();
				repo.SnoozeAlertsDialog.OkButton.ClickThis();
				Reports.ReportLog("Resumed alert for Server using Context Menu. ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickResumeAlertContextMenu :" + ex.Message);
			}
		}
		
		public static void ClickMaintainceModeContextMenu()
		{ 
			try
			{
				repo.SQLdmDesktopClient.MaintenanceMode.ClickThis();
				Reports.ReportLog("Maintenance Mode Context Menu Clicked  ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickMaintainceModeContextMenu :" + ex.Message);
			}
		}
		
		public static void EnableMaintainceMode()
		{ 
			try
			{
				if(repo.SQLdmDesktopClient.DisableContextMenuItem.Enabled)
				{
					repo.SQLdmDesktopClient.DisableContextMenuItem.Click();
					Reports.ReportLog("Maintenance Mode is Disabled ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else if(repo.SQLdmDesktopClient.EnableContextMenuItem.Enabled)
				{
					repo.SQLdmDesktopClient.EnableContextMenuItem.Click();
					Reports.ReportLog("Maintenance Mode is Enabled ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Maintenance Mode is not applied", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("Maintenance Mode is not applied");
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnableMaintainceMode :" + ex.Message);
			}
		}
		
		public static void VerifyMaintainceModeIsChanged()
		{ 
			try
			{
				Thread.Sleep(10000);
				RightClickMonitoredServer();
        	    ClickMaintainceModeContextMenu();
        	    
        	    if(repo.SQLdmDesktopClient.EnableContextMenuItem.Enabled==false)
					Reports.ReportLog("Maintaince Mode Is Enabled successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
        	    else if(repo.SQLdmDesktopClient.DisableContextMenuItem.Enabled==false)
				{
					Reports.ReportLog("Maintaince Mode is Disabled successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
        	    else
        	    {
        	    	Reports.ReportLog("Maintaince Mode Not applied successfully. ", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("Maintaince Mode Not applied successfully.");
        	    }
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyMaintainceModeIsChanged :" + ex.Message);
			}
		}
		
//		public static void VerifyMaintainceModeIsChanged_MyViews()
//		{ 
//			try
//			{
//				Thread.Sleep(120000);
//				RightClickAllServer_MyViews();
//        	    ClickMaintainceModeContextMenu();
//        	    
//        	    if(repo.SQLdmDesktopClient.EnableContextMenuItem.Enabled==false)
//					Reports.ReportLog("Maintaince Mode Is Enabled successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
//        	    else if(repo.SQLdmDesktopClient.DisableContextMenuItem.Enabled==false)
//				{
//					Reports.ReportLog("Maintaince Mode is Disabled successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
//				}
//        	    else
//        	    {
//        	    	Reports.ReportLog("Maintaince Mode Not applied successfully. ", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
//					Validate.Fail("Maintaince Mode Not applied successfully.");
//        	    }
//			}
//			catch (Exception ex)
//			{
//				throw new Exception("Failed : VerifyMaintainceModeIsChanged :" + ex.Message);
//			}
//		}
		
		public static void VerifyMaintainceModeContextMenuItems()
		{ 
			try
			{	
				if(!repo.SQLdmDesktopClient.EnableContextMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				if(!repo.SQLdmDesktopClient.DisableContextMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				if(!repo.SQLdmDesktopClient.ScheduleConextMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				
					
				Reports.ReportLog("Verified Maintenance Mode Items: Enabled, Disables and Scheduled are present ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyMaintainceModeContextMenuItems :" + ex.Message);
			}
		}
		
		public static void Cell_test()
		{ 
			var cell = Host.Local.FindSingle<Ranorex.Cell>(@"/form[@title~'^Idera\ SQL\ diagnostic\ mana']/statusbar[@automationid='statusBar']//table[@accessiblename~'^\ \ \ \ \ \ \ System\ logins,\ whi']//cell[@accessiblevalue='sa1']");
            cell.DoubleClick();
		}
		
		public static void VerifyMaintainceModeMenuItems_test()
		{ 
            var menuitems = Host.Local.Find<Ranorex.MenuItem>("/contextmenu[@win32ownerwindowlevel='2']/menuitem");
          
			if (menuitems != null) {
				foreach (var mitem in menuitems)  
			    {
					//if(mitem.Text.Equals(""))
			        Report.Info(mitem.Text + mitem.Enabled);           
			    }    
				Report.Info(menuitems.Count.ToString());
			}
			
		}
		
		public static void VerifyMaintainceModeMenuItems()
		{ 
			try
			{	
				if(!repo.SQLdmDesktopClient.MaintenanceModeEnableMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				if(!repo.SQLdmDesktopClient.MaintenanceModeDisableMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				if(!repo.SQLdmDesktopClient.MaintenanceModeScheduleMenuItemInfo.Exists())
				{
					Reports.ReportLog("No Server Found. Please Add Server.", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("No Server Found. Please Add Server.");
				}
				
					
				Reports.ReportLog("Verified Maintenance Mode Items: Enabled, Disables and Scheduled are present ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyMaintainceModeContextMenuItems :" + ex.Message);
			}
		}
		
		public static void VerifyServerSnoozed()
		{ 
			try
			{
				RightClickMonitoredServer();
				
				if(!repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenu.Enabled) 
					Reports.ReportLog("SnoozeAlert is applied successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
				{
					Reports.ReportLog("SnoozeAlert Not applied successfully. ", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("SnoozeAlert Not applied successfully.");
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyServerSnoozed :" + ex.Message);
			}
		}
		
		
		public static void VerifyAllServerSnoozed(string AllServerOrTag)
		{ 
			try
			{
				if(AllServerOrTag.Equals(SQDLDMConstants.allServer))
					RightClickAllServer();
				else if(AllServerOrTag.Equals(SQDLDMConstants.tagSnoozeAlert))
					RightClickTag();
				
				if(!repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenu.Enabled) 
					Reports.ReportLog("SnoozeAlert is applied successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
				{
					Reports.ReportLog("SnoozeAlert Not applied successfully. ", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("SnoozeAlert Not applied successfully.");
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyServerSnoozed :" + ex.Message);
			}
		}
		
		public static void VerifyServerSnoozed_MyViews()
		{ 
			try
			{
				RightClickAllServer_MyViews();
				
				if(!repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenu.Enabled) 
					Reports.ReportLog("SnoozeAlert is applied successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
				{
					Reports.ReportLog("SnoozeAlert Not applied successfully. ", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Validate.Fail("SnoozeAlert Not applied successfully.");
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyServerSnoozed :" + ex.Message);
			}
		}
		
		public static void SetSnoozeAlertTime()
		{ 
			try
			{
				repo.SnoozeAlertsDialog.SnooozeAlertTime.TextValue = "10";
				repo.SnoozeAlertsDialog.OkButton.Focus();
				repo.SnoozeAlertsDialog.OkButton.ClickThis();
				Reports.ReportLog("SnoozeAlert Time applied successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SetSnoozeAlertTime :" + ex.Message);
			}
		}
		
		public static void VerifySnoozeAlertApplied()
		{ 
			try
			{
				Ranorex.MenuItem snoozeMenuItem = SNOOZEALERT_MENU;
				Report.Info(snoozeMenuItem.Enabled.ToString());
				if(!snoozeMenuItem.Enabled) 
					Reports.ReportLog("SnoozeAlert is applied successfully ! ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
				{
					Reports.ReportLog("SnoozeAlert Not applied successfully. ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					Validate.Fail("SnoozeAlert Not applied successfully.");
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifySnoozeAlertApplied :" + ex.Message);
			}
		}
		
		public static void ClickAdministration()
		{
			try
			{
				repo.Application.btnAdministrationInfo.WaitForExists(new Duration(200000));
				repo.Application.btnAdministration.ClickThis();
				//repo.Application.btnAdministration.Press();
				Reports.ReportLog("Clicked Administration button", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickAdministration : " + ex.Message);
			}
		}
		
		public static void ClickApplicationSecurity()
		{
			try
			{
				repo.Application.ApplicationSecurityInfo.WaitForExists(new Duration(200000));
				repo.Application.ApplicationSecurity.Click();
				Reports.ReportLog("Clicked Application Security", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickApplicationSecurity : " + ex.Message);
			}
		}
		
		public static void ClickEnableSecurity()
		{
			try
			{
				//repo.Application.EnableSecurityInfo.WaitForExists(new Duration(100000));
				if(repo.Application.EnableSecurityInfo.Exists())
				{
					repo.Application.EnableSecurity.ClickThis();
					Reports.ReportLog("Clicked Enabled Security", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
					Reports.ReportLog("Enabled Security link not exists", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickEnableSecurity : " + ex.Message);
			}
		}

		public static void AcceptExceptionMessage()
		{
			try
			{
				if(repo.ExceptionForm.SelfInfo.Exists())
				{
					repo.ExceptionForm.btnYes.ClickThis();
					Reports.ReportLog("Clicked Yes button on Exception Alert", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
					Reports.ReportLog("Exception Message popup does not exists", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : AcceptExceptionMessage : " + ex.Message);
			}
		}
		
		public static void ClickToAddUsers()
		{
			try
			{   if(repo.Application.btnAddUsersInfo.Exists())
				{
					repo.Application.btnAddUsers.ClickThis();
					Reports.ReportLog("Clicked Add Users", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					ClickEnableSecurity();
        	  		AcceptExceptionMessage();
        	  		repo.Application.btnAddUsers.ClickThis();
					Reports.ReportLog("Clicked Add Users", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickToAddUsers : " + ex.Message);
			}
		}
		
		public static void ClickNextButton()
		{
			try
			{
				//repo.AddPermissionWizard.btnNextInfo.WaitForExists(new Duration(500));				
				repo.AddPermissionWizard.btnNext.ClickThis();
				Reports.ReportLog("Clicked Next Button", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickNextButton : " + ex.Message);
			}
		}
	
		public static void EnterDomianUserName(string domainUserName)
		{
			try
			{
				repo.AddPermissionWizard.txtUserNameInfo.WaitForItemExists(new Duration(200000));				
				repo.AddPermissionWizard.txtUserName.PressKeys(domainUserName);
				Reports.ReportLog("Entered DomianUserName", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EnterDomianUserName : " + ex.Message);
			}
		}
		
		public static void SelectSqlAuthentication()
		{
			try
			{
				repo.AddPermissionWizard.ComboBoxUserPageCmbBxAuthenticationInfo.WaitForItemExists(new Duration(200000));				
				Ranorex.ComboBox combobox = repo.AddPermissionWizard.ComboBoxUserPageCmbBxAuthentication;
				combobox.Click();
				ListItem lst_userItem = combobox.FindSingle<ListItem>("/list/listitem[@text='SQL Server Authentication']");
				lst_userItem.Focus();  
				lst_userItem.Click(); 
				Reports.ReportLog("SQL Server Authentication Selected ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectAuthenticationType : " + ex.Message);
			}
		}
		
		public static void ClickOptionBtn_ViewDataAcknowledgwAlarm()
		{
			try
			{
				repo.AddPermissionWizard.ViewDataAcknowledgwAlarmInfo.WaitForItemExists(new Duration(200000));
				repo.AddPermissionWizard.ViewDataAcknowledgwAlarm.Click();
				Reports.ReportLog("Selected Option ViewDataAcknowledgwAlarm ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickOptionBtn_ViewDataAcknowledgwAlarm : " + ex.Message);
			}
		}
		
		public static void SelectServers()
		{
			try
			{
				Ranorex.List serversLists= null;
				if(repo.AddPermissionWizard.AvailableServersInfo.Exists())
				{
					serversLists = repo.AddPermissionWizard.AvailableServers;
					int itemCount = serversLists.Children.Count;
					Report.Info("Servers Count ="+ itemCount.ToString());
					if(itemCount >= 2)
					{
						//Report.Info("serversLists.Items[0]: " + serversLists.Items[0]);
						//serversLists.Children[0].Click();
						serversLists.Items[0].Click();
						Thread.Sleep(2000);
						serversLists.Items[0].PressKeys("{LControlKey down}{LShiftKey down}");
						Thread.Sleep(2000);
						//serversLists.Items[itemCount/2+1].EnsureVisible();
						serversLists.Items[itemCount/2+1].Click();
						serversLists.Items[itemCount/2+1].PressKeys("{LControlKey up}{LShiftKey up}");
						Reports.ReportLog("Selected Server", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					else if(itemCount == 1)
					{
						serversLists.Items[0].Click();
						Reports.ReportLog("Selected Server", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					}
					else
					{
						//Reports.ReportLog("No Servers Available in Server List", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
						Validate.Fail("No Servers Available in Server List");
					}
				}
				else
				{
					//Reports.ReportLog("Available Server Dialog not exists : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					Validate.Fail("Available Server Dialog not exists");
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : SelectServers : " + ex.Message);
			}
		}
		
		public static void ClickAddButton()
		{
			try
			{
				//repo.AddPermissionWizard.ViewDataAcknowledgwAlarmInfo.WaitForExists(new Duration(500));
				repo.AddPermissionWizard.ButtonAdd.Click();
				Reports.ReportLog("Clicked Add button to Add Server", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickAddButton : " + ex.Message);
			}
		}
		
		public static void ClickFinishButton()
		{
			try
			{
				//repo.AddPermissionWizard.ViewDataAcknowledgwAlarmInfo.WaitForExists(new Duration(500));
				repo.AddPermissionWizard.ButtonFinish.Click();
				Reports.ReportLog("Clicked Finish Button", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickFinishButton : " + ex.Message);
			}
		}
		
		public static void VerifyWindowsUserAdded()
		{
			try
			{
				repo.Application.TableSystemLoginsWhichBelongInfo.WaitForItemExists(200000);
				
				Ranorex.Cell cellUser= null;
				cellUser = repo.Application.TableSystemLoginsWhichBelong.FindSingle("//cell[@accessiblevalue='"+ Config.NewWindowsUser +"']");
				
				if(cellUser.GetAttributeValue<string>("accessiblevalue").ToLower().Equals(Config.NewWindowsUser.ToLower()))
				{
					Reports.ReportLog("New Windows User Added Successfully ! " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("New Windows User not Added : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					Validate.Fail("New Windows User not Added Successfully");
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyWindowsUserAdded : " + ex.Message);
			}
		}
		
		public static void VerifyUserAdded(string userType)
		{
			try
			{
				string user = null;
				if(userType.ToLower().Equals(Config.NewSqlUser.ToLower()))
					user = Config.NewSqlUser;
				else
					user = Config.NewWindowsUser;
				
				repo.Application.TableSystemLoginsWhichBelongInfo.WaitForItemExists(200000);
				//Ranorex.Cell cellUser = repo.Application.TableSystemLoginsWhichBelong.FindSingle("/row[1]/cell[@accessiblevalue='"+ user +"']");
				//Ranorex.Cell cellUser = Host.Local.FindSingle<Ranorex.Cell>(@"/form[@title~'^Idera\ SQL\ diagnostic\ mana']/statusbar[@automationid='statusBar']//container[@automationid='viewContainer']/container[@automationid='windowsFormsHostControl']//container[@controlname='_child']//container[@controlname='ApplicationSecurityView_Fill_Panel']//table[@accessiblename~'^\ \ \ \ \ \ \ System\ logins,\ whi']/row[1]/cell[@accessiblevalue='"+ user +"']");
				Ranorex.Cell cellUser = Host.Local.FindSingle<Ranorex.Cell>(UserTableRow1 + "/cell[@accessiblevalue='"+ user +"']");
				if(cellUser.Text.ToLower().Equals(user.ToLower()))
				{
					cellUser.Click();
					Reports.ReportLog("New User "+ user +" Added Successfully ! " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("New User "+ user +" is not Added Successfully", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					Validate.Fail("New User  "+ user +" is not Added Successfully");
				}
			
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyUserAdded : " + ex.Message);
			}
		}
		
		public static void VerifySqlUserAdded()
		{
			try
			{
				repo.Application.TableSystemLoginsWhichBelongInfo.WaitForItemExists(200000);
				
				Ranorex.Cell cellUser= null;
				cellUser = repo.Application.TableSystemLoginsWhichBelong.FindSingle("//cell[@accessiblevalue='"+ Config.NewSqlUser +"']");
				
				//Report.Info(cellUser.Visible.ToString() + cellUser.Enabled.ToString()+ cellUser.Text.ToString());
				//if(repo.Application.NewSqlUserAddedInfo.Exists())
				if(cellUser.GetAttributeValue<string>("accessiblevalue").ToLower().Equals(Config.NewSqlUser.ToLower()))
				{
					Reports.ReportLog("New Sql User Added Successfully ! " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("New Sql User not Added : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					Validate.Fail("New Sql User not Added Successfully");
				}
			
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifySqlUserAdded : " + ex.Message);
			}
		}

		public static void EditUserInUserTable(string userType)
		{
			try
			{
				Ranorex.Cell cellUser= null;
				if (userType.ToLower() == "sqluser")
					cellUser = repo.Application.TableSystemLoginsWhichBelong.FindSingle("//cell[@accessiblevalue='"+ Config.NewSqlUser +"']");
				else
					cellUser = repo.Application.TableSystemLoginsWhichBelong.FindSingle("//cell[@accessiblevalue='"+ Config.NewWindowsUser +"']");
				cellUser.MoveTo();
				//Thread.Sleep(2000);
				cellUser.Click();
				//Thread.Sleep(2000);
				cellUser.DoubleClick();
				Reports.ReportLog("Opened User in Edit mode Successfully ! " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : EditUserInUserTable : " + ex.Message);
			}
		}
		
		public static void ChangePermission(string userType)
		{
			try
			{
				EditUserInUserTable(userType);
				repo.PermissionPropertyDialog.RadioButtonGeneralRdBtnAdministrator.MoveTo();
				repo.PermissionPropertyDialog.RadioButtonGeneralRdBtnAdministrator.Click();
				repo.PermissionPropertyDialog.ButtonBtnOK.MoveTo();
				repo.PermissionPropertyDialog.ButtonBtnOK.ClickThis();
				Reports.ReportLog("Permission Changed to Administrator Powers in Sql DM" , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ChangePermission : " + ex.Message);
			}
		}
		
		public static void VerifyPermissionChanged()
		{
			bool IsFound = false;
			try
			{
				var tableSystemLoginsWhichBelong = repo.Application.TableSystemLoginsWhichBelong;
				foreach(var row in tableSystemLoginsWhichBelong.Rows)
				{
					if(row.Cells[3].Text.ToLower().Equals(Config.NewSqlUser.ToLower()))
					{
						if(row.Cells[5].Text.ToLower().Equals(SQDLDMConstants.strAdministrator.ToLower()))
						{
							IsFound = true;
							break;
						}
					}
				}
				if(IsFound)
					Reports.ReportLog("Permission Changed to Administrator Powers in Sql DM " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				else
					Validate.Fail("Permission Not Changed to Administrator Powers in Sql DM");
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ChangePermission : " + ex.Message);
			}
		}
		
//		public static void VerifyPermissionChanged()
//		{
//			try
//			{
//				
//				repo.PermissionPropertiesSIMPSONSAdminis.AdministratorPowersInSQLDiagnosticM.Click();
//				repo.PermissionPropertiesSIMPSONSAdminis.ButtonOK.ClickThis();
//				Reports.ReportLog("Permission Changed to 'Administrator Powers in Sql DM' " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//			}
//			catch(Exception ex)
//			{
//				throw new Exception("Failed : ChangePermission : " + ex.Message);
//			}
//		}
		
		
			
		public static void VerifyViewDataAcknowledgwAlarmIsSelected(string userType)
		{
			try
			{
				string user = null;
				if(userType.ToLower().Equals(SQDLDMConstants.WindowsUser.ToLower()))
					user = Config.NewWindowsUser;
				else
					user = Config.NewSqlUser;
				
				repo.Application.TableSystemLoginsWhichBelongInfo.WaitForItemExists(200000);
				Ranorex.Cell cellUser = Host.Local.FindSingle<Ranorex.Cell>(UserTableRow1 + "/cell[@accessiblevalue='"+ user +"']");
				cellUser.DoubleClick();
				
				if(repo.PermissionPropertyDialog.ViewDataAcknowledgwAlarm.Checked)
				{
					Reports.ReportLog("ViewDataAcknowledgwAlarm Option is Selected " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("ViewDataAcknowledgwAlarm Option Not Selected : ", Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					Validate.Fail("ViewDataAcknowledgwAlarm Option Not Selected");
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : VerifyViewDataAcknowledgwAlarmIsSelected : " + ex.Message);
			}
		}
		
		public static void ClickCancelPermissionProperties()
		{
			try
			{
				repo.PermissionPropertyDialog.btnCancel.ClickThis();
				Reports.ReportLog("Clicked Cancel Permission Properties " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickCancelPermissionProperties : " + ex.Message);
			}
		}
		
		public static void ClickWindowsUserToDelete()
		{
			try
			{
				repo.Application.NewWindowsUserAdded.Click();
				Reports.ReportLog("Clicked New WindowsUser Added " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickWindowsUserAdded : " + ex.Message);
			}
		}
		
		public static void ClickSqlUserToDelete()
		{
			try
			{
				repo.Application.NewSqlUserAddedInfo.WaitForItemExists(200000);
				repo.Application.NewSqlUserAdded.Click();
				Reports.ReportLog("Clicked New SqlUser Added " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ClickSqlUserAdded : " + ex.Message);
			}
		}
		
		public static void DeleteAddedUser()
		{
			try
			{
				repo.Application.btnDeleteInfo.WaitForItemExists(200000);
				repo.Application.btnDelete.Click();
				repo.ExceptionForm.btnYes.Click();
				Reports.ReportLog("New User Deleted Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : DeleteAddedUser : " + ex.Message);
			}
		}
		
//		public static void ConnectDMRepo()
//		{
//			try
//			{
//				repo.Application.File.Click();
//				Reports.ReportLog("Clicked File Menu Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//				repo.SQLdmDesktopClient.ConnectToSQLDMRepository.Click();
//				Reports.ReportLog("Clicked Menuitem ConnectToSQLDMRepository Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//				Ranorex.ComboBox combobox = repo.RepositoryConnectionDialog.AuthenticationDropDownList;
//				combobox.Click();
//				ListItem lst_userItem = combobox.FindSingle<ListItem>("/list/listitem[@text='SQL Server Authentication']");
//				lst_userItem.Focus();  
//				lst_userItem.Click(); 
//				Reports.ReportLog("SQL Server Authentication Selected ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//				repo.RepositoryConnectionDialog.Username.PressKeys(Constants.SqlSystemUser);
//				Reports.ReportLog("Username : " + Config.NewSqlUser + "Entered Successfully  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//				
//				repo.RepositoryConnectionDialog.Password.PressKeys(Constants.SqlSystemUserPassword);
//				Reports.ReportLog("Passsword Entered Successfully  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//				repo.RepositoryConnectionDialog.ConnectButton.ClickThis();
//				Reports.ReportLog("Clicked Connect Button Successfully !  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//				
//				if(repo.Application.CaptionText.TextValue.Contains(Config.RepositoryName))
//					Reports.ReportLog("Connected to SQLdmRepository Successfully !  "   , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
//				else
//				{
//					Reports.ReportLog("Failed to connect to SQLdmRepository " , Reports.SQLdmReportLevel.Fail, null, Configuration.Config.TestCaseName);
//					throw new Exception("Failed to connect to SQLdmRepository ");
//				}
//			}
//			catch(Exception ex)
//			{
//				throw new Exception("Failed : ConnectDMRepo : " + ex.Message);
//			}
//		}
		
		public static void ConnectDMRepo(string userType)
		{
			try
			{
				repo.Application.File.Click();
				Reports.ReportLog("Clicked File Menu Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				repo.SQLdmDesktopClient.ConnectToSQLDMRepository.Click();
				Reports.ReportLog("Clicked Menuitem ConnectToSQLDMRepository Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				if(userType.Equals(SQDLDMConstants.SqlUser))
				{
					Ranorex.ComboBox combobox = repo.RepositoryConnectionDialog.AuthenticationDropDownList;
					combobox.Click();
					ListItem lst_userItem = combobox.FindSingle<ListItem>("/list/listitem[@text='SQL Server Authentication']");
					lst_userItem.Focus();  
					lst_userItem.Click(); 
					Reports.ReportLog("SQL Server Authentication Selected ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					repo.RepositoryConnectionDialog.Username.PressKeys(Config.NewSqlUser);
					Reports.ReportLog("Username : " + Config.NewSqlUser + "Entered Successfully  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					
					repo.RepositoryConnectionDialog.Password.PressKeys(Config.NewSqlUserPassword);
					Reports.ReportLog("Passsword Entered Successfully  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
				{
					Ranorex.ComboBox combobox = repo.RepositoryConnectionDialog.AuthenticationDropDownList;
					combobox.Click();
					ListItem lst_userItem = combobox.FindSingle<ListItem>("/list/listitem[@text='Windows Authentication']");
					lst_userItem.Focus();  
					lst_userItem.Click(); 
					Reports.ReportLog("Windows Authentication Selected ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
								
				repo.RepositoryConnectionDialog.ConnectButton.ClickThis();
				Reports.ReportLog("Clicked Connect Button Successfully !  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				
				if(repo.Application.CaptionText.TextValue.Contains(Config.RepositoryName))
					Reports.ReportLog("Connected to SQLdmRepository Successfully !  "   , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				else
				{
					Reports.ReportLog("Failed to connect to SQLdmRepository " , Reports.SQLdmReportLevel.Fail, null, Configuration.Config.TestCaseName);
					throw new Exception("Failed to connect to SQLdmRepository ");
				}
				Thread.Sleep(30000);
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ConnectDMRepo : " + ex.Message);
			}
		}
		
		public static void ClickCntextMenuItem(string textValue)
		{ 
			try
			{	
				//var sQLdmDesktopClient = repo.SQLdmDesktopClient;
				//bool isFound = false;
				repo.SQLdmDesktopClient.SelfInfo.WaitForItemExists(2000);
				//repo.SQLdmDesktopClient.MaintenanceModeInfo.WaitForItemExists(2000);
				Ranorex.ContextMenu contextMenuItems = @".//contextmenu[@processname='SQLdmDesktopClient']";
				if(contextMenuItems != null)
				{
					
				}
				
//				Report.Info(contextMenuItems.Children.Count.ToString());
//				Report.Info(contextMenuItems.Children[0].ToString());
//				Ranorex.MenuItem mi = null;
//				//Report.Info(contextMenuItems.Checked.Count.ToString());
//				//repo.SQLdmDesktopClient.SnoozeAlerts_ContextMenu.ClickThis();
//				foreach(Ranorex.Adapter item in contextMenuItems.Children)
//				{
//					
//   Ranorex.Separator sep = item.As<Ranorex.Separator>();  
//    if (sep != null)  
//        Report.Info("Seperator!");  
//    
//					mi = item.As<Ranorex.MenuItem>();
//					 
//					if(mi.Text.Contains(textValue))
//					{
//						isFound = true; break;
//					}
//				}
//				
//				if(isFound)
//				{
//					mi.ClickThis();
//					Reports.ReportLog("Context Menu '" +  textValue + "' Clicked ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
//				}
//				else
//					Reports.ReportLog("Context Menu '" +  textValue + "' does not exists ", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
//				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SnoozeServer :" + ex.Message);
			}
		}
		
		public static void RightClickTag()
		{
			try
			{
				if(!repo.Application.TagSnoozeAlertInfo.Exists())
				{
					repo.Application.Tags.Click();
					repo.ManageTagsDialog.AddButton.ClickThis();
					repo.TagPropertiesDialog.TagName.TextValue = SQDLDMConstants.tagSnoozeAlert;
					repo.TagPropertiesDialog.SelectAllServersCheckBox.Checked = true;
					repo.TagPropertiesDialog.OkButton.ClickThis();
					repo.ManageTagsDialog.DoneButton.ClickThis();
					Reports.ReportLog("TagSnoozeAlert Created Successfully. "   , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				
				if(repo.Application.TagSnoozeAlertInfo.Exists())
				{
					repo.Application.TagSnoozeAlert.Click(System.Windows.Forms.MouseButtons.Right);
					Reports.ReportLog("Right Clicked on TagSnoozeAlert.", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				}
				else
					Validate.Fail("Right Click Failed on TagSnoozeAlert.");

			}
			catch(Exception ex)
			{
				throw new Exception("Failed : CreateTag : " + ex.Message);
			}
		}
		
	}
}
