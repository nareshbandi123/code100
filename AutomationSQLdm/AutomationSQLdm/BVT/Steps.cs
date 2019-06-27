
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
using Ranorex.Core.Repository;

using AutomationSQLdm.Commons;
using AutomationSQLdm.Extensions;
using AutomationSQLdm.Configuration;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using AutomationSQLdm.DataBaseOperations;


namespace AutomationSQLdm.BVT
{
    
    [TestModule("E7D37F6D-5226-40D4-9599-A4CAAFF6A2A5", ModuleType.UserCode, 1)]
    public static class Steps 
    {
    	//Object for Shared Repo
    	public static BVTRepo repo = BVTRepo.Instance;
    	
    	//Handling Sync Wait
    	public static int MinSyncWaitTime = 180000;
    	public static int MidSyncWaitTime = 240000;    		
		public static int MaxSyncWaitTime = 300000;    		
    		
    	public const string AlertActionsandResponses_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='menuToolsAlertActions']";
    	public static string ProviderName="SMTPProvider";
    	public static string ProviderAddress="SMTPProviderAddress";
    	public static string ProviderUserName="SMTPProviderName";
    	public static string ProviderPassword="SMTPProvider";
    	public static string ProviderEmail="SMTPProvider@gmail.com";
    	public static string ProviderEditName="NewSMTPProvider";
    	public static string SMTPToAddress="SMTPResponse@gmail.com";
    	public static string ResponseName ="ResponseName";
    	public static string EditResponseName ="NewResponseName";
    	public static string CopyResponseName ="ResponseName(Copy)";
    	//public static string SQLUserName="sa";
    	//public static string SQLPassword="control*88";	
    	//TestUserCreation
//TestUser@1234
    	public static string SQLUserName="TestSQLAuth";
    	public static string SQLPassword="Test@123";
    	
    	public static void VerifySQLdmToday()
			{
				try 
				{
					
				    repo.Application.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.Application.SQLdmPaneInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.Application.SQLdmPane.TextValue == "SQLDM Today")
						Reports.ReportLog("SQLdm Today pane is Displaying", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("SQLdm Today pane is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifySQLdmToday :" + ex.Message);
				}
			}
    	
