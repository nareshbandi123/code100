using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AutomationSQLdm.TestRailAPI
{
	public class APIClient
	{
		private string m_user;
		private string m_password;
		private string m_url;

		public APIClient(string base_url)
		{
			if (!base_url.EndsWith("/"))
			{
				base_url += "/";
			}

			this.m_url = base_url + "index.php?/api/v2/";
		}

		public string User
		{
			get { return this.m_user; }
			set { this.m_user = value; }
		}

		public string Password
		{
			get { return this.m_password; }
			set { this.m_password = value; }
		}

		public object SendGet(string uri)
		{
			string url = m_url + uri;
			return SendRequest("GET", url, null);
		}

		public object SendPost(string uri, object data)
		{
			string url = m_url + uri;
			return SendRequest("POST", url, data);
		}

		private object SendRequest(string method, string uri, object data)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.ContentType = "application/json";
			request.Method = method;

			string auth = Convert.ToBase64String(
				Encoding.ASCII.GetBytes(
					String.Format(
						"{0}:{1}",
						this.m_user,
						this.m_password
					)
				)
			);

			request.Headers.Add("Authorization", "Basic " + auth);

			if (method == "POST")
			{
				if (data != null)
				{
					byte[] block = Encoding.UTF8.GetBytes( 
						JsonConvert.SerializeObject(data)
					);

					request.GetRequestStream().Write(block, 0, block.Length);
				}
			}

			Exception ex = null;
			HttpWebResponse response = null;
			try
			{
				response = (HttpWebResponse)request.GetResponse();
			}
			catch (WebException e)
			{
				if (e.Response == null)
				{
					throw;
				}

				response = (HttpWebResponse)e.Response;
				ex = e;
			}

			string text = "";
			if (response != null)
			{
				var reader = new StreamReader(
					response.GetResponseStream(),
					Encoding.UTF8
				);

				using (reader)
				{
					text = reader.ReadToEnd();
				}
			}

			JContainer result;
			if (text != "")
			{
				if (text.StartsWith("["))
				{
					result = JArray.Parse(text);
				}
				else 
				{
					result = JObject.Parse(text);
				}
			}
			else 
			{
				result = new JObject();
			}

			if (ex != null)
			{
				string error = (string) result["error"];
				if (error != null)
				{
					error = '"' + error + '"';
				}
				else
				{
					error = "No additional error message received";
				}

				throw new APIException(
					String.Format(
						"TestRail API returned HTTP {0} ({1})",
						(int)response.StatusCode,
						error
					)
				);
			}

			return result;
		}
	}
}
