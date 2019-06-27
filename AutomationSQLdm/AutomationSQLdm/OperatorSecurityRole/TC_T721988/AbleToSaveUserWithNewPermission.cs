using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using WinForms = System.Windows.Forms;
using AutomationSQLdm.Base;
using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using SQDLDMConstants = AutomationSQLdm.Commons.Constants; 


namespace AutomationSQLdm.OperatorSecurityRole.TC_T721988
{
    /// <summary>
    /// Description of AbleToSaveUserWithNewPermission.
    /// </summary>
    [TestModule("7539C170-42ED-4C80-85E6-9F46BEDD0342", ModuleType.UserCode, 1)]
    public class VerifySnoozeAlertsForFewMinutesForSqlUser : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifySnoozeAlertsForFewMinutesForSqlUser()
        {
            // Do not delete - a parameterless constructor is required!
        }

       void ITestModule.Run()
        {
         	StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        	  Common.ClickStartConsole();
        	  Common.ConnectDMRepoWindowsUser();
        	  Steps.ClickAdministration();
        	  Steps.ClickApplicationSecurity();
        	  Steps.ClickToAddUsers();
        	  Steps.ClickNextButton();
        	  Steps.EnterDomianUserName(Config.NewSqlUser);
        	  Steps.SelectSqlAuthentication();
        	  Steps.ClickNextButton();
        	  Steps.ClickOptionBtn_ViewDataAcknowledgwAlarm();
        	  Steps.ClickNextButton();
        	  Steps.SelectServers();
        	  Steps.ClickAddButton();
        	  Steps.ClickNextButton();
        	  Steps.ClickFinishButton();
			  Steps.VerifyUserAdded(Config.NewSqlUser);
        	  Steps.ChangePermission(SQDLDMConstants.SqlUser);
        	  Steps.VerifyPermissionChanged();
        	  Steps.DeleteAddedUser();
        	  Common.UpdateStatus(1); // 1 : Pass
        	} 
        	catch (Exception ex)
        	{
        		Common.UpdateStatus(5); // 5 : fail
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	
        	return true;
        }
    }
}



