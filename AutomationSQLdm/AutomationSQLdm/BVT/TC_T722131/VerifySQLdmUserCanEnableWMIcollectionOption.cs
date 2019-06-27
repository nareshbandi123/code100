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
using AutomationSQLdm.OperatorSecurityRole;
using AutomationSQLdm.Configuration;

namespace AutomationSQLdm.BVT.TC_T722131
{
    /// <summary>
    /// Description of VerifySQLdmUserCanEnableWMIcollectionOption.
    /// </summary>
    [TestModule("F7A1C105-66CA-4582-A174-11B938AE4E0A", ModuleType.UserCode, 1)]
    
    
    public class VerifySQLdmUserCanEnableWMIcollectionOption : BaseClass, ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifySQLdmUserCanEnableWMIcollectionOption()
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
        		Common.RightClickOnServer(ServerListConstants.WIN2K12_SQL14);
        		Steps.ClickProperties();
        		Steps.ClickOSMetrix();
        		Steps.SelectOperatingSystemMetrixUsingDirectWMI();
        		Steps.SelectOptionSqldmServiceAccount();
        		Steps.EnterUsername(Config.WindowsUser);
        		Steps.EnterPassword(Config.WinUserPassword);
        		Steps.ClickTest();
        		Steps.VerifyPopupMessage();        		
        		//ToDo : Test Rail Status Pass
        		Common.UpdateStatus(1); // 1 : Pass
        	} 
        	catch (Exception ex)
        	{
        		//ToDo : Test Rail Status Fail
        		Common.UpdateStatus(5); // 5 : fail
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        	}
        	return true;
        }
        
      
    }
}
