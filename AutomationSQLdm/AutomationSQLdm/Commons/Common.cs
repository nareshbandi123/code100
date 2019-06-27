
using System;
using AutomationSQLdm.Base;
using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using AutomationSQLdm.Extensions;
using Ranorex;
using AutomationSQLdm.TestRailAPI;

namespace AutomationSQLdm.Commons
{
   
    public static class Common 
    {
       public static CommonRepo repo = CommonRepo.Instance; 
       //public static int ApplicationOpenWaitTime = 280000;
       public static int ApplicationOpenWaitTime = 12000000;
		
		public static void DeleteFile(string filename)
        {
        	try 
        	{
	        	if(System.IO.File.Exists(filename))
	        		System.IO.File.Delete(filename);
        	} 
        	catch (Exception e)
        	{
        		throw e;
        	}
        }
		
		public static void UpdateStatus(int statusid)
		{
			try 
			{
				Rail rail = new Rail();
				string testcaseid = GetCaseID();
				if(!string.IsNullOrEmpty(testcaseid))
				{
					rail.UpdateCaseStatus(statusid, testcaseid);
				}
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : UpdateStatus : " + ex.Message);
			}
		}
		
		
		public static string GetCaseID()
		{
			try 
			{
				string testcaseid = "";
				Rail rail = new Rail();
				foreach (var testCase in rail.GetCases()) 
				{
					string suite_testcasename  = Config.TestCaseName.Replace('_', ' ');
					if(testCase.TestCaseName == suite_testcasename) 
					{
						testcaseid = testCase.TestCaseId;
						break;
					}
				}
				return testcaseid;				
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : GetCaseID : " + ex.Message);
			}
		}
		
		 public static void WaitForSync(int TimeInSeconds)
       {
       		System.Threading.Thread.Sleep(TimeInSeconds);
       }
    
		public static void RightClickOnServer(string serverName)
		{
		    try 
		    {
		    	
		    	var allServers = repo.Application.AllServers;
				Report.Info(allServers.Items.Count.ToString());
				if(allServers.Items.Count>=1)
				{
		//					allServers.Items[0].Click(System.Windows.Forms.MouseButtons.Right);
		//					Reports.ReportLog("Clicked Server ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				
		        repo.Application.AllServersInfo.WaitForItemExists(120000);
		        TreeItem serveritem = repo.Application.AllServers.GetChildItem(serverName);
		        if(serveritem != null) 
		        	serveritem.Click(System.Windows.Forms.MouseButtons.Right);
		    } 
		    catch (Exception ex) 
		    {
		        throw new Exception("Failed : ClickOnAllServers : " + ex.Message);
		    }
		}
		
		public static void ClickStartConsole()
		{
		    try 
		    {
		    	if(repo.Application.btnStartConsoleInfo.Exists())
		    	{
		    		repo.Application.btnStartConsole.ClickThis();
		    		Reports.ReportLog("Clicked Start Console button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
		    	}
		    	else
		    		Reports.ReportLog("Start Console button does not exists", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
		    	
		    } 
		    catch (Exception ex) 
		    {
		        throw new Exception("Failed : ClickOnAllServers : " + ex.Message);
		    }
		}
		
		public static void ConnectDMRepoWindowsUser()
		{
			try
			{
				if(repo.Application.CaptionText.TextValue.Contains(Config.RepositoryName))
					Reports.ReportLog("Connected to SQLdmRepository Successfully !  "   , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
				else
				{
					Reports.ReportLog("Connecting to SQLdmRepository " , Reports.SQLdmReportLevel.Info, null, Configuration.Config.TestCaseName);
					
					repo.Application.File.Click();
					Reports.ReportLog("Clicked File Menu Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					repo.SQLdmDesktopClient.ConnectToSQLDMRepository.Click();
					Reports.ReportLog("Clicked Menuitem ConnectToSQLDMRepository Successfully ! ", Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					repo.RepositoryConnectionDialog.ConnectButton.ClickThis();
					Reports.ReportLog("Clicked Connect Button Successfully !  " , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					
					if(repo.Application.btnStartConsoleInfo.Exists())
						repo.Application.btnStartConsole.ClickThis();
				
					Delay.Milliseconds(2000);
					
					if(repo.Application.CaptionText.TextValue.Contains(Config.RepositoryName))
						Reports.ReportLog("Connected to SQLdmRepository Successfully !  "   , Reports.SQLdmReportLevel.Success, null, Configuration.Config.TestCaseName);
					else
					{
						Reports.ReportLog("Failed to connect to SQLdmRepository " , Reports.SQLdmReportLevel.Fail, null, Configuration.Config.TestCaseName);
						throw new Exception("Failed to connect to SQLdmRepository.");
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception("Failed : ConnectDMRepo : " + ex.Message);
			}
		}
		
    }
}
