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

namespace AutomationSQLdm.OperatorSecurityRole.TC_T721974
{
    /// <summary>
    /// Description of AddingWindowsUserToSecurityRole.
    /// </summary>
    [TestModule("3E8ECE01-3F23-48DE-947E-37F88504D5CF", ModuleType.UserCode, 1)]
    public class AddingWindowsUserToSecurityRole : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddingWindowsUserToSecurityRole()
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
