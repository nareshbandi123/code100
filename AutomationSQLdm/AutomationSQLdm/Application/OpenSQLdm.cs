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
using AutomationSQLdm.Extensions;

namespace AutomationSQLdm.Application
{
    
    [TestModule("F749EA84-58C0-4B06-B370-33030D553C6D", ModuleType.UserCode, 1)]
    public class OpenSQLdm : Base.BaseClass, ITestModule
    {
        AppRepo repo = AppRepo.Instance;
        
        public OpenSQLdm()
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
        		Ranorex.Host.Local.OpenSQLdm();
        		repo.IderaSQLdmRepo.SelfInfo.WaitForItemExists(Commons.Common.ApplicationOpenWaitTime);
        		Common.WaitForSync(30000);
        		//repo.IderaSQLdmRepo.imgSQLdiagnosticManagerInfo.WaitForItemExists(Commons.Common.ApplicationOpenWaitTime);
        		Reports.ReportLog("SQLdm Application Open", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
        		
        		//repo.IderaSQLdmRepo.SelfInfo.WaitForItemExists(Commons.Common.ApplicationOpenWaitTime);
        		
//        		if (repo.IderaSQLdmRepo.imgSQLdiagnosticManager.Visible == true)
//        		{
//					Reports.ReportLog("SQLdm Application Open", Reports.SQLdmReportLevel.Success, null, Config.TestCaseName);
//        		}
//        		else
//        		{
//        			//Common.WaitForSync(120000);
//        			//Reports.ReportLog("SQLdm Application Open", Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
//        		}
        	} 
        	catch (Exception ex) 
        	{
        		Reports.ReportLog(ex.Message, Reports.SQLdmReportLevel.Fail, null, Config.TestCaseName);
        		return false;
        	}
        	return true;
        }
      
    }
}
