using System;
using System.Collections.Generic;
using System.Linq;
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


namespace AutomationSQLdm.Grooming_Modifications
{
	public static class Steps
	{
		public static GroomingRepo repo = GroomingRepo.Instance;
		
		 //Handling Sync Wait
    	public static int MinSyncWaitTime = 180000;
    	public static int MidSyncWaitTime = 240000;    		
		public static int MaxSyncWaitTime = 300000;    		
    	//MaxSyncWaitTime	
		public const string GROOMING_MENU = @"/contextmenu[@processname='SQLdmDesktopClient']/menuitem[@automationid='menuToolsGrooming']";
		
		
		public static void ClickOnTools()
		{
			try
			{
				repo.Application.ToolsInfo.WaitForItemExists(new Duration(MaxSyncWaitTime));
				repo.Application.Tools.Click();
				Reports.ReportLog("ClickOnTools", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnTools :" + ex.Message);
			}
		}
		
		public static void SelectGroomingOption()
		{
			try
			{
				Ranorex.MenuItem groomingMenuItem = GROOMING_MENU;
				if(groomingMenuItem != null) groomingMenuItem.ClickThis();
				Reports.ReportLog("SelectGroomingOption", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : SelectGroomingOption :" + ex.Message);
			}
		}
		
		public static void VerifyAggregateforecastingValue()
		{
			try
			{
				repo.GroomingOptionWindow.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				repo.GroomingOptionWindow.AggregateTextbox.TextValue = "1095";
				//if (repo.GroomingOptionWindow.AggregateTextboxInfo.Exists())
				if (repo.GroomingOptionWindow.AggregateTextbox.TextValue == "1095")
					Reports.ReportLog("Verify Aggregate forecasting data to daily records after is Displaying: " + repo.GroomingOptionWindow.AggregateTextbox.TextValue , Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Verify Aggregate forecasting data to daily records after is not displaying Default Value :1095", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyAggregateforecastingValue :" + ex.Message);
			}
		}
		
		public static void VerifyGroomforecastingValue()
		{
			try
			{
				repo.GroomingOptionWindow.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				//if (repo.GroomingOptionWindow.GroomForecastTextboxInfo.Exists())
				if (repo.GroomingOptionWindow.GroomForecastTextbox.TextValue == "1095")
					
					Reports.ReportLog("Groom forecasting data to daily records after is Displaying : " + repo.GroomingOptionWindow.GroomForecastTextbox.TextValue, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Groom forecasting data to daily records after is not Displaying ", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyAggregateforecastingValue :" + ex.Message);
			}
		}
		
		public static void ClickOnCancel()
		{
			try
			{
				repo.GroomingOptionWindow.CancelButtonInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				repo.GroomingOptionWindow.CancelButton.Click();
				Reports.ReportLog("Click On Cancel Button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnCancel :" + ex.Message);
			}
		}
		
		public static void VerifyQueryIsRemovedFromText()
		{
			try
			{
				
				//Verify Query is Removed from The Current time on the repository
				if (repo.GroomingOptionWindow.AggregationInCurrentTime.Caption.Contains("Query"))
					Reports.ReportLog("The Current time on the repository is Displaying Query Aggregation", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				else
					Reports.ReportLog("The Current time on the repository is Displaying Only : " + repo.GroomingOptionWindow.AggregationInCurrentTime.Caption, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				
				//Verify Query is Removed from The Current time on the repository
				repo.GroomingOptionWindow.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				if (repo.GroomingOptionWindow.CombineOlderData.TextValue.Contains("Query"))
					Reports.ReportLog("Query is not Removed from The Current time on the repository", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				else
					Reports.ReportLog("Combine older query data into daily roll-up records to save space is Displaying : " + repo.GroomingOptionWindow.CombineOlderData.TextValue, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				
				//Verify Query is Removed from What is the Current grooming status
				if (repo.GroomingOptionWindow.AggregationInCurrentGrooming.Caption.Contains("Query"))
					Reports.ReportLog("What is the Current grooming status is Displaying Query Aggregation", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				else
					Reports.ReportLog("What is the Current grooming status is Displaying Only : " + repo.GroomingOptionWindow.AggregationInCurrentGrooming.Caption, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyQueryIsRemovedFromText :" + ex.Message);
			}
			
		}
		
		public static void VerifyGroomMetricsAndBaseLineFieldMaxValue()
		{
			try
			{
				
				repo.GroomingOptionWindow.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				repo.GroomingOptionWindow.GroomMetricsAndBaseLine.TextValue = "";
				repo.GroomingOptionWindow.GroomMetricsAndBaseLine.TextValue = "1100";
				if (repo.GroomingOptionWindow.GroomMetricsAndBaseLine.TextValue.Contains("1100"))
					Reports.ReportLog("Groom standard metrics and baselines metrics is Displaying Max Value: " + repo.GroomingOptionWindow.GroomMetricsAndBaseLine.TextValue, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Groom standard metrics and baselines metrics is not showing Max Value", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyGroomMetricsAndBaseLineFieldMaxValue :" + ex.Message);
			}
		}
		
		public static void ClickOnServer(string serverName)
		{
			try
			{
				repo.Application.AllServersInfo.WaitForItemExists(120000);
				TreeItem serveritem = repo.Application.AllServers.GetChildItem(serverName);
				if(serveritem != null) serveritem.ClickThis();
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAllServers : " + ex.Message);
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
		
		public static void OpenProperties(string serverName)
		{
			try
			{
				repo.Application.AllServersInfo.WaitForItemExists(120000);
				TreeItem serveritem = repo.Application.AllServers.GetChildItem(serverName);
				if(serveritem != null)
				{
					serveritem.RightClick();
					repo.SQLdmDC.PropertiesInfo.WaitForExists(120000);
					repo.SQLdmDC.Properties.ClickThis();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : OpenProperties : " + ex.Message);
			}
		}
		

		
		public static void DeleteSQLServerInstance(string serverName)
		{
			try
			{
				repo.Application.AllServersInfo.WaitForItemExists(120000);
				TreeItem serveritem = repo.Application.AllServers.GetChildItem(serverName);
				if(serveritem != null)
				{
					serveritem.RightClick();
					repo.SQLdmDC.DeleteInfo.WaitForExists(120000);
					repo.SQLdmDC.Delete.ClickThis();
					repo.DeleteConfirmWindow.btnConfirmNo.ClickThis();
					Reports.ReportLog("Successfully Deleted Server ID: " + serverName, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : DeleteSQLServerInstance : " + ex.Message);
			}
		}
		
		
		
		public static void EnterTextInAggregateForecasting(int AggregateForecasting)
		{
			try
			{
				repo.GroomingOptionWindow.AggregateTextboxInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				//repo.GroomingOptionWindow.AggregateTextbox.TextValue = "";
				repo.GroomingOptionWindow.AggregateTextbox.TextValue = AggregateForecasting.ToString();
				
				
				Reports.ReportLog("Successfully Entered Aggregation Value: " + AggregateForecasting, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : EnterTextInAggregateForecasting :" + ex.Message);
			}
		}
		
		public static void ClickOnGroomNow()
		{
			try
			{
				repo.GroomingOptionWindow.btnGroomNowInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				repo.GroomingOptionWindow.btnGroomNow.ClickThis();
				Reports.ReportLog("Click On Groom Now Button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnGroomNow :" + ex.Message);
			}
		}
		
		public static void ClickOnAggregateNow()
		{
			try
			{
				repo.GroomingOptionWindow.btnAggregateNowInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				repo.GroomingOptionWindow.btnAggregateNow.ClickThis();
				Reports.ReportLog("Click On Aggregate Now Button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnAggregateNow :" + ex.Message);
			}
		}
		
		public static void ClickOnRefresh()
		{
			try
			{
				repo.GroomingOptionWindow.btnRefreshInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				repo.GroomingOptionWindow.btnRefresh.ClickThis();
				Reports.ReportLog("Click On Refresh Button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnRefresh :" + ex.Message);
			}
		}
		
		
		
		public static void ClickOnOk()
		{
			try
			{
				repo.GroomingOptionWindow.btnGOWOkInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				repo.GroomingOptionWindow.btnGOWOk.ClickThis();
				Reports.ReportLog("Click On Ok Button", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : ClickOnOk :" + ex.Message);
			}
		}
		
		public static void VerifyCurrentRunningStatusInDataGrooming(string strCurrentRunningStatusInDG)
		{
			try
			{
				repo.GroomingOptionWindow.txtDGCurrentlyRunningStatusInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				
				if (repo.GroomingOptionWindow.txtDGCurrentlyRunningStatus.TextValue == strCurrentRunningStatusInDG)
					Reports.ReportLog("Successfully Verified Current Running Status In DataGrooming As: " + repo.GroomingOptionWindow.txtDGCurrentlyRunningStatus.TextValue, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Failed to Verify Current Running Status In DataGrooming As: " + strCurrentRunningStatusInDG, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyCurrentRunningStatusInDataGrooming :" + ex.Message);
			}
		}
		
		public static void VerifyCompletionStatusInDataGrooming(string strCompletionStatusInDG)
		{
			try
			{
				repo.GroomingOptionWindow.txtDGCompletionStatusInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				
				if (repo.GroomingOptionWindow.txtDGCompletionStatus.TextValue == strCompletionStatusInDG)
					Reports.ReportLog("Successfully Verified Completion Status In DataGrooming As: " + repo.GroomingOptionWindow.txtDGCompletionStatus.TextValue, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Failed to Verify Completion Status In DataGrooming As: " + strCompletionStatusInDG, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyCompletionStatusInDataGrooming :" + ex.Message);
			}
		}
		
		public static void VerifyCurrentRunningStatusInAggregation(string strCurrentRunningStatusInAG)
		{
			try
			{
				repo.GroomingOptionWindow.txtAggregationCurrentlyRunningInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				
				if (repo.GroomingOptionWindow.txtAggregationCurrentlyRunning.TextValue == strCurrentRunningStatusInAG)
					Reports.ReportLog("Successfully Verified Current Running Status In Aggregation As: " + repo.GroomingOptionWindow.txtAggregationCurrentlyRunning.TextValue, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Failed to Verify Current Running Status In Aggregation As: " + strCurrentRunningStatusInAG, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyCurrentRunningStatusInAggregation :" + ex.Message);
			}
		}
		
		public static void VerifyCompletionStatusInAggregation(string strCompletionStatusInAG)
		{
			try
			{
				repo.GroomingOptionWindow.txtAggregationCompletionStatusInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				
				if (repo.GroomingOptionWindow.txtAggregationCompletionStatus.TextValue == strCompletionStatusInAG)
					Reports.ReportLog("Successfully Verified Completion Status In Aggregation As: " + repo.GroomingOptionWindow.txtAggregationCompletionStatus.TextValue, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Failed to Verify Completion Status In Aggregation As: " + strCompletionStatusInAG, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyCompletionStatusInAggregation :" + ex.Message);
			}
		}
		
		public static void VerifyQueryDataCount(string strQuery,string strTableName)
		{
			try
			{
				DataTable dtInfo = DataAccess.GetData(strQuery);
				if(dtInfo != null && dtInfo.Rows.Count > 0)
					Reports.ReportLog("Total No Of Records present in " + strTableName + "  Is : " + dtInfo.Rows.Count, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Records is not present in Table: " + strTableName, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyQueryDataCount :" + ex.Message);
			}
		}
		
		public static void GetMonitoredServerID(string Query,ref string ServerID)
		{
			try
			{
				DataTable dtInfo = DataAccess.GetData(Query);
				if(dtInfo != null && dtInfo.Rows.Count > 0)
				{
					ServerID = dtInfo.Rows[0]["SQLServerID"].ToString();
					Reports.ReportLog("Monitered Instance ID Is: " + ServerID , Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				}
				else
				{
					Reports.ReportLog("Failed to Get Monitered Instance ID", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				}
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : GetMonitoredServerID :" + ex.Message);
			}
			
		}
		
		public static void VerifyInstanceIsDeleted(string Query,string TableName)
		{
			try
			{
				DataTable dtInfo = DataAccess.GetData(Query);
				if(dtInfo != null && dtInfo.Rows.Count == 0)
					Reports.ReportLog("Deleted server ID is not showning in Table " + TableName , Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Server Instance is Not Deleted" + TableName, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyInstanceIsDeleted :" + ex.Message);
			}
		}
		
		public static void AddSQLServerInstance(string serverName)
		{
			try
			{
				if (repo.GettingStartWindow.txtGSWAddNewServerInfo.Exists())
				{
					//Click On Add Server Button
					repo.GettingStartWindow.txtGSWAddNewServer.ClickThis();
					
					//Calling the function to Add Server
					StepsAddServer(serverName);
				}
				
				else
				{
					repo.Application.AllServersInfo.WaitForItemExists(120000);
					TreeItem serveritem = repo.Application.AllServers.GetChildItem(serverName);
					if(serveritem == null)
					{
						//Right Click On AllServers
						repo.Application.AllServers.RightClick();
						
						//Click On Manage Servers
						repo.SQLdmDC.ManageServersInfo.WaitForExists(120000);
						repo.SQLdmDC.ManageServers.ClickThis();
						
						//Calling the function to Add Server
						StepsAddServer(serverName);
						
					}
					else
					{
						Reports.ReportLog("Server Instance is Already Present: " + serverName, Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
						
					}
					
				}

			}
			catch (Exception ex)
			{
				throw new Exception("Failed : AddSQLServerInstance : " + ex.Message);
			}
		}
		
		public static void StepsAddServer(string serverName)
		{
			try
			{
					//Wait For Confirmation
					repo.ManageServersDialog.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
					
					//Click ON Add Button IN Manage Servers
					repo.ManageServersDialog.btnMSAddInfo.WaitForExists(120000);
					repo.ManageServersDialog.btnMSAdd.ClickThis();
					
					
					//Click ON Next in Add Server Wizard
					repo.AddServersWizardDialog.btnASWNextInfo.WaitForExists(120000);
					repo.AddServersWizardDialog.btnASWNext.ClickThis();
					
					//Click ON Next in Add Configure Authentication
					repo.AddServersWizardDialog.btnASWNextInfo.WaitForExists(120000);
					repo.AddServersWizardDialog.btnASWNext.ClickThis();
					
					//Enter Server Name
					repo.AddServersWizardDialog.txtAvailableServersInfo.WaitForExists(120000);
					repo.AddServersWizardDialog.txtAvailableServers.TextValue = serverName.ToString();
					
					//Click ON Add Button in Select Server To Monitor
					repo.AddServersWizardDialog.btnSSTMAddInfo.WaitForExists(120000);
					repo.AddServersWizardDialog.btnSSTMAdd.ClickThis();
					
					//Click ON Next in Select Server To Monitor
					repo.AddServersWizardDialog.btnASWNextInfo.WaitForExists(120000);
					repo.AddServersWizardDialog.btnASWNext.ClickThis();
					
					//Click ON Next in Add Servers
					repo.AddServersWizardDialog.btnASWNextInfo.WaitForExists(120000);
					repo.AddServersWizardDialog.btnASWNext.ClickThis();
					
					//Click ON Next in Configure SQLdm
					repo.AddServersWizardDialog.btnASWNextInfo.WaitForExists(120000);
					repo.AddServersWizardDialog.btnASWNext.ClickThis();
					
					//Click ON Next in Configure OS Collection
					repo.AddServersWizardDialog.btnASWNextInfo.WaitForExists(120000);
					repo.AddServersWizardDialog.btnASWNext.ClickThis();
					
					//Click ON Finish in Configure OS Collection
					Common.WaitForSync(120000);
					repo.AddServersWizardDialog.btnASFinishInfo.WaitForExists(120000);
					repo.AddServersWizardDialog.btnASFinish.ClickThis();
					Common.WaitForSync(120000);
					
					//Click ON Finish in Configure OS Collection
					repo.ExceptionMessageBoxForm.btnMSYesInfo.WaitForExists(120000);
					repo.ExceptionMessageBoxForm.btnMSYes.ClickThis();
					
					//Click ON Apply Button IN Manage Servers
					repo.ManageServersDialog.btnApplyInfo.WaitForExists(120000);
					repo.ManageServersDialog.btnApply.ClickThis();
					
					//Click ON Ok Button IN Manage Servers
					repo.ManageServersDialog.btnMSOkInfo.WaitForExists(120000);
					
					//repo.ManageServersDialog.btnMSOk.Enabled= true
					repo.ManageServersDialog.btnMSOk.ClickThis();
					
					//Click On StartConsole If it is Present
					if (repo.GettingStartWindow.btnGSWStartConsoleInfo.Exists())
					{
						repo.GettingStartWindow.btnGSWStartConsole.ClickThis();
					}
					
					Common.WaitForSync(90000);
					Reports.ReportLog("Successfully Added Server Instance: " + serverName, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : StepsAddServer :" + ex.Message);
			}	
		}
		
		public static void VerifyFieldsAreEditable()
		{
			if(repo.GroomingOptionWindow.GroomingOnceDailyAt.Enabled.Equals(true))
				Reports.ReportLog("GroomingOnceDailyAt and baseline is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("GroomingOnceDailyAt is Not Enabled", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.GroomingOnceDailyAtInfo, "Enabled", "true");
			}
			
			if(repo.GroomingOptionWindow.AggregaionOnceDailyAt.Enabled.Equals(true))
				Reports.ReportLog("AggregaionOnceDailyAt and baseline is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("AggregaionOnceDailyAt is Not Enabled", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.AggregaionOnceDailyAtInfo, "Enabled", "true");
			}
			
			if(repo.GroomingOptionWindow.GroomStandardMetrixAndBaseline.Enabled.Equals(true))
				Reports.ReportLog("Groom standard Metrics and baseline is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("Groom standard Metrics and baseline is Not Enabled", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.GroomStandardMetrixAndBaselineInfo, "Enabled", "true");
			}
			
			
			if(repo.GroomingOptionWindow.GroomSessionsQueries.Enabled.Equals(true))
				Reports.ReportLog("Groom Sessions Queries is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("Groom Sessions Queries is Not Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.GroomSessionsQueriesInfo, "Enabled", "true");
			}
			
			if(repo.GroomingOptionWindow.GroomInactiveAlert.Enabled.Equals(true))
				Reports.ReportLog("Groom Inactive Alert is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("Groom Inactive Alert is Not Enabled", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.GroomInactiveAlertInfo,  "Enabled", "true");
			}
			
			if(repo.GroomingOptionWindow.AggregateQueryDataInto.Enabled.Equals(true))
				Reports.ReportLog("Aggregate Query Data Into is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("Aggregate Query Data Into is Not Enabled", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.AggregateQueryDataIntoInfo, "Enabled", "true");
			}
			
			if(repo.GroomingOptionWindow.GroomChangeLog.Enabled.Equals(true))
				Reports.ReportLog("GroomChangeLog is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("GroomChangeLog is Not Enabled", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.GroomChangeLogInfo, "Enabled", "true");
			}

			if(repo.GroomingOptionWindow.GroomPrescriptiveAnalysis.Enabled.Equals(true))
				Reports.ReportLog("GroomPrescriptiveAnalysis is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("GroomPrescriptiveAnalysis is Not Enabled", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.GroomPrescriptiveAnalysisInfo, "Enabled", "true");
			}
			
			if(repo.GroomingOptionWindow.AggregateTextbox.Enabled.Equals(true))
				Reports.ReportLog("Aggregate Forcasting data is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("Aggregate Forcasting data is Not Enabled", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.AggregateTextboxInfo, "Enabled", "true");
			}
			
			if(repo.GroomingOptionWindow.GroomForecastTextbox.Enabled.Equals(true))
				Reports.ReportLog("Groom Forecasting is Enabled", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
			else
			{
				Reports.ReportLog("Groom Forecasting is Not Enabled", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
				Validate.AttributeNotEqual(repo.GroomingOptionWindow.GroomForecastTextboxInfo, "Enabled", "true");
			}
		}
		public static void VerifyDefaultMetricsDataAs90Days()
		{
			try
			{
				repo.GroomingOptionWindow.SelfInfo.WaitForExists(new Duration(MaxSyncWaitTime));
				
				Validate.AttributeContains(repo.GroomingOptionWindow.GroomStandardMetrixAndBaselineInfo, "Text", "90");
				
				if (repo.GroomingOptionWindow.GroomStandardMetrixAndBaseline.TextValue.Equals("90") )
					Reports.ReportLog("Groom standard Metrics and baseline Data is Displaying : " + repo.GroomingOptionWindow.GroomStandardMetrixAndBaseline.TextValue, Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
				else
					Reports.ReportLog("Groom standard Metrics and baseline Data is Displaying : ", Reports.SQLdmReportLevel.Info, null, Config.TestCaseName);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed : VerifyDefaultMetricsDataAs90Days :" + ex.Message);
			}
		}
		
	}
}
