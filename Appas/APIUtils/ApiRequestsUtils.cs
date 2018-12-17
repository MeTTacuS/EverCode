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
        public async System.Threading.Tasks.Task<bool> RegistratePersonAsync (int ID, string Username, byte[] image)
        {
            HttpClient client = new HttpClient();

            string uri = $"{AppSettings.Uri}/api/registration";

            RegistrationRequest person = new RegistrationRequest() {ID=ID, Username = Username, image=image };

            StringContent queryString = null;
            try
            {
                queryString = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
            }
            catch (Exception e)
            {
                return false;
            }

            HttpResponseMessage response;

            response = await client.PostAsync(uri, queryString);

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

        public async System.Threading.Tasks.Task<string> GetPersonAsync(int id)
        {
            HttpClient client = new HttpClient();
            string uri = $"{AppSettings.Uri}/api/getperson/{id}";

            StringContent queryString = null;
            try
            {
                queryString = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            }
            catch (Exception e)
            {
                return null;
            }

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

    }
}