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

namespace AutomationSQLdm.OperatorSecurityRole.TC_T721981
{
    /// <summary>
    /// Description of VerifySnoozeAlertsForUserWithViewDataAcknowledgeAlarms.
    /// </summary>
    [TestModule("F30DD081-D3D3-4CAD-A667-CE95C221E53A", ModuleType.UserCode, 1)]
    public class VerifySnoozeAlertsForFewMinutesForWindowsUser : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifySnoozeAlertsForFewMinutesForWindowsUser()
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
			  AutomationSQLdm.Grooming_Modifications.Steps.ClickOnTools();
        	  Steps.SelectSnoozeAlertMenuItem();
        	  Steps.SetSnoozeAlertTime();
        	  AutomationSQLdm.Grooming_Modifications.Steps.ClickOnTools();
        	  Steps.VerifySnoozeAlertApplied();
        	  Steps.ResumeAlertMenuItem();
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
