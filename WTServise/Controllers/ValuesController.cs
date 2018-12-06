using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonManager;
using PersonManager.FaceApi;
using PersonManager.Utils;
using Swashbuckle.Swagger.Annotations;
using WTServise.Loger;

namespace WTServise.Controllers
{
    public class ValuesController : ApiController
    {
        private string m_sourcePath;
        FileLoger loger = new FileLoger();

        // GET api/values
        [SwaggerOperation("GetAll")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async System.Threading.Tasks.Task<PersonResponse> GetAsync(byte[] data)
        {
            PersonGroupGetResponse selection= new PersonGroupGetResponse()

                try
                {

                    var detectResult = await FaceApiUtils.DetectFace(data);
                    if (detectResult != null && detectResult.Count > 0)
                    {
                        var faceId = detectResult[0].FaceId;
                        if (!string.IsNullOrEmpty(faceId))
                        {
                            var identifyResult = await FaceApiUtils.Identify(
                               faceId,
                               selection.PersonGroupId,
                               1);

                            if (identifyResult != null && identifyResult.Count > 0 &&
                               identifyResult[0].Candidates.Count > 0)
                            {
                                var personId = identifyResult[0].Candidates[0].PersonId;
                                var confidence = identifyResult[0].Candidates[0].Confidence;

                                var person = await FaceApiUtils.GetPerson(selection.PersonGroupId, personId);

                                

                                var faceFiles = PersonsPersistence.GetFaceFiles(selection.PersonGroupId, personId);
                                if (faceFiles != null && faceFiles.Length > 0)
                                {
                                    var image = ImageUtils.LoadBitmapImage(faceFiles[0].FullName);
                                    return person;
                                }
                            }
                            else
                            {
                                loger.Log("Person could not be identified!");
                            }
                        }
                    }
                }
                catch (FaceApiException ex)
                {
                    
                    loger.Log(ex.Message, ex.Code);
                }
                catch (Exception ex)
                {
                   
                    loger.Log(ex.Message);
                }

            }
        }
    };

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(int id)
        {
        }
    }
}
