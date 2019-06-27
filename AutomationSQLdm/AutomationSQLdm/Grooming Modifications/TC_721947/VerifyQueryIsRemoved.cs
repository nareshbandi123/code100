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

namespace AutomationSQLdm.Grooming_Modifications.TC_721947
{
    
    [TestModule("3234D829-E982-4430-9101-18A9A2D56565", ModuleType.UserCode, 1)]
    public class VerifyQueryIsRemoved : Base.BaseClass, ITestModule
    {
        
        public VerifyQueryIsRemoved()
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
        		Steps.ClickOnTools();
        		Steps.SelectGroomingOption();
        		Steps.VerifyQueryIsRemovedFromText();
        		Steps.ClickOnCancel();
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
