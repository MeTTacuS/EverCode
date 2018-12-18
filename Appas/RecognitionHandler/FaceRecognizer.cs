using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Widget;
using Appas;
using Appas.Model;
using Appas.RecognitionHandler;
using Newtonsoft.Json;
using PersonManager.FaceApi;
using static Appas.RecognitionHandler.FaceAddedEvent;
using static Appas.RecognitionHandler.FaceRecognizedEvent;

namespace Appas.RecognitionHandler

{
    public class FaceRecognizer
    {
        const string OcpApimSubscriptionKey = "Ocp-Apim-Subscription-Key";
        const string subscriptionKey = "f4ff0a8d3a30477ea495ad08dbb72bd1";
        const string uriBase = "https://northeurope.api.cognitive.microsoft.com/face/v1.0/";
        public event FaceRecognizedEventHandler OnRecognized;
        public event FaceAddedEventHandler OnFaceAdded;

        public async Task CreateFaceLogin(Android.Graphics.Bitmap bitmap, int userID)
        {
            try
            {
                if(GetPersonGroup(AppSettings.GroupId) == null)
                {
                    await CreatePersonGroup(AppSettings.GroupId, "people");
                }
                // Create person
                string personID = string.Empty;
                try
                {
                    personID = await GetPersonID(userID);
                }
                catch { /* person id not found */ }

                if (string.IsNullOrEmpty(personID))
                {
                     personID = await CreatePerson(userID);
                }
                // Add face
                var img = ImageToByte(bitmap);
                await AddFaceToPerson(img, personID);

                // Train group
                await TrainGroup();

                //Toast.MakeText(AuthServiceRequests.context, "Face login added succesfully", ToastLength.Long).Show();
            }
            catch (Exception)
            {
                //Toast.MakeText(AuthServiceRequests.context, "Face login addition failed", ToastLength.Long).Show();
            }
        }

        private async Task<string> GetPersonID(int userID)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string uri = uriBase + "persongroups/1/persons";

            HttpResponseMessage response;

            StringContent content = new StringContent(string.Empty);

            response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();

            List<Person> personList = null;

            try
            {
                personList = JsonConvert.DeserializeObject<List<Person>>(contentString);
            }
            catch (Exception e)
            {
                //Toast.MakeText(AuthServiceRequests.context, e.ToString(), ToastLength.Long).Show();
                return string.Empty;
            }

            string personID = personList.FirstOrDefault(p => p.name == userID.ToString()).personId;

            //Toast.MakeText(AuthServiceRequests.context, personID, ToastLength.Long).Show();

            return personID;
        }

        private static async Task<string> CreatePerson(int userID)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string uri = uriBase + $"persongroups/{AppSettings.GroupId}/persons/";

            var newPerson = new
            {
                name = userID.ToString(),
                userData = ""
            };

            StringContent queryString = null;
            try
            {
                queryString = new StringContent(JsonConvert.SerializeObject(newPerson), Encoding.UTF8, "application/json");
            }
            catch (Exception e)
            {
                //Toast.MakeText(AuthServiceRequests.context, e.ToString(), ToastLength.Long).Show();
                return null;
            }

            HttpResponseMessage response;

            response = await client.PostAsync(uri, queryString);

            string contentString = await response.Content.ReadAsStringAsync();

            //Toast.MakeText(AuthServiceRequests.context, contentString, ToastLength.Long).Show();

            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                var resp = JsonConvert.DeserializeObject<Person>(contentString, jsonSerializerSettings);

                //Toast.MakeText(AuthServiceRequests.context, resp.personId, ToastLength.Long).Show();

                return resp.personId;
            }
            catch (Exception e)
            {
                //Toast.MakeText(AuthServiceRequests.context, e.ToString(), ToastLength.Long).Show();
                return string.Empty;
            }
        }

        private async Task AddFaceToPerson(byte[]byteData, string personID)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string uri = uriBase + $"persongroups/{AppSettings.GroupId}/persons/" + personID + "/persistedFaces";


            HttpResponseMessage response;

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                response = await client.PostAsync(uri, content);

                string contentString = await response.Content.ReadAsStringAsync();

                var json = JsonPrettyPrint(contentString);

                //Toast.MakeText(AuthServiceRequests.context, json, ToastLength.Long).Show();


                //Toast.MakeText(AuthServiceRequests.context, a, ToastLength.Long).Show();


            }
        }

        private async Task TrainGroup()
        {
            //https://[location].api.cognitive.microsoft.com/face/v1.0/persongroups/{personGroupId}/train
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string uri = uriBase + $"persongroups/{AppSettings.GroupId}/train";

            HttpResponseMessage response;

            StringContent content = new StringContent(string.Empty);

            response = await client.PostAsync(uri, content);

            string contentString = await response.Content.ReadAsStringAsync();
            
        }

        public async Task RecognizeFace(Android.Graphics.Bitmap bitmap)
        {
            // detect
            var img = ImageToByte(bitmap);

            try
            {
                DetectedFace result = await Detect(img);

                string faceId =  await Identify(result.faceId);
                if(faceId == string.Empty)
                {
                    OnRecognized(this, new FaceRecognizedEventArgs(0));

                    return;
                }

                int userID = await GetUserID(faceId);

                OnRecognized(this, new FaceRecognizedEventArgs(userID));

            }
            catch (Exception e)
            {
                //Toast.MakeText(AuthServiceRequests.context, e.ToString(), ToastLength.Long).Show();
            }
        }

        private static async Task<int> GetUserID(string faceID)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string uri = uriBase + $"persongroups/{AppSettings.GroupId}/persons/" + faceID;

            HttpResponseMessage response;
            
            response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();

            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                var person = new
                {
                    name = string.Empty
                };
                var resp = JsonConvert.DeserializeObject<Person>(contentString, jsonSerializerSettings);

                int id =  Int32.Parse(resp.name.ToString());
                Console.WriteLine("*********************************************************************************************************************" + resp.name);
                //Toast.MakeText(AuthServiceRequests.context, id.ToString(), ToastLength.Long).Show();
                return id;
            }
            catch (Exception e)
            {
               // Toast.MakeText(AuthServiceRequests.context, e.ToString(), ToastLength.Long).Show();
                return 0;
            }
        }

        private static async Task<string> Identify(string faceId)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string uri = uriBase;

            HttpResponseMessage response;
            var detectedFace = new
            {
                PersonGroupId = AppSettings.GroupId,
                faceIds = new List<String>()
                 {
                     faceId
                 },
                maxNumOfCandidatesReturned = 1,
                confidenceThreshold = 0.5
            };
            StringContent queryString = null;
            try
            {
                queryString = new StringContent(JsonConvert.SerializeObject(detectedFace), Encoding.UTF8, "application/json");
            }
            catch (Exception e )
            {
                //Toast.MakeText(AuthServiceRequests.context, e.ToString(), ToastLength.Long).Show();
                return string.Empty;
            }
            response = await client.PostAsync(uri + "identify", queryString);

            string contentString = await response.Content.ReadAsStringAsync();

            //Toast.MakeText(AuthServiceRequests.context, contentString, ToastLength.Long).Show();

            List<IdentifiedFace> identifiedFace = null;

            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                identifiedFace = JsonConvert.DeserializeObject<List<IdentifiedFace>>(contentString, jsonSerializerSettings);
                return identifiedFace[0].candidates[0].personId;
            }
            catch (Exception e)
            {
                //Toast.MakeText(AuthServiceRequests.context, "Failed recognizing face", ToastLength.Long).Show();
                return string.Empty;
            }

        }
        
        static async Task<DetectedFace> Detect(byte[] byteData)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", subscriptionKey);

            string uri = uriBase;

            HttpResponseMessage response;

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                response = await client.PostAsync(uri + "detect", content);

                string contentString = await response.Content.ReadAsStringAsync();

                var json = JsonPrettyPrint(contentString);

                //Toast.MakeText(AuthServiceRequests.context, json, ToastLength.Long).Show();

                var jsonSerializerSettings = new JsonSerializerSettings();
                    jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                List<DetectedFace> resp = null;
                try
                {
                    resp = JsonConvert.DeserializeObject<List<DetectedFace>>(json, jsonSerializerSettings);
                    string a = resp[0].faceId;
                    return resp[0];
                }
                catch (Exception e)
                {

                    //Toast.MakeText(AuthServiceRequests.context, "No faces detected", ToastLength.Long).Show();
                    return null;
                }

                //Toast.MakeText(AuthServiceRequests.context, a, ToastLength.Long).Show();

            }
        }

        public static byte[] ImageToByte(Android.Graphics.Bitmap bitmap)
        {
            byte[] bitmapData;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
            return bitmapData;
        }

        public static async Task<bool> CreatePersonGroup(string personGroupId, string groupName)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, subscriptionKey);

                var uri = $"{uriBase}/persongroups/{personGroupId}";

                var body = new PersonGroupCreateRequest()
                {
                    Name = groupName,
                    UserData = ""
                };
                var bodyText = JsonConvert.SerializeObject(body);

                var httpContent = new StringContent(bodyText, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(uri, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    var errorText = await response.Content.ReadAsStringAsync();
                    return false;
                }

                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<PersonGroupGetResponse> GetPersonGroup(string personGroupId)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add(OcpApimSubscriptionKey, subscriptionKey);

                var uri = $"{uriBase}/persongroups/{personGroupId}";

                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<PersonGroupGetResponse>(responseBody);
                    return list;
                }
                else
                {
                    var errorText = await response.Content.ReadAsStringAsync();
                    return null;
                }
            }
        }

        static string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            int offset = 0;
            int indentLength = 3;

            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\'':
                        if (quote) ignore = !ignore;
                        break;
                }

                if (quote)
                    sb.Append(ch);
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '}':
                        case ']':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            break;
                        default:
                            if (ch != ' ') sb.Append(ch);
                            break;
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public static async Task<string> DeletePerson(int personId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                string Id = personId.ToString();

                string uri = $"{uriBase}persongroups/{AppSettings.GroupId}/persons/{Id}";

                var response = await client.DeleteAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                    
                    var errorText = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<FaceApiErrorResponse>(errorText);
                    return errorResponse.Error.Message;
                }
                return null;
            }
        }
    }
}
