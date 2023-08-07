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



            //CheckBuildStatus();

            //TriggerJenkinsJob();

            //CheckBuildStatus();

        }

        void LoadSeetingsForGitHubAction()
        {

            GitHubUser = Environment.GetEnvironmentVariable("USERNAME");
            BranchName = Environment.GetEnvironmentVariable("BRANCH");
            JenkinsApiToken = Environment.GetEnvironmentVariable($"{GitHubUser.ToUpper()}_JENKINS_API_TOKEN");
            URL = Environment.GetEnvironmentVariable($"{GitHubUser.ToUpper()}_DEV_URL");
            JenkinsUser = Environment.GetEnvironmentVariable($"{GitHubUser.ToUpper()}_JENKINS_USER");
            Username = Environment.GetEnvironmentVariable($"{GitHubUser.ToUpper()}_DEV_USERNAME");
            Password = Environment.GetEnvironmentVariable($"{GitHubUser.ToUpper()}_DEV_PASSWORD");
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
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"http://localhost:8080/job/{JenkinsJobName}/buildWithParameters?token=apiToken"))
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

        //public void TriggerJenkinsJob()
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        try
        //        {
        //            var jenkinsUrl = "http://localhost:8080"; // Replace with the remote Jenkins server URL
        //            var apiEndpoint = $"{jenkinsUrl}/job/{JenkinsJobName}/buildWithParameters?token=apiToken";

        //            var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{JenkinsUser}:{JenkinsApiToken}"));
        //            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

        //            var multipartContent = new MultipartFormDataContent();
        //            multipartContent.Add(new StringContent($"{BranchName}"), "BUILD_BRANCH");
        //            var response = httpClient.PostAsync(apiEndpoint, multipartContent).GetAwaiter().GetResult();

        //            if (response.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine("Jenkins job triggered successfully.");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Failed to trigger Jenkins job. Status code: {response.StatusCode}");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"An error occurred: {ex.Message}");
        //        }
        //    }
        //}

        public void CheckBuildStatus()
        {
            Task.Delay(30000).Wait();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"http://localhost:8080/job/{JenkinsJobName}/lastBuild/api/json"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{JenkinsUser}:{JenkinsApiToken}"));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    var response = httpClient.Send(request);
                    var jsonResult = JObject.Parse(response.Content.ReadAsStringAsync().Result ?? "");
                    var status = jsonResult["result"]?.ToString();
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






