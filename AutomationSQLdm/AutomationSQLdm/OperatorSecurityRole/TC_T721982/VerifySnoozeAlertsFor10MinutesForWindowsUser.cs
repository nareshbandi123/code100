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

namespace AutomationSQLdm.OperatorSecurityRole.TC_T721982
{
    /// <summary>
    /// Description of VerifyUserWithViewdataAckAlarmsIsAbleToSnoozeAlerts.
    /// </summary>
    [TestModule("4BB73B19-A411-466E-8B32-B36229059E3C", ModuleType.UserCode, 1)]
    public class VerifySnoozeAlertsFor10MinutesForWindowsUser : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifySnoozeAlertsFor10MinutesForWindowsUser()
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
        	  Steps.EnterDomianUserName(Config.NewWindowsUser);
        	  Steps.ClickNextButton();
        	  Steps.ClickOptionBtn_ViewDataAcknowledgwAlarm();
        	  Steps.ClickNextButton();
        	  Steps.SelectServers();
        	  Steps.ClickAddButton();
        	  Steps.ClickNextButton();
        	  Steps.ClickFinishButton();
			  Steps.VerifyUserAdded(Config.NewWindowsUser);
        	  Steps.ClickServersInLeftPane();
			  Steps.RightClickMonitoredServer();
        	  Steps.ClickSnoozeAlertContextMenu();
        	  Steps.SetSnoozeAlertTime();
        	  Steps.VerifyServerSnoozed();
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
        	    Steps.DeleteAddedUser();
        	}
        	return true;
        }
        
      
    }
}
