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
using SQDLDMConstants = AutomationSQLdm.Commons.Constants; 

namespace AutomationSQLdm.OperatorSecurityRole.TC_T721992
{
    /// <summary>
    /// Description of VerifySnoozeAlertsForFewMinutesForSqlUser.
    /// </summary>
    [TestModule("C5A4B559-5C5D-464D-949B-3B25D8E8963C", ModuleType.UserCode, 1)]
    public class VerifySnoozeAlertsForFewMinutesForSqlUser :BaseClass, ITestModule
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
        	  Steps.ClickServersInLeftPane();
        	  Steps.RightClickTag();
        	  Steps.ClickSnoozeAlertContextMenu();
        	  Steps.SetSnoozeAlertTime();
        	  Steps.VerifyAllServerSnoozed(SQDLDMConstants.tagSnoozeAlert);
        	  Steps.ClickResumeAlertContextMenu();
			 
        	  Common.UpdateStatus(1); // 1 : Pass
        	} 
        	catch (Exception ex)
        	{
        		Common.UpdateStatus(5); // 5 : fail
        		Validate.Fail(ex.Message);
        	}
        	finally
        	{
        		Steps.ClickAdministration();
        		//Steps.ClickSqlUserToDelete();
        	    Steps.DeleteAddedUser();
        	}
        	return true;
        }
    }
}
