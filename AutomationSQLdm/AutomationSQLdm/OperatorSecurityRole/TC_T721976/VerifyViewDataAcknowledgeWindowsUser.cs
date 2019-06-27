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

namespace AutomationSQLdm.OperatorSecurityRole.TC_T721976
{
    /// <summary>
    /// Description of AvailabilityOfViewDataAcknowledgeAlarmsWindowsUserscreen.
    /// </summary>
    [TestModule("D2BAFE2F-10CB-45F8-878D-838B021B2D88", ModuleType.UserCode, 1)]
    public class VerifyViewDataAcknowledgeWindowsUser : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyViewDataAcknowledgeWindowsUser()
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
        	  Steps.VerifyViewDataAcknowledgwAlarmIsSelected(SQDLDMConstants.WindowsUser); 
        	  Steps.ClickCancelPermissionProperties();
        	  Steps.DeleteAddedUser();
        	  Common.UpdateStatus(1); // 1 : Pass
        	} 
        	catch (Exception ex)
        	{
        		Common.UpdateStatus(5); // 5 : fail
        		Validate.Fail(ex.Message);
        	}
        	return true;
        }
    }
}
