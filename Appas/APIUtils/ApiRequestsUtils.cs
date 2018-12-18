using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Appas.Request_Models;
using Newtonsoft.Json;

namespace Appas.APIUtils
{
    class ApiRequestsUtils
    {
        public static async System.Threading.Tasks.Task<int> RegistratePersonAsync(string Username, byte[] image)
        {
            HttpClient client = new HttpClient();

            string uri = $"{AppSettings.Uri}api/registration";

            RegistrationRequest person = new RegistrationRequest() {Username = Username, image = image };

            StringContent queryString = null;
            try
            {
                queryString = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
            }
            catch (Exception e)
            {
                return e.HResult;
            }

            HttpResponseMessage response;

            response = await client.PostAsync(uri, queryString);

            string contentString = await response.Content.ReadAsStringAsync();

            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                var resp = JsonConvert.DeserializeObject<int>(contentString, jsonSerializerSettings);

                return resp;
            }
            catch (Exception e)
            {

                return e.HResult;
            }

        }

        public static async System.Threading.Tasks.Task<string> GetPersonAsync(int id)
        {
            HttpClient client = new HttpClient();
            string uri = $"{AppSettings.Uri}api/getperson/{id}";

            HttpResponseMessage response;

            response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var jsonSerializerSettings = new JsonSerializerSettings();
                    jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                    var resp = JsonConvert.DeserializeObject<string>(contentString, jsonSerializerSettings);

                    return resp;
                }
                catch (Exception e)
                {

                    return null;
                }
            }
            else { return null; }
        }

        #region upvotes
        public static async System.Threading.Tasks.Task<bool> AddUpvoteAsync(int id)
        {
            HttpClient client = new HttpClient();
            string uri = $"{AppSettings.Uri}api/upvote";

            StringContent queryString = null;
            try
            {
                queryString = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            }
            catch (Exception e)
            {
                return false;
            }

            HttpResponseMessage response;

            response = await client.PutAsync(uri, queryString);

            string contentString = await response.Content.ReadAsStringAsync();

            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                var resp = JsonConvert.DeserializeObject<bool>(contentString, jsonSerializerSettings);

                return resp;
            }
            catch (Exception e)
            {

                return false;
            }

        }

        public static async System.Threading.Tasks.Task<int> GetUpvotesAsync(int id)
        {
            HttpClient client = new HttpClient();
            string uri = $"{AppSettings.Uri}api/upvote/{id}";

            HttpResponseMessage response;

            response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();

            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                var resp = JsonConvert.DeserializeObject<int>(contentString, jsonSerializerSettings);

                return resp;
            }
            catch (Exception e)
            {

                return e.HResult;
            }
        }

        #endregion

        public static async System.Threading.Tasks.Task<bool> AddWhoSawWhoAsync(int WhoSawID, int WasSeenID, string date)
        {
            HttpClient client = new HttpClient();

            string uri = $"{AppSettings.Uri}api/whosawwho";

            WhoSawWhoRequest model = new WhoSawWhoRequest() { WhoSawID = WhoSawID, WasSeenID = WasSeenID, Date = date };

            StringContent queryString = null;
            try
            {
                queryString = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                Console.WriteLine("*********00******************22222222222222222222222222222222222222222*********************************************88***" + queryString);

            }
            catch (Exception e)
            {
                Console.WriteLine("*********00******************999999999999999999999999999999999999**********************************************88*** -1");
                return false;
            }

            HttpResponseMessage response;

            response = await client.PostAsync(uri, queryString);

            string contentString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("*********00******************43333333333333333333333333333333333333333333333333*********************************************88***" + contentString);
            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                var resp = JsonConvert.DeserializeObject<bool>(contentString, jsonSerializerSettings);

                Console.WriteLine("*********00********************************************************************************************88***" + resp);
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine("*********00***************************55555555555555555555555555555555555*************************************88***");
                return false;
            }
        }

        public static async System.Threading.Tasks.Task<List<HistoryModel>> GetLatestHistoryAsync(int id)
        {
            HttpClient client = new HttpClient();
            string uri = $"{AppSettings.Uri}api/whosawwhodefault/{id}";

            HttpResponseMessage response;

            response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();

            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                var resp = JsonConvert.DeserializeObject<List<HistoryModel>>(contentString, jsonSerializerSettings);

                return resp;
            }
            catch (Exception e)
            {

                return null;
            }
        }

    }
}