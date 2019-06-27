
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
using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;


namespace AutomationSQLdm.BVT.TC_722162
{
    
    [TestModule("F6E5CFA3-A02F-427C-BDDB-4185A3D272F4", ModuleType.UserCode, 1)]
    public class VerifySQLdmToday : ITestModule
    {
        
        public VerifySQLdmToday()
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
        		
        		Steps.VerifySQLdmToday();
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
