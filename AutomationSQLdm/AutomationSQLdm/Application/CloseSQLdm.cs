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

using AutomationSQLdm.Extensions;
using AutomationSQLdm.Configuration;

namespace AutomationSQLdm.Application
{
 
    [TestModule("0FE8941E-6526-477A-BC6F-CB90C434E430", ModuleType.UserCode, 1)]
    public class CloseSQLdm : Base.BaseClass, ITestModule
    {
        AppRepo repo = AppRepo.Instance;
        public CloseSQLdm()
        {
           
        }

        void ITestModule.Run()
        {
            StartProcess();
        }
        
        bool StartProcess()
        {
        	try 
        	{
        		Ranorex.Host.Local.CloseSQLdm();
//        		repo.ConfirmWindow.ConfirmExitButtonInfo.WaitForExists(Commons.Common.ApplicationOpenWaitTime);
//        		repo.ConfirmWindow.ConfirmExitButton.ClickThis();
//        		repo.Application.SelfInfo.WaitForNotExists(Commons.Common.ApplicationOpenWaitTime);
        		Reports.ReportLog("SQLdm Application Close", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
        	} 
        	catch (Exception ex) 
        	{
        		StartProcess();
        		Reports.ReportLog(ex.Message.ToString(), Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        		return false;
        	}
        	return true;
        }
    }
}