    	public static void SelectRequiredServer(string serverName)
			{
				try 
				{
					 //repo.Application.AllServersInfo.WaitForItemExists(120000);
					 repo.Application.AllServersInfo.WaitForItemExists(MidSyncWaitTime);
					 TreeItem serveritem = repo.Application.AllServers.GetChildItem(serverName);
					 
					if(serveritem != null)
					{
						serveritem.ClickThis();
						repo.SQLdm.tabQueriesInfo.WaitForItemExists(MidSyncWaitTime);
						Reports.ReportLog("Successfully Selected Default Server : " + serverName, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Default Server is Not Available to Select", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
						
					}
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : SelectRequiredServer :" + ex.Message);
				}
			}
    	

    	public static void VerifyDashboardView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.btnDBCPUInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.SQLdm.btnDBCPU.Text == "CPU")
						Reports.ReportLog("Dashboard View Is Displaying", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Dashboard View Is Not Displaying", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyDashboardView :" + ex.Message);
				}
			}
    	
    	public static void VerifyAllInDashboardView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.btnDBCPUInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
				    //Verify CPU Pane is Displaying in Dashboard View
				    if (repo.SQLdm.ServerInfo.btnDABCPUInfo.Exists())
				    {
				    	Reports.ReportLog("CPU Pane is Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    else
				    {
				    	Reports.ReportLog("CPU Pane is Not Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    
				    //Verify ServerWaits Pane is Displaying in Dashboard View
				    if (repo.SQLdm.ServerInfo.btnDABServerWaitsInfo.Exists())
				    {
				    	Reports.ReportLog("ServerWaits Pane is Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    else
				    {
				    	Reports.ReportLog("ServerWaits Pane is Not Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    
				    //Verify Memory Pane is Displaying in Dashboard View
				    if (repo.SQLdm.ServerInfo.btnDABMemoryInfo.Exists())
				    {
				    	Reports.ReportLog("Memory Pane is Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    else
				    {
				    	Reports.ReportLog("Memory Pane is Not Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    
				     //Verify Cache Pane is Displaying in Dashboard View
				    if (repo.SQLdm.ServerInfo.btnDABCacheInfo.Exists())
				    {
				    	Reports.ReportLog("Cache Pane is Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    else
				    {
				    	Reports.ReportLog("Cache Pane is Not Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    
				     //Verify Network Pane is Displaying in Dashboard View
				    if (repo.SQLdm.ServerInfo.btnDABNetworkInfo.Exists())
				    {
				    	Reports.ReportLog("Network Pane is Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    else
				    {
				    	Reports.ReportLog("Network Pane is Not Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    
				    //Verify Sessions Pane is Displaying in Dashboard View
				    if (repo.SQLdm.ServerInfo.btnDABSessionsInfo.Exists())
				    {
				    	Reports.ReportLog("Sessions Pane is Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    else
				    {
				    	Reports.ReportLog("Sessions Pane is Not Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    
				     //Verify Disk Pane is Displaying in Dashboard View
				    if (repo.SQLdm.ServerInfo.btnDABDiskInfo.Exists())
				    {
				    	Reports.ReportLog("Disk Pane is Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    else
				    {
				    	Reports.ReportLog("Disk Pane is Not Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    
				     //Verify Databases Pane is Displaying in Dashboard View
				    if (repo.SQLdm.ServerInfo.btnDABDatabasesInfo.Exists())
				    {
				    	Reports.ReportLog("Databases Pane is Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    else
				    {
				    	Reports.ReportLog("Databases Pane is Not Displaying in Dashboard View", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    
					if (repo.SQLdm.btnDBCPU.Text == "CPU")
						Reports.ReportLog("Dashboard View Is Displaying", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Dashboard View Is Not Displaying", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyAllInDashboardView :" + ex.Message);
				}
			}
    	
        public static void ClickOnSessions()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtSessionsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtSessions.Click();
					Reports.ReportLog("Successfully Clicked On Sessions", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnSessions :" + ex.Message);
				}
			}
        
        public static void ClickOnDetails()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.radioDetailsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.radioDetails.Click();
					Reports.ReportLog("Successfully Clicked On Details", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnDetails :" + ex.Message);
				}
			}
        public static void ClickOnLocks()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.radioLocksInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.radioLocks.Click();
					Reports.ReportLog("Successfully Clicked On Locks", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnLocks :" + ex.Message);
				}
			}
         public static void ClickOnBlocking()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.radioBlocksInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.radioBlocks.Click();
					Reports.ReportLog("Successfully Clicked On Blocking", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnBlocking :" + ex.Message);
				}
			}
         public static void VerifySummaryUnderSessions()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtSUMResponseTimeInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.SQLdm.txtSUMResponseTime.TextValue == "Response Time")
					{
						Reports.ReportLog("Summary View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Summary View Under Sessions Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifySummaryUnderSessions :" + ex.Message);
				}
			}
         
         public static void VerifyAllInSummaryUnderSessions()
			{
				try 
				{
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
				    //Verify Response TIme in Summary
					if (repo.SQLdm.txtSUMResponseTimeInfo.Exists())
					{
						Reports.ReportLog("Response Time in Summary View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Response Time in Summary View Under Sessions Is Not Showing", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
					
					//Verify Sessions in Summary
					if (repo.SQLdm.txtSessionsInfo.Exists())
					{
						Reports.ReportLog("Sessions in Summary View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Sessions in Summary View Under Sessions Is Not Showing", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
					
					//Verify LockStatisticsRequests in Summary
					if (repo.SQLdm.ddlSESUMLockStatisticsRequestsInfo.Exists())
					{
						Reports.ReportLog("Lock Statistics Requests in Summary View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Lock Statistics Requests in Summary View Under Sessions Is Not Showing", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
					
					//Verify BlockedSessions in Summary
					if (repo.SQLdm.txtSESUMBlockedSessionsInfo.Exists())
					{
						Reports.ReportLog("Blocked Sessions in Summary View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Blocked Sessions in Summary View Under Sessions Is Not Showing", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyAllInSummaryUnderSessions :" + ex.Message);
				}
			}
        
        public static void VerifyDetailsViewUnderSessions()
			{
				try 
				{
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtDEDetailsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.SQLdm.txtDEDetails.TextValue == "Details")
					{
						Reports.ReportLog("Details View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Details View Under Sessions Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
					
					if (repo.SQLdm.tblSEDetailsInfo.Exists())
					{
						Reports.ReportLog("No Of Records Present in Details Is:" + repo.SQLdm.tblSEDetails.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("There is No Records Present in Details Is:", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					}
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyDetailsViewUnderSessions :" + ex.Message);
				}
			}
        
         public static void VerifyLocksUnderSessions()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ddlLOLockStatisticsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.SQLdm.ddlLOLockStatistics.Visible == true)
						
						Reports.ReportLog("Locks Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Locks Under Sessions Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyLocksUnderSessions :" + ex.Message);
				}
			}
        public static void VerifyBlockingUnderSessions()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtBLBlockReportsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.SQLdm.txtBLBlockReports.TextValue == "Block Reports")
						
						Reports.ReportLog("Block Reports Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Block Reports Under Sessions Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyBlockingUnderSessions :" + ex.Message);
				}
			}
        
         public static void ClickOnDetailsInOverView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.OverViewTab.rgOVDetailsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.OverViewTab.rgOVDetails.Click();
				    Reports.ReportLog("Successfully Clicked On Details in OverView", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnDetailsInOverView :" + ex.Message);
				}
			}
         
          public static void ClickOnConfigurationInOverView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.OverViewTab.rgOVConfigurationInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.OverViewTab.rgOVConfiguration.Click();
				    Reports.ReportLog("Successfully Clicked On Configuration in OverView", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnConfigurationInOverView :" + ex.Message);
				}
			}
          
          public static void ClickOnActiveAlertsInOverView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.OverViewTab.rgOVActiveAlertsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.OverViewTab.rgOVActiveAlerts.Click();
				    Reports.ReportLog("Successfully Clicked On Active Alerts in OverView", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnActiveAlertsInOverView :" + ex.Message);
				}
			}
          
          
           public static void ClickOnTimeLineInOverView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.OverViewTab.rgOVTimeLineInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.OverViewTab.rgOVTimeLine.Click();
				    Reports.ReportLog("Successfully Clicked On TimeLine in OverView", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnTimeLineInOverView :" + ex.Message);
				}
			}
           
           public static void ClickOnQueriesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabQueriesInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabQueries.Click();
				    Reports.ReportLog("Successfully Clicked On Queries Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnQueriesTab :" + ex.Message);
				}
			}
          
            public static void ClickOnDataBasesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabDatabasesInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabDatabases.Click();
				    Reports.ReportLog("Successfully Clicked On DataBases Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);	
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnDataBasesTab :" + ex.Message);
				}
			}
           public static void ClickOnSignatureMode()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.QueriesTab.rgQUESignatureModeInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.QueriesTab.rgQUESignatureMode.Click();
				    Reports.ReportLog("Successfully Clicked On Signature Mode in Queries", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnSignatureMode :" + ex.Message);
				}
			}
           
            public static void ClickOnStatementMode()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.QueriesTab.rgQUEStatementModeInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.QueriesTab.rgQUEStatementMode.Click();
				    Reports.ReportLog("Successfully Clicked On Statement Mode in Queries", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnStatementMode :" + ex.Message);
				}
			}
           
           public static void ClickOnQueryHistory()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.QueriesTab.rgQUEQueryHistoryInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.QueriesTab.rgQUEQueryHistory.Click();
				    Reports.ReportLog("Successfully Clicked On Query History in Queries", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnQueryHistory :" + ex.Message);
				}
			}
          
           public static void ClickOnQueryWaits()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.QueriesTab.rgQUEQueryWaitsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.QueriesTab.rgQUEQueryWaits.Click();
				    Reports.ReportLog("Successfully Clicked On Query Waits in Queries", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnQueryWaits :" + ex.Message);
				}
			}
          
            public static void ClickOnMirroringInDB()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBMirroringInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBMirroring.Click();
				    Reports.ReportLog("Successfully Clicked On Mirroring in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnMirroringInDB :" + ex.Message);
				}
			}
            
             public static void ClickOnTablesAndIndexesInDB()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBTablesAndIndexesInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBTablesAndIndexes.Click();
				    Reports.ReportLog("Successfully Clicked On TablesAndIndexes in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnTablesAndIndexesInDB :" + ex.Message);
				}
			}
             
              public static void ClickOnBackupsAndRestoresInDB()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBBackupsAndRestoresInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBBackupsAndRestores.Click();
				    Reports.ReportLog("Successfully Clicked On BackupsAndRestores in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnBackupsAndRestoresInDB :" + ex.Message);
				}
			}
             
               public static void ClickOnFilesInDB()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBFilesInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBFiles.Click();
				    Reports.ReportLog("Successfully Clicked On Files in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnFilesInDB :" + ex.Message);
				}
			}
                
			 public static void ClickOnConfigurationInDB()
			{
				try 
				{ 
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBConfigurationInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBConfiguration.Click();
				    Reports.ReportLog("Successfully Clicked On Configuration in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnConfigurationInDB :" + ex.Message);
				}
			}
			 
			  public static void ClickOnTempDBSummary()
			{
				try 
				{ 
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBTempDBSummaryInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBTempDBSummary.Click();
				    Reports.ReportLog("Successfully Clicked On TempDBSummary in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnTempDBSummary :" + ex.Message);
				}
			}
			 
			   public static void ClickOnSummaryInDB()
			{
				try 
				{ 
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBSummaryInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBSummary.Click();
				    Reports.ReportLog("Successfully Clicked On Summary in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnSummaryInDB :" + ex.Message);
				}
			}
			   
			   
			public static void VerifyDetailsInOverView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.View.txtOVDEChartInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.SQLdm.View.txtOVDEChart.TextValue == "Chart")
						
						Reports.ReportLog("Details View Under OverView Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Details View Under OverView Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyDetailsInOverView :" + ex.Message);
				}
			}
			
			public static void VerifyConfigurationInOverView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.View.txtOVCONDetailsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.SQLdm.View.txtOVCONDetails.TextValue == "Details")
						
						Reports.ReportLog("Configuration Under OverView Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Configuration Under OverView Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyConfigurationInOverView :" + ex.Message);
				}
			}
			
			public static void VerifyActiveAlertsInOverView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.View.txtOVAADetailsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.SQLdm.View.txtOVAADetails.TextValue == "Details")
						
						Reports.ReportLog("Active Alerts Under OverView Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Active Alerts Under OverView Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyActiveAlertsInOverView :" + ex.Message);
				}
			}
			
			public static void VerifyTimeLineInOverView()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtOVTLDatabasesInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    
					if (repo.SQLdm.txtOVTLDatabases.TextValue == "Databases")
						
						Reports.ReportLog("TimeLine Under OverView Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("TimeLine Under OverView Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyTimeLineInOverView :" + ex.Message);
				}
			}
			
			public static void VerifySignatureModeIsDisplayed()
			{
				try 
				{
					 repo.SQLdm.QueriesTab.rgQUESignatureModeInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.QueriesTab.rgQUESignatureMode.Checked == true)
				    {
				    	Reports.ReportLog("Signature Mode Displaying By Default in Queries Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				    }
				    else
				    {
				    	Reports.ReportLog("Signature Mode Is Not Displaying By Default in Queries Tab", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				    }
				    
//					if (repo.SQLdm.tblQueryEventOccerrances.Rows.Count >= 0 )
//					{
//						repo.SQLdm.tblQueryEventOccerrances.Rows[0].Click();
//						Reports.ReportLog("No Of Records Present in Signature Mode Is:" + repo.SQLdm.tblQueryEventOccerrances.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
//					}
//					else
//					{
//						Reports.ReportLog("There is No Data in Signature Mode", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
//					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifySignatureModeIsDisplayed :" + ex.Message);
				}
			}
			
			public static void VerifyStatementModeIsDisplayed()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblQueryEventOccerrancesInfo.WaitForItemExists(MaxSyncWaitTime);
				    
					if (repo.SQLdm.tblQueryEventOccerrances.Rows.Count >= 0 )
					{
						repo.SQLdm.tblQueryEventOccerrances.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Statement Mode Is:" + repo.SQLdm.tblQueryEventOccerrances.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Statement Mode Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Statement Mode Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyStatementModeIsDisplayed :" + ex.Message);
				}
			}
			
			public static void VerifyQueryHistoryIsDisplayed()
			{
				try 
				{
					//repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblQueryEventOccerrancesInfo.WaitForItemExists(MaxSyncWaitTime);
				    
					if (repo.SQLdm.tblQueryEventOccerrances.Rows.Count >= 0 )
					{
						repo.SQLdm.tblQueryEventOccerrances.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Query History Is:" + repo.SQLdm.tblQueryEventOccerrances.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Query History Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Query History Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyQueryHistoryIsDisplayed :" + ex.Message);
				}
			}
			
			
			public static void VerifyQueryWaitsIsDisplayed()
			{
				try 
				{
				    if (repo.SQLdm.btnQWQueryWaitsOverTimeInfo.Exists())
						Reports.ReportLog("Query Waits Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Query Waits Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyQueryHistoryIsDisplayed :" + ex.Message);
				}
			}
			
			
			public static void VerifySummaryInDataBases()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSSummaryInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSSummaryInfo.Exists())
					{
						repo.SQLdm.tblDBSSummary.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Summary In DataBases Is:" + repo.SQLdm.tblDBSSummary.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Summary View Displayed Successfully in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Summary View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifySummaryInDataBases :" + ex.Message);
				}
			}
			
			public static void VerifyTempDBSummaryInDataBases()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSTempDBSummaryInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSTempDBSummaryInfo.Exists())
					{
						repo.SQLdm.tblDBSTempDBSummary.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Temp DB Summary In DataBases Is:" + repo.SQLdm.tblDBSTempDBSummary.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Temp DB Summary View Displayed Successfully in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Temp DB Summary View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyTempDBSummaryInDataBases :" + ex.Message);
				}
			}
			
			
			
	public static void VerifyConfigurationInDataBases()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSConfigurationInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSConfigurationInfo.Exists())
					{
						repo.SQLdm.tblDBSConfiguration.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Configuration In DataBases Is:" + repo.SQLdm.tblDBSConfiguration.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Configuration View Displayed Successfully in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Configuration View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyConfigurationInDataBases :" + ex.Message);
				}
			}
			
			public static void VerifyFilesInDataBases()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSFilesInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSFilesInfo.Exists())
					{
						repo.SQLdm.tblDBSFiles.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Files In DataBases Is:" + repo.SQLdm.tblDBSFiles.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Files View Displayed Successfully in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Files View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyFilesInDataBases :" + ex.Message);
				}
			}
			
          
       	public static void ClickProperties()
		{
			try
			{
				repo.SQLdmDesktopClient.Properties.ClickThis();
				Common.WaitForSync(30000);
				Reports.ReportLog("Clicked Properties ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickProperties :" + ex.Message);
			}
		}
		
		public static void ClickOSMetrix()
		{
			try
			{
				repo.MonitoredSqlServerInstancePropertiesDial.OSMetrix.ClickThis();
				Reports.ReportLog("Clicked OSMetrix ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OSMetrix :" + ex.Message);
			}
		}
		
		public static void SelectOperatingSystemMetrixUsingDirectWMI()
		{
			try
			{
				repo.MonitoredSqlServerInstancePropertiesDial.OsPropertyPage.OptionWmiDirect.Click();
				Reports.ReportLog("Option Operating System Metrix Using Direct WMI Selected ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectOperatingSystemMetrixUsingDirectWMI :" + ex.Message);
			}
		}
		
		public static void SelectOptionSqldmServiceAccount()
		{
			try
			{
				if(repo.MonitoredSqlServerInstancePropertiesDial.OsPropertyPage.SqldmServiceAccount.Checked)
				{
					repo.MonitoredSqlServerInstancePropertiesDial.OsPropertyPage.SqldmServiceAccount.ClickThis();
					Reports.ReportLog("OptionSqldmServiceAccount Selected ", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectOptionSelectSqldmServiceAccount :" + ex.Message);
			}
		}
		
		public static void EnterUsername(string username)
		{
			try
			{
				repo.MonitoredSqlServerInstancePropertiesDial.OsPropertyPage.UserName.PressKeys(username);
				Reports.ReportLog("Entered Username " + username , Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterUsername :" + ex.Message);
			}
		}
		
		public static void EnterPassword(string password)
		{
			try
			{
				repo.MonitoredSqlServerInstancePropertiesDial.OsPropertyPage.Password.PressKeys(password);
				Reports.ReportLog("Entered Password "+ password, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterPassword :" + ex.Message);
			}
		}
		
		public static void ClickTest()
		{
			try
			{
				repo.MonitoredSqlServerInstancePropertiesDial.OsPropertyPage.WmiTestButton.ClickThis();
				Reports.ReportLog("Clicked Test Button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickTest :" + ex.Message);
			}
		}
		
		public static void VerifyPopupMessage()
		{
			try
			{
				if(repo.ExceptionMessageBoxForm.SelfInfo.Exists())
				{
					Reports.ReportLog("PopupMessage Exists", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("PopupMessage does not Exists", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					throw new Exception("Failed : VerifyPopupMessage ");
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyPopupMessage :" + ex.Message);
			}
		}
		
		 public static void ClickOnResourcesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabResourcesInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabResources.Click();
				    Reports.ReportLog("Successfully Clicked On Resources Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnResourcesTab :" + ex.Message);
				}
			}
		 public static void ClickOnSummaryInResourcesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESSummaryInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESSummary.Click();
				    Reports.ReportLog("Successfully Clicked On Summary In Resources Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnSummaryInResourcesTab :" + ex.Message);
				}
			}
		 
		   public static void VerifySummaryViewInResources()
			{
				try 
				{ 
					
		            if(repo.SQLdm.TableLayoutPanelInfo.Exists())
		             {
		                CompressedImage rsSummary = repo.SQLdm.TableLayoutPanelInfo.GetRESSummary();
		                Imaging.FindOptions options = Imaging.FindOptions.Default;
		                RepoItemInfo info = repo.SQLdm.TableLayoutPanelInfo;
		                bool isvalid = Validate.ContainsImage(info, rsSummary, options,"Summary View image comparision in Resources Tab", true);
			         }
			    }
	            catch (Exception ex)
	            {
	                throw new Exception("Failed : VerifySummaryViewInResources  : " + ex.Message);
	            }

			}
		   
		  public static void ClickOnProcedureCacheInResourcesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESProcedureCacheInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESProcedureCache.Click();
				    Reports.ReportLog("Successfully Clicked On ProcedureCache In Resources Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnProcedureCacheInResourcesTab :" + ex.Message);
				}
			}   
		  
		     public static void ClickOnServerWaitsInResourcesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESServerWaitsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESServerWaits.Click();
				    Reports.ReportLog("Successfully Clicked On ServerWaits In Resources Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnServerWaitsInResourcesTab :" + ex.Message);
				}
			} 
			 
		      public static void VerifyServerWaitsInResources()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblRESServerWaitsInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblRESServerWaitsInfo.Exists())
					{
						repo.SQLdm.tblRESServerWaits.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Server Waits In Resources Is:" + repo.SQLdm.tblRESServerWaits.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Server Waits Displayed Successfully In Resources", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Server Waits Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyServerWaitsInResources :" + ex.Message);
				}
			}
		      public static void ClickOnServicesTab()
			  {
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabServicesInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabServices.Click();
				    Reports.ReportLog("Successfully Clicked On Services Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnServicesTab :" + ex.Message);
				}
			  } 
		      
		      public static void ClickOnReplicationInService()
			  {
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabServicesInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tabServices.Click();
				    Reports.ReportLog("Successfully Clicked On Replication In Service Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnReplicationInService :" + ex.Message);
				}
			  }
		      
		       public static void VerifySummaryInServices()
			  {
			  	try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSServiceSummaryInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSServiceSummaryInfo.Exists())
					{
						repo.SQLdm.tblDBSServiceSummary.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Summary In Services Is:" + repo.SQLdm.tblDBSServiceSummary.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Summary View Displayed Successfully in Services", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Summary View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifySummaryInServices :" + ex.Message);
				}
			  }
		       
		       
            public static void ClickOnSqlAgentJobsInServices()
			{
				try 
				{					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ServicesTab.rgSERSqlAgentJobsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ServicesTab.rgSERSqlAgentJobs.Click();
				    Reports.ReportLog("Successfully Clicked On Sql Agent Jobs in Services", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnSqlAgentJobsInServices :" + ex.Message);
				}
			}
			   public static void VerifySqlAgentJobsInServices()
			  {
			  try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSServiceSqlAgentJobsInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSServiceSqlAgentJobsInfo.Exists())
					{
						repo.SQLdm.tblDBSServiceSqlAgentJobs.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Sql Agent Jobs In Services Is:" + repo.SQLdm.tblDBSServiceSqlAgentJobs.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Sql Agent Jobs View Displayed Successfully in Services", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Sql Agent Jobs View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifySqlAgentJobsInServices :" + ex.Message);
				}
			  }
			   
			   public static void VerifySqlAgentJobsJobsHistoryInServices()
			  {
			  try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSServicesJobHistoryInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSServicesJobHistoryInfo.Exists())
					{
				    	//repo.SQLdm.tblDBSServicesJobHistory
						repo.SQLdm.tblDBSServicesJobHistory.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Sql Agent Jobs Histroy In Services Is:" + repo.SQLdm.tblDBSServicesJobHistory.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Sql Agent Jobs Histroy View Displayed Successfully in Services", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Sql Agent Jobs Histroy View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifySqlAgentJobsJobsHistoryInServices :" + ex.Message);
				}
			  }
		      
		        public static void ClickOnFileActivityInResourcesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESFileActivityInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESFileActivity.Click();
				    Reports.ReportLog("Successfully Clicked On FileActivity In Resources Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnFileActivityInResourcesTab :" + ex.Message);
				}
			}   
		        
		      public static void VerifyFileActivityInResources()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ddlRESFileActivityInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.ddlRESFileActivityInfo.Exists())
					{
						Reports.ReportLog("File Activity Displayed Successfully In Resources", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("File Activity  Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyFileActivityInResources :" + ex.Message);
				}
			}
            
            public static void ClickOnTools()
		{
		try 
		{
		repo.SQLdm.ToolsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
		repo.SQLdm.Tools.Click();
		Reports.ReportLog("ClickOnTools", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
		} 
		catch (Exception ex)
		{
		throw new Exception("Failed : ClickOnTools :" + ex.Message);
		}
		}
            
         public static void SelectAlertActionsandResponsesOption()
		{ 
		try
		{
		
			Ranorex.MenuItem AlertActionsandResponsesMenuItem = AlertActionsandResponses_MENU;
			if(AlertActionsandResponsesMenuItem != null) 
			AlertActionsandResponsesMenuItem.ClickThis();
		Reports.ReportLog("Clicked On Alert Actions and Response Actions", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
		}
		catch (Exception ex)
		{
		throw new Exception("Failed : SelectAlertActionsandResponsesOption :" + ex.Message);
		}
		}
		public static void ClickonActionProvidersOption()
				{
					try 
					{
						repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
						repo.AlertActionsandResponsesOptionDialog.tabActionProviders.Click();
					  
						Reports.ReportLog("Click On Action Providers Option", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					} 
					catch (Exception ex)
					{
					throw new Exception("Failed : ClickOnActionProviders :" + ex.Message);
					}
				}
		
		 public static void AddAlertResponses()
		 {
			try 
					{
						repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
						repo.AlertActionsandResponsesOptionDialog.btnAlertAndResponseAdd.Click();
						repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
						repo.AlertResponsesDialog.btnARDAdd.Click();
						//repo.AddActionProviderDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
						repo.AddActionProviderDialog.chkNewProviderInfo.WaitForExists(new Duration(MaxSyncWaitTime));
						repo.AddActionProviderDialog.chkNewProvider.Rows[0].DoubleClick();
						
				        repo.AddActionProviderDialog.btnOK.Click();
				        repo.AddActionproviderWizard.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				        repo.AddActionproviderWizard.btnAPWNext.Click();
				        repo.AddActionproviderWizard.ddlAPWProvider.Click();
				        //code for select value from dropdown				        			        				      
				        repo.AddActionproviderWizard.txtAPWProvidertext.Click();
				        repo.AddActionproviderWizard.txtAPWProvidertext.Element.SetAttributeValue("Text",ProviderName);
				        //code for entering text in textbox
				        repo.AddActionproviderWizard.btnAPWSMTPNext.Click();
				        repo.AddActionproviderWizard.txtAPWServerName.Click();
				        //code for entering text into address textbox
				        repo.AddActionproviderWizard.txtAPWServerName.Element.SetAttributeValue("Text",ProviderAddress);
				        repo.AddActionproviderWizard.chkAPWAuthentication.Click();
				        repo.AddActionproviderWizard.txtAPWLoginName.Click();
				        //code for entering text into username textbox
				        repo.AddActionproviderWizard.txtAPWLoginName.Element.SetAttributeValue("Text",ProviderUserName);
				        repo.AddActionproviderWizard.txtAPWPassword.Click();
				        //code for entering text into password textbox
				        repo.AddActionproviderWizard.txtAPWPassword.Element.SetAttributeValue("Text",ProviderPassword);
				         repo.AddActionproviderWizard.txtAPWEmail.Click();
				        //code for entering text into email textbox
				         repo.AddActionproviderWizard.txtAPWEmail.Element.SetAttributeValue("Text",ProviderEmail);
						 repo.AddActionproviderWizard.btnAPWFinish.Click(); 
				        
						 repo.SMTPActionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
						repo.SMTPActionDialog.txtSADToAddress.Click();
						repo.SMTPActionDialog.txtSADToAddress.Element.SetAttributeValue("Text",SMTPToAddress);
						repo.SMTPActionDialog.btnSADOK.Click();
				        repo.AlertResponsesDialog.txtARDName.Click();
				        repo.AlertResponsesDialog.txtARDName.Element.SetAttributeValue("Text",ResponseName);
				        repo.AlertResponsesDialog.btnARDOK.Click();
				        repo.AlertActionsandResponsesOptionDialog.btnFinish.Click();
				        
				       				       						  					  
						Reports.ReportLog("Alert Responses are added sucessfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					} 
					catch (Exception ex)
					{
					throw new Exception("Failed : AddAlertResponses :" + ex.Message);
					}
				}	
		    public static void RemoveAlertResponses()
         	{
					try 
					{
					
                     repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));						
					 Table tbl=repo.AlertActionsandResponsesOptionDialog.tblAlertResponses;
					   foreach(Row row in tbl.Rows)
					    {
					    	foreach ( Cell cell in row.Cells) 
					    	{
					    		Report.Info("Cell "+cell.Text);	
					    		if(cell.Text==ResponseName || cell.Text==EditResponseName || cell.Text==CopyResponseName)
					    		{
					    			cell.Click();
					    			break;
					    		}
					    	}
					      }
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnAlertAndResponseRemove.Click();
					   repo.ExceptionMessageDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.ExceptionMessageDialog.btnAAROk.Click();
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnFinish.Click();
					   
              		      
						Reports.ReportLog("Alert Responses Removed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					} 
					catch (Exception ex)
					{
					throw new Exception("Failed : RemoveAlertResponsesFailed :" + ex.Message);
					}
				}
		    public static void CopyAlertResponses()
           {
         	try 
					{
					
                     repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));						
					 Table tbl=repo.AlertActionsandResponsesOptionDialog.tblAlertResponses;
					   foreach(Row row in tbl.Rows)
					    {
					    	foreach ( Cell cell in row.Cells) 
					    	{
					    		Report.Info("Cell "+cell.Text);	
					    		if(cell.Text==ResponseName)
					    		{
					    			cell.Click();
					    			break;
					    		}
					    	}
					      }
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnAlertAndResponseCopy.Click();
					   repo.AlertResponsesDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertResponsesDialog.btnARDOK.Click();				     
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnFinish.Click();					                 		     
					   Reports.ReportLog("Alert Responses Copied Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					} 
					catch (Exception ex)
					{
					throw new Exception("Failed : CopyAlertResponses :" + ex.Message);
					}
         }
		    
		    public static void EditAlertResponses()
        {
        	try 
					{
						
					  Table tbl=repo.AlertActionsandResponsesOptionDialog.tblAlertResponses;
					   foreach(Row row in tbl.Rows)
					    {
					    	foreach ( Cell cell in row.Cells) 
					    	{
					    		Report.Info("Cell "+cell.Text);	
					    		if(cell.Text==ResponseName)
					    		{
					    			cell.Click();
					    			break;
					    		}
					    	}
					      }
					   
					   
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnAlertAndResponseEdit.Click();
					  			      
				        repo.AlertResponsesDialog.txtARDName.Click();
				        repo.AlertResponsesDialog.txtARDName.Element.SetAttributeValue("Text",EditResponseName);
				        
					   repo.AlertResponsesDialog.btnARDOK.Click(); 
						 repo.AlertActionsandResponsesOptionDialog.btnFinish.Click();
				        				   
					   
						Reports.ReportLog("Alert Responses are Edited sucessfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
              		      
						Reports.ReportLog("EditAlertResponses", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					} 
					catch (Exception ex)
					{
					throw new Exception("Failed : EditAlertResponses :" + ex.Message);
					}
        }
         
		
		public static void AddActionProviders()
				{
					try 
					{
						repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
						repo.AlertActionsandResponsesOptionDialog.btnActAndResAPAdd.Click();
						repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
						repo.AlertCommunicationsWizardDialog.btnACWNext.Click();
				        repo.AlertCommunicationsWizardDialog.ddlACWProviderType.Click();
				        //code for select value from dropdown				        			        				      
				        repo.AlertCommunicationsWizardDialog.txtACWProviderName.Click();
				        repo.AlertCommunicationsWizardDialog.txtACWProviderName.Element.SetAttributeValue("Text",ProviderName);
				        //code for entering text in textbox
				        repo.AlertCommunicationsWizardDialog.btnACWNext.Click();
				        repo.AlertCommunicationsWizardDialog.txtACWAddress.Click();
				        //code for entering text into address textbox
				        repo.AlertCommunicationsWizardDialog.txtACWAddress.Element.SetAttributeValue("Text",ProviderAddress);
				        repo.AlertCommunicationsWizardDialog.cbACWServerRequriesAuthn.Click();
				        repo.AlertCommunicationsWizardDialog.txtACWUserName.Click();
				        //code for entering text into username textbox
				        repo.AlertCommunicationsWizardDialog.txtACWUserName.Element.SetAttributeValue("Text",ProviderUserName);
				        repo.AlertCommunicationsWizardDialog.txtACWPassword.Click();
				        //code for entering text into password textbox
				        repo.AlertCommunicationsWizardDialog.txtACWPassword.Element.SetAttributeValue("Text",ProviderPassword);
				         repo.AlertCommunicationsWizardDialog.txtACWEmail.Click();
				        //code for entering text into email textbox
				         repo.AlertCommunicationsWizardDialog.txtACWEmail.Element.SetAttributeValue("Text",ProviderEmail);
						 repo.AlertCommunicationsWizardDialog.btnACWFinish.Click();  						  					  	 
						Reports.ReportLog("Action Providers are added sucessfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					} 
					catch (Exception ex)
					{
					throw new Exception("Failed : AddActionProviders :" + ex.Message);
					}
				}	
		
		public static void ClickOnAddRemoveInActionProviders()
				{
					try 
					{
						
					  Table tbl=repo.AlertActionsandResponsesOptionDialog.tblAlertAndActionsAndResponses;
					   foreach(Row row in tbl.Rows)
					    {
					    	foreach ( Cell cell in row.Cells) 
					    	{
					    		Report.Info("Cell "+cell.Text);	
					    		if(cell.Text==ProviderName || cell.Text==ProviderEditName)
					    		{
					    			cell.Click();
					    			break;
					    		}
					    	}
					      }
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnActAndResAPRemove.Click();
					   repo.ExceptionMessageDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.ExceptionMessageDialog.btnAAROk.Click();
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnFinish.Click();
					   
              		      
						Reports.ReportLog("ActionProvidersRemovedSuccessfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					} 
					catch (Exception ex)
					{
					throw new Exception("Failed : ActionProvidersRemovedFailed :" + ex.Message);
					}
				}
		
			  public static void EditActionProviders()
               {
        	     try 
					{
						
					  Table tbl=repo.AlertActionsandResponsesOptionDialog.tblAlertAndActionsAndResponses;
					   foreach(Row row in tbl.Rows)
					    {
					    	foreach ( Cell cell in row.Cells) 
					    	{
					    		Report.Info("Cell "+cell.Text);	
					    		if(cell.Text==ProviderName)
					    		{
					    			cell.Click();
					    			break;
					    		}
					    	}
					      }
					   
					   
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnActAndResAPEdit.Click();
//					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
//						repo.AlertCommunicationsWizardDialog.btnACWNext.Click();
//				        repo.AlertCommunicationsWizardDialog.ddlACWProviderType.Click();
				        //code for select value from dropdown				        			        				      
				        repo.SMTPProviderDialog.txtSMTPProviderName.Click();
				        repo.SMTPProviderDialog.txtSMTPProviderName.Element.SetAttributeValue("Text",ProviderEditName);
				        
					   repo.SMTPProviderDialog.btnSMTPOk.Click();  	
					   
						Reports.ReportLog("Action Providers are Edited sucessfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
              		      
						Reports.ReportLog("EditActionProviders", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					} 
					catch (Exception ex)
					{
					throw new Exception("Failed : EditActionProviders :" + ex.Message);
					}
        }

         public static void ClickOnEditRemoveInActionProviders()
				{
					try 
					{
						
					  Table tbl=repo.AlertActionsandResponsesOptionDialog.tblRemoveAlertAndActionsAndResponses;
					   foreach(Row row in tbl.Rows)
					    {
					    	foreach ( Cell cell in row.Cells) 
					    	{
					    		Report.Info("Cell "+cell.Text);	
					    		if(cell.Text==ProviderName || cell.Text==ProviderEditName)
					    		{
					    			cell.Click();
					    			break;
					    		}
					    	}
					      }
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnActAndResAPRemove.Click();
					   repo.ExceptionMessageDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.ExceptionMessageDialog.btnAAROk.Click();
					   repo.AlertActionsandResponsesOptionDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					   repo.AlertActionsandResponsesOptionDialog.btnFinish.Click();
					   
              		      
						Reports.ReportLog("ActionProvidersRemovedSuccessfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					} 
					catch (Exception ex)
					{
					throw new Exception("Failed : ActionProvidersRemovedFailed :" + ex.Message);
					}
				}
						  
		  
		   public static void VerifyProcedureCacheInResources()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblRESProcedureCacheInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblRESProcedureCacheInfo.Exists())
					{
						repo.SQLdm.tblRESProcedureCache.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Procedure Cache In Resources Is:" + repo.SQLdm.tblRESProcedureCache.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Procedure Cache Displayed Successfully In Resources", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Procedure Cache Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyProcedureCacheInResources :" + ex.Message);
				}
			}			   
		    public static void ClickOnDiskInResourcesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESDiskInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESDisk.Click();
				    Reports.ReportLog("Successfully Clicked On Disk In Resources Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnDiskInResourcesTab :" + ex.Message);
				}
			}
		    
		    public static void VerifyDiskViewInResources()
			{
				try 
				{ 
					
		            if(repo.SQLdm.TableLayoutPanelInfo.Exists())
		             {
		                CompressedImage rsDisk = repo.SQLdm.TableLayoutPanelInfo.GetRESDisk();
		                Imaging.FindOptions options = Imaging.FindOptions.Default;
		                RepoItemInfo info = repo.SQLdm.TableLayoutPanelInfo;
		                bool isvalid = Validate.ContainsImage(info, rsDisk, options,"Disk View image comparision in Resources Tab", false);
			         }
			    }
	            catch (Exception ex)
	            {
	                throw new Exception("Failed : VerifyDiskViewInResources  : " + ex.Message);
	            }

			}
			
		    public static void ClickOnMemoryInResourcesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESMemoryInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESMemory.Click();
				    Reports.ReportLog("Successfully Clicked On Memory In Resources Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnMemoryInResourcesTab :" + ex.Message);
				}
			}
		    
		    public static void VerifyMemoryViewInResources()
			{
				try 
				{ 
					
		            if(repo.SQLdm.TableLayoutPanelInfo.Exists())
		             {
		                CompressedImage rsMemory = repo.SQLdm.TableLayoutPanelInfo.GetRESMemory();
		                Imaging.FindOptions options = Imaging.FindOptions.Default;
		                RepoItemInfo info = repo.SQLdm.TableLayoutPanelInfo;
		                bool isvalid = Validate.ContainsImage(info, rsMemory, options,"Memory View image comparision in Resources Tab", false);
			         }
			    }
	            catch (Exception ex)
	            {
	                throw new Exception("Failed : VerifyMemoryViewInResources  : " + ex.Message);
	            }

			}
		    
		      public static void ClickOnCPUInResourcesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESCPUInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESCPU.Click();
				    Reports.ReportLog("Successfully Clicked On CPU In Resources Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnCPUInResourcesTab :" + ex.Message);
				}
			}
			 
		       public static void VerifyCPUViewInResources()
			{
				try 
				{ 
					
		            if(repo.SQLdm.TableLayoutPanelInfo.Exists())
		             {
		                CompressedImage rsCPU = repo.SQLdm.TableLayoutPanelInfo.GetRESCPU();
		                Imaging.FindOptions options = Imaging.FindOptions.Default;
		                RepoItemInfo info = repo.SQLdm.TableLayoutPanelInfo;
		                bool isvalid = Validate.ContainsImage(info, rsCPU, options,"CPU View image comparision in Resources Tab", false);
			         }
			    }
	            catch (Exception ex)
	            {
	                throw new Exception("Failed : VerifyCPUViewInResources  : " + ex.Message);
	            }

			}		
public static void VerifyTablesAndIndexesInDataBases()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSTablesAndIndexesInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSTablesAndIndexesInfo.Exists())
					{
						repo.SQLdm.tblDBSTablesAndIndexes.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Tables and Indexes In DataBases Is:" + repo.SQLdm.tblDBSTablesAndIndexes.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Tables and Indexes View Displayed Successfully in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Tables and Indexes View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyTablesAndIndexesInDataBases :" + ex.Message);
				}
			}		       
		   
		   public static void VerifyMirroringViewInDataBases()
			{
				try 
					{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSMirroringInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSMirroringInfo.Exists())
					{
						repo.SQLdm.tblDBSMirroring.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Mirroring View In DataBases Is:" + repo.SQLdm.tblDBSMirroring.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Mirroring View Displayed Successfully in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Mirroring View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyMirroringViewInDataBases :" + ex.Message);
				}
			}
			
		   public static void VerifyBackupsAndRestoresInDataBases()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSBackupsAndRestoresInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSBackupsAndRestoresInfo.Exists())
					{
						repo.SQLdm.tblDBSBackupsAndRestores.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Backups And Restores In DataBases Is:" + repo.SQLdm.tblDBSBackupsAndRestores.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Backups And Restores View Displayed Successfully in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Backups And Restores View Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyBackupsAndRestoresInDataBases :" + ex.Message);
				}
			}
		   
		    public static void RightClickOnServer(string serverName)
		{
			try 
			{
				repo.Application.AllServersInfo.WaitForItemExists(120000);
				TreeItem serveritem = repo.Application.AllServers.GetChildItem(serverName);
				if(serveritem != null) serveritem.RightClick(); 
				
			} 
			catch (Exception ex) 
			{
				throw new Exception("Failed : ClickOnAllServers : " + ex.Message);
			}
		}
         
		    
			   public static void ClickOnDiskSizeInResourcesTab()
			{
				try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESDiskSizeInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.ResourcesTab.rgRESDiskSize.Click();
				    Reports.ReportLog("Successfully Clicked On DiskSize In Resources Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnDiskSizeInResourcesTab :" + ex.Message);
				}
			} 
			   
			 public static void VerifyDiskSizeViewInResources()
			  {
				try 
				{									  
					if (repo.SQLdm.ddlRESDiskSizeInfo.Exists())
						
						Reports.ReportLog("Current Disk Usage Under Resourses Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Current Disk Usage Under Resourses Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyDiskSizeViewInResources :" + ex.Message);
				}

			}
			
			  public static void ClickOnAvailabilityGroupInDB()
			{
				try 
				{ 					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBAvailabillityGroupInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.DatabasesTab.rgDBAvailabillityGroup.Click();
				    Reports.ReportLog("Successfully Clicked On Availability Group in Databases", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnAvailabilityGroupInDB :" + ex.Message);
				}
			}
			  public static void VerifyAvailabilityGroupInDatabases()
			{
				try 
				{
					repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.tblDBSTempDBSummaryInfo.WaitForItemExists(MaxSyncWaitTime);
				    
				    if (repo.SQLdm.tblDBSTempDBSummaryInfo.Exists())
					{
						repo.SQLdm.tblDBSTempDBSummary.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in Availability Group In DataBases Is:" + repo.SQLdm.tblDBSTempDBSummary.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog("Availability Group In Databases Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Verify Availability Group In Databases Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifyAvailabilityGroupInDatabases :" + ex.Message);
				}
			}
			  
			  public static void Verifydataonspecificdatabaseinconfiguration()
		{
			try 
				{									  
				
					repo.SQLdm.ddlConfiguration.Click();
					
				    repo.SQLdm.tblDatabaseConfigurationInfo.WaitForItemExists(MaxSyncWaitTime);
				    
					if (repo.SQLdm.tblDatabaseConfiguration.Rows.Count >= 0 )
					{
						repo.SQLdm.tblDatabaseConfiguration.Rows[0].Click();
						Reports.ReportLog("No Of Records Present in selected Data base Is:" + repo.SQLdm.tblDatabaseConfiguration.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						Reports.ReportLog(" Selected Data base Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					else
					{
						Reports.ReportLog("Selected Data base Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					}
						
				}
				catch (Exception ex)
				{
					throw new Exception("Failed : Verifydataonspecificdatabaseinconfiguration :" + ex.Message);
				}
			
		}
			  			   
          public static void TestSQLAuthentication()
         {
         	try 
					{
					 repo.MonitoredSqlServerInstancePropertiesDial.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));	
					 repo.MonitoredSqlServerInstancePropertiesDial.rdbsqlauthentication.Click();
					 repo.MonitoredSqlServerInstancePropertiesDial.txtsqlloginname.Click();
					 repo.MonitoredSqlServerInstancePropertiesDial.txtsqlloginname.Element.SetAttributeValue("Text","");
				     repo.MonitoredSqlServerInstancePropertiesDial.txtsqlloginname.Element.SetAttributeValue("Text",SQLUserName);
				     repo.MonitoredSqlServerInstancePropertiesDial.txtsqlpwd.Click();
				     repo.MonitoredSqlServerInstancePropertiesDial.txtsqlpwd.Element.SetAttributeValue("Text","");
				     repo.MonitoredSqlServerInstancePropertiesDial.txtsqlpwd.Element.SetAttributeValue("Text",SQLPassword);
				     repo.MonitoredSqlServerInstancePropertiesDial.btnTest.Click();
					 if(repo.ExceptionMessageBoxForm.SelfInfo.Exists())
						{
					     repo.ExceptionMessageBoxForm.ButtonYes.Click();
						 Reports.ReportLog("PopupMessage Exists", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
						 
						}
						else
						{
							Reports.ReportLog("PopupMessage does not Exists", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
							throw new Exception("Failed : VerifyPopupMessage ");
						}
				        repo.MonitoredSqlServerInstancePropertiesDial.btnOk.Click();
						//repo.MonitoredSqlServerInstancePropertiesDial.btnClose.Click();
				     	Thread.Sleep(12000);
				    } 
					catch (Exception ex)
					{
					throw new Exception("Failed : TestSQLAuthentication :" + ex.Message);
					}
         	
         }
         
            public static void VerifySummarygraphsUnderSessions()
        {
        	try 
				{
					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtSUMResponseTimeInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    if (repo.SQLdm.txtSUMResponseTime.TextValue == "Response Time")
						Reports.ReportLog("Response Time View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Response Time View Under Sessions Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					
					 repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtSumSessionsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    if (repo.SQLdm.txtSumSessions.TextValue == "Sessions")
						Reports.ReportLog("Sessions View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Sessions View Under Sessions Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					
					 repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtSUMLockStatisticsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    if (repo.SQLdm.txtSUMLockStatistics.Text == "Lock Statistics: Requests")
						Reports.ReportLog("Lock Statistics View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Lock Statistics View Under Sessions Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
					
					 repo.SQLdm.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    repo.SQLdm.txtSUMBlockedSessionsInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				    if (repo.SQLdm.txtSUMBlockedSessions.TextValue == "Blocked Sessions")
						Reports.ReportLog("Blocked Sessions View Under Sessions Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					else
						Reports.ReportLog("Blocked Sessions View Under Sessions Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);        
        	}
				catch (Exception ex)
				{
					throw new Exception("Failed : VerifySummarygraphsUnderSessions :" + ex.Message);
				}
             }
      
		   		
		   
		public static void VerifyImage123()
		{
			try
			{
				if(repo.Application.ElementBrInfo.Exists())
				{
					CompressedImage BarChart = repo.Application.ElementBrInfo.GetCPU();
					
					Imaging.FindOptions MyFindOptions = new Imaging.FindOptions(0.40);
					
					Bitmap bmp = Imaging.CaptureImage(repo.Application.ElementBr);
					bool isvalid = Imaging.Compare(bmp, BarChart, MyFindOptions);
					if(isvalid)
					{
						Reports.ReportLog("PopupMessage Exists", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
					}
					
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ValidateCurrencycodeColorChart  : " + ex.Message);
			}

	   }

			public static void ClickonFulltextSearchInServices()
		   {
		   	try 
			{					
			    repo.SQLdm.SelfInfo.WaitForExists(new Duration(1000000));
			    repo.SQLdm.ServicesTab.rgSERFullTextSearchInfo.WaitForExists(new Duration(1000000));
			    repo.SQLdm.ServicesTab.rgSERFullTextSearch.Click();
			    Reports.ReportLog("Successfully Clicked On Full Text Search in Services", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : Click On Full Text Search in services :" + ex.Message);
			}
		   }
		   public static void VerifyFullTextSearchInservices()
		   {
		   	try 
			{
				repo.SQLdm.SelfInfo.WaitForExists(new Duration(1000000));
			    repo.SQLdm.tblFulltextsearchInfo.WaitForItemExists(1000000);
			    
			    if (repo.SQLdm.tblFulltextsearchInfo.Exists())
				{
					repo.SQLdm.tblFulltextsearch.Rows[0].Click();
					Reports.ReportLog("No Of Records Present in Full Text Search In Services Is:" + repo.SQLdm.tblFulltextsearch.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Reports.ReportLog("Full Text Search Displayed Successfully In Services", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Full Text Search Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyFullTextSearchInservices :" + ex.Message);
			}
		   }

 			public static void ClickOnLogsTab()
			{
				try 
				{					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(1000000));
				    repo.SQLdm.tabLogsInfo.WaitForExists(new Duration(1000000));
				    repo.SQLdm.tabLogs.Click();
				    Reports.ReportLog("Successfully Clicked On Logs Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnLogsTab :" + ex.Message);
				}
			}	

            public static void ClickOnAnalyzeTab()
			{
				try 
				{					
				    repo.SQLdm.SelfInfo.WaitForExists(new Duration(1000000));
				    repo.SQLdm.tabAnalyzeInfo.WaitForExists(new Duration(1000000));
				    repo.SQLdm.tabAnalyze.Click();
				    Reports.ReportLog("Successfully Clicked On Analyze Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnAnalyzeTab :" + ex.Message);
				}
			}	 			
          
        	public static void ClickOnRunAnalysisInAnalyze()
			{
				try 
				{					
				   repo.SQLdm.SelfInfo.WaitForExists(new Duration(1000000));
				   repo.SQLdm.AnalyzeTab.rgAnalyzeRunAnalysisInfo.WaitForExists(new Duration(1000000));
			       repo.SQLdm.AnalyzeTab.rgAnalyzeRunAnalysis.Click();				   
				   Reports.ReportLog("Successfully Clicked On Run Analysis In Analyze Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnRunAnalysisInAnalyze :" + ex.Message);
				}
			}
        	
           public static void VerifyRunAnalysisInAnalyze()
		   {
		   	try 
			{
				repo.SQLdm.SelfInfo.WaitForExists(new Duration(1000000));
			    repo.SQLdm.tblAnalyzeRunAnalysisInfo.WaitForItemExists(1000000);
			    
			    if (repo.SQLdm.tblAnalyzeRunAnalysisInfo.Exists())
				{
					repo.SQLdm.tblAnalyzeRunAnalysis.Rows[0].Click();
					Reports.ReportLog("No Of Records Present in Run Analysis In Analyze Is:" + repo.SQLdm.tblFulltextsearch.Rows.Count, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
					Reports.ReportLog("Run Analysis In Analyze Displayed Successfully", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Run Analysis In Analyze Is Not Displaying", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				}
			} 
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyRunAnalysisInAnalyze :" + ex.Message);
			}
		   }

            public static void ClickOnRunWorkLoadAnalysisInAnalyze()
			{
				try 
				{					
				   repo.SQLdm.SelfInfo.WaitForExists(new Duration(1000000));
				   repo.SQLdm.AnalyzeTab.rgAnalyzeRunWorkLoadAnalysisInfo.WaitForExists(new Duration(1000000));
			       repo.SQLdm.AnalyzeTab.rgAnalyzeRunWorkLoadAnalysis.Click();				   
				   Reports.ReportLog("Successfully Clicked On Run Work Load Analysis In Analyze Tab", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);					
				} 
				catch (Exception ex)
				{
					throw new Exception("Failed : ClickOnRunWorkLoadAnalysisInAnalyze :" + ex.Message);
				}
			}        	
    }
}
    