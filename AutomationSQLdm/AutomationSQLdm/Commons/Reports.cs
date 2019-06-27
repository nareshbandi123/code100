
using System;
using AutomationSQLdm.Base;
using AutomationSQLdm.Commons;
using AutomationSQLdm.Configuration;
using AutomationSQLdm.Extensions;


namespace AutomationSQLdm.Commons
{
  
    public static class Reports 
    {
    
       public static void ReportLog(string log, SQLdmReportLevel reportlevel, Ranorex.Core.Element element, string category)
        {
			System.Threading.Thread.Sleep(200);
        	switch (reportlevel) 
        	{
        		case SQLdmReportLevel.Fail:
					Ranorex.Report.Failure(category, log);
        			Ranorex.Report.Screenshot(element);
        			break;
    			case SQLdmReportLevel.Info:
	    			Ranorex.Report.Info(category, log);        			
	    			break;
    			case SQLdmReportLevel.Success:
	    			Ranorex.Report.Success(category, log);        			
	    			break;
        		default:        			
        			break;
        	}
        	System.Threading.Thread.Sleep(200);
        } 

		public enum SQLdmReportLevel
		{
        	Success = 1,
        	Fail = 2,
        	Info = 3
        }
    }
}
