using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AutomationSQLdm.Configuration;
using System.Configuration;

namespace AutomationSQLdm.TestRailAPI
{
	public class Rail
	{
		public Rail(){}
		
		string url = ConfigurationManager.AppSettings["TESTRAIL_API"].ToString();
		string UserName = ConfigurationManager.AppSettings["USER_NAME"].ToString();
		string pass = ConfigurationManager.AppSettings["PASSWORD"].ToString();
		
		string projectId = ConfigurationManager.AppSettings["PROJECT_ID"].ToString();
		string suiteId = ConfigurationManager.AppSettings["SUITE_ID"].ToString();
		string runId = ConfigurationManager.AppSettings["RUN_ID"].ToString();
		
		bool isTRailEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["TESTRAIL_ENABLED"].ToString());
		
		public void UpdateCaseStatus(int statusId, string caseId)
		{
			APIClient client = new APIClient(url);
			client.User = UserName;
			client.Password = pass;
			
			var data = new Dictionary<string, object>
			{
				{ "status_id", statusId }
			};
			
			if(isTRailEnabled) 
			{
				JObject result = (JObject) client.SendPost(string.Format("add_result_for_case/{0}/{1}", runId, caseId), data);
			}
		}
		
		public void AddRun()
		{
			APIClient client = new APIClient(url);
			client.User = UserName;
			client.Password = pass;
			
			var data = new Dictionary<string, object>
			{
				{ "suite_id", suiteId },
				{ "name", "Automation_SQLDM : " + DateTime.UtcNow}
			};
			
			if(isTRailEnabled) 
			{
			
				JObject result = (JObject) client.SendPost(string.Format("add_run/{0}", projectId), data);
				
				if(result != null && result["id"] != null)
				{
					string value= result["id"].ToString();
					var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
	        		var settings = configFile.AppSettings.Settings;
	        		settings["RUN_ID"].Value = value;
	            	configFile.Save(ConfigurationSaveMode.Modified);
	        		ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
				}
			}
			
			string runId = ConfigurationManager.AppSettings["RUN_ID"].ToString();
		}
		
		public void GetRunId()
		{
			APIClient client = new APIClient(url);
			client.User = UserName;
			client.Password = pass;
			
			var data = new Dictionary<string, object>
			{
				{ "suite_id", suiteId }
			};
			
			if(isTRailEnabled) 
			{
				JArray result = (JArray) client.SendGet(string.Format("get_runs/{0}&suite_id={1}&limit=1", projectId,suiteId));
				
				if(result != null && result[0] != null)
				{
					string value= result[0].SelectToken("id").ToString();
					var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
	        		var settings = configFile.AppSettings.Settings;
	        		settings["RUN_ID"].Value = value;
	            	configFile.Save(ConfigurationSaveMode.Modified);
	        		ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
				}
			}
			string runId = ConfigurationManager.AppSettings["RUN_ID"].ToString();
		}
		
		public IList<Case> GetCases()
		{
			APIClient client = new APIClient(url);
			client.User = UserName;
			client.Password = pass;
			
			var data = new Dictionary<string, object>
			{
				{ "suite_id", suiteId }
			};
			
			if(isTRailEnabled) 
			{
				JArray result = (JArray) client.SendGet(string.Format("get_cases/{0}&suite_id={1}", projectId,suiteId));
				
				if(result != null && result[0] != null)
					return result.ToObject<IList<Case>>();
			}
			return null;
		}
	}
	
	public class Case
	{
		[JsonProperty(PropertyName = "id")]
		public string TestCaseId {get; set;}
		
		[JsonProperty(PropertyName = "title")]
		public string TestCaseName {get;set;}
	}
}
