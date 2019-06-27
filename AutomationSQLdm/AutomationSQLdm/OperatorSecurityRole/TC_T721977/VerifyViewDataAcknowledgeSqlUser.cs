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

namespace AutomationSQLdm.OperatorSecurityRole.TC_T721977
{
    /// <summary>
    /// Description of VerifyViewDataAcknowledgeSqlUser.
    /// </summary>
    [TestModule("CD95E968-A9BF-4E2B-8ECE-C2DE3E5A6109", ModuleType.UserCode, 1)]   
    public class VerifyViewDataAcknowledgeSqlUser : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyViewDataAcknowledgeSqlUser()
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
        	  Steps.VerifyViewDataAcknowledgwAlarmIsSelected(SQDLDMConstants.SqlUser);
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
