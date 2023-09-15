using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace TestAutomation
{
	public class Configurations
	{
        string GitHubUser { get; set; }

        string BranchName { get; set; }

        public string JenkinsApiToken { get; set; }

        public string URL { get; set; }

        public string JenkinsUser { get; set; }

		public string Username { get; set; }

        public string Password { get; set; }

        string JenkinsJobName { get; set; }

        public Configurations()
		{

            /*
             * To run test cases locally set below value to false. but makesure push it to the branch 
             * you should change back to true. the variable "BranchName" value need to be change accordingly.
             * */

            if (true)
                LoadSeetingsForGitHubAction();
            else
                LoadSeetingsForLocalRun();



            // CheckBuildStatus();

            // TriggerJenkinsJob();

            // CheckBuildStatus();

        }

		void LoadSeetingsForGitHubAction()
        {

            GitHubUser = Environment.GetEnvironmentVariable("username");
            BranchName = Environment.GetEnvironmentVariable("branch");
            JenkinsApiToken = Environment.GetEnvironmentVariable($"{GitHubUser.ToUpper()}_JENKINS_API_TOKEN");
            URL = Environment.GetEnvironmentVariable("WATI_AUTOMATION_NONTRIAL_ENV_URL");
            JenkinsUser = Environment.GetEnvironmentVariable($"{GitHubUser.ToUpper()}_JENKINS_USER");
            Username = Environment.GetEnvironmentVariable("WATI_AUTOMATION_ENV_USERNAME");
            Password = Environment.GetEnvironmentVariable("WATI_AUTOMATION_ENV_PASSWORD");
            JenkinsJobName = Environment.GetEnvironmentVariable($"{GitHubUser.ToUpper()}_JENKINS_DEPLOYMENT_JOB_NAME");
        }

      void LoadSeetingsForLocalRun()
        {
            GitHubUser = "dubeywati";
            BranchName = "master";
            JenkinsApiToken = "111189db382717f939012be0b4b14dfa72";
            URL = "https://live-300005.watiapp.io/";
            JenkinsUser = "abhishek";
            Username = "abhishek@clare.ai";
            Password = "Abhishek@1";
            JenkinsJobName = "wati";
        }


        public void TriggerJenkinsJob()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"https://ci.clare.ai/job/{JenkinsJobName}/buildWithParameters?token=apiToken"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{JenkinsUser}:{JenkinsApiToken}"));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    var multipartContent = new MultipartFormDataContent();
                    multipartContent.Add(new StringContent($"{BranchName}"), "BUILD_BRANCH");
                    request.Content = multipartContent;

                    var response = httpClient.Send(request);
                }
            }
        }

        public void CheckBuildStatus()
        {
            Task.Delay(30000).Wait();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://ci.clare.ai/job/{JenkinsJobName}/lastBuild/api/json"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{JenkinsUser}:{JenkinsApiToken}"));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    var response = httpClient.Send(request);
                    var jsonResult = JObject.Parse(response.Content.ReadAsStringAsync().Result ?? "");
                    var status = jsonResult["result"].ToString();
                    if (status == "")
                    {
                        Task.Delay(30000).Wait();
                        CheckBuildStatus();
                    }
                }
            }
        }



    }
}
