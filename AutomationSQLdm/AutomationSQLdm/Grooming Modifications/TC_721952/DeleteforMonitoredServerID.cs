
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

namespace AutomationSQLdm.Grooming_Modifications.TC_721952
{
    
    [TestModule("A99B8D48-8CE4-4DC1-8071-6850FC9AB5C2", ModuleType.UserCode, 1)]
    public class DeleteforMonitoredServerID :Base.BaseClass, ITestModule
    {
        
        public DeleteforMonitoredServerID()
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
        		string ServerID = "";
				Steps.AddSQLServerInstance(Config.ServerOptions_FORDELETE);
				Steps.VerifyQueryDataCount(Config.Query_MonitoredSQLServers,"MonitoredSQLServers");
				Steps.GetMonitoredServerID("select SQLServerID from MonitoredSQLServers where InstanceName =" + "'" + Config.ServerOptions_FORDELETE +"'",ref ServerID);
				Steps.DeleteSQLServerInstance(Config.ServerOptions_FORDELETE);
				Steps.VerifyInstanceIsDeleted("select * from AnalysisConfiguration where MonitoredServerID = " + ServerID,"AnalysisConfiguration");
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
