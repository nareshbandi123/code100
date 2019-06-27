using System;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Reporting;
using Ranorex.Core.Testing;
using System.Configuration;
using AutomationSQLdm.TestRailAPI;

namespace AutomationSQLdm
{
    class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            // Uncomment the following 2 lines if you want to automate Windows apps
            // by starting the test executable directly
            //if (Util.IsRestartRequiredForWinAppAccess)
            //    return Util.RestartWithUiAccess();

            Keyboard.AbortKey = System.Windows.Forms.Keys.Pause;
            int error = 0;

            try
            {
            	
            	ConfigureTestRail();
            	
            	
                error = TestSuiteRunner.Run(typeof(Program), Environment.CommandLine);
            }
            catch (Exception e)
            {
                Report.Error("Unexpected exception occurred: " + e.ToString());
                error = -1;
            }
            return error;
        }
        
        
        static void ConfigureTestRail()
        {
        	Rail rail = new Rail();
        	string runId = ConfigurationManager.AppSettings["RUN_ID"].ToString();
        	string isTRailEnabled = ConfigurationManager.AppSettings["TESTRAIL_ENABLED"].ToString();
        	string isGenerateRunID = ConfigurationManager.AppSettings["GENERATE_RUN"].ToString();
        	
        	if(isTRailEnabled.ToLower() == "true")
        	{
        		if(string.IsNullOrEmpty(runId) && isGenerateRunID.ToLower() == "true")
	        	{
        			rail.AddRun();
	        	}
        		else if(string.IsNullOrEmpty(runId) && isGenerateRunID.ToLower() == "false")
	        	{
        			rail.GetRunId();
	        	}
        		else if (!string.IsNullOrEmpty(runId)) 
        		{
        			// do nothing
        		}
        	}
        }
    }
}
