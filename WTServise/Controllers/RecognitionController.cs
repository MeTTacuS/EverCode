using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PersonManager;
using PersonManager.FaceApi;
using PersonManager.Utils;
using Swashbuckle.Swagger.Annotations;
using WTServise.Loger;

namespace WTServise.Controllers
{
    public class RecognitionController : ApiController
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

        public async Task<string> PostPersonAsync(string personId ,byte[] data)
        {
            var persistedFaceId= await AddFace(personId, data);

            try
            {
                var result = await FaceApiUtils.TrainPersonGroup(AppSettings.GroupId);

                if (result)
                {
                    while (true)
                    {
                        var status = await FaceApiUtils.GetPersonGroupTrainingStatus(AppSettings.GroupId);
                        if (status == PersonGroupTrainingStatus.failed)
                        {
                            return null;
                            break;
                        }
                        else if (status == PersonGroupTrainingStatus.succeeded)
                        {
                            return persistedFaceId;
                            break;
                        }

                        System.Threading.Thread.Sleep(1000);
                    };
                }
                else
                {
                    loger.Log("smth happened with the result in PostPersonAsync");
                    return null;
                }
            }
            catch (FaceApiException ex)
            {
                loger.Log(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                loger.Log(ex.Message);
                return null;
            }
        }


        private async Task<string> AddFace( string personId, byte[] data)
        {
            try
            {

                var persistedFaceId = await FaceApiUtils.AddFaceToPerson(AppSettings.GroupId, personId, data);
                //this where reading and writing to database should be

                return persistedFaceId;
            }
            catch (FaceApiException e)
            {
                loger.Log(e.Message);
            }
            catch (Exception e)
            {
                loger.Log(e.Message);
            }

            return null;
        }
    }
    };

      
