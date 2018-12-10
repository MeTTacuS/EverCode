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
        FileLoger loger = new FileLoger();

        
        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async System.Threading.Tasks.Task<PersonResponse> GetPersonAsync([FromBody]byte[] data)
        {
            PersonGroupGetResponse selection = new PersonGroupGetResponse();

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

                            if (identifyResult != null && identifyResult.Count > 0 && identifyResult[0].Candidates.Count > 0)
                            {
                                var personId = identifyResult[0].Candidates[0].PersonId;
                                var confidence = identifyResult[0].Candidates[0].Confidence;

                                var person = await FaceApiUtils.GetPerson(selection.PersonGroupId, personId);

                                

                                var faceFiles = PersonsPersistence.GetFaceFiles(selection.PersonGroupId, personId);
                                if (faceFiles != null && faceFiles.Length > 0)
                                {
                                    return person;
                                }
                            else { return null; }
                            }
                            else
                            {
                                loger.Log("Person could not be identified!");
                                return null;
                            }
                        }
                        else { return null; }
                    }
                else { return null; }
                }
                catch (FaceApiException ex)
                {
                    loger.Log(ex.Message, ex.Code);
                    return null;                   
                }
                catch (Exception ex)
                {
                    loger.Log(ex.Message);
                    return null;                    
                }

            }
        }
    };

      
