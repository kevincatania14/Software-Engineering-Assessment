using GithubAnalyser.BusinessLogic.Helpers;
using Newtonsoft.Json;
using GithubAnalyser.Models;

namespace GithubAnalyser.BusinessLogic
{
    public class GithubAnalyser
    {
        /// <summary>
        /// Searches for Github profile
        /// </summary>
        /// <param name="username"></param>
        /// <returns>API response</returns>
        public GithubProfileCustomModel Analyse(string username)
        {
            /* optional - enabling tls */
            Security security = new Security();
            security.EnableTLS();

            /* Cannot deserialize the current JSON object ... */
            //List<GithubProfileModel> githubProfile = new List<GithubProfileModel>();
            GithubProfileCustomModel githubProfile = new GithubProfileCustomModel();

            /* fetching json from url */
            string api = "https://api.github.com/users/" + username;

            /* http request */
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "request"); /* important - including header to address error 403 */
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); /* not required */

            /* http response */
            HttpResponseMessage response = client.GetAsync(api).Result;
            if (response.IsSuccessStatusCode)
            {
                githubProfile = JsonConvert.DeserializeObject<GithubProfileCustomModel>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                githubProfile.message = username;
            }

            /* returning deserialised json object */
            //return Json(githubProfile);
            return githubProfile;
        }
    }
}