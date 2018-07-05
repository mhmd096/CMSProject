using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YellowPagesDB;

namespace YellowPagesServices
{
    public class PictureService
    {
        Helper helper = new Helper();
        public async Task<ResponseViewModel<List<Picture>>> Gets(long id)
        {
            var returnResponse = new ResponseViewModel<List<Picture>>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("pictures/InItem/" + id.ToString());
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask = await responsetask.Content.ReadAsAsync<List<Picture>>();
                    //returnResponse.Data = readTask;
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    List<Picture> res = JsonConvert.DeserializeObject<List<Picture>>(result, settings);
                    returnResponse.Data = res;
                }
                else
                {
                    returnResponse.Status = false;
                    returnResponse.Data = null;
                    returnResponse.Message = "There was a problem. Please try again ";
                }
            }
            catch (Exception ex)
            {
                returnResponse.Data = null;
                returnResponse.Message = "There was a problem. Please try again return. reason: " + ex.Message.ToString();
                returnResponse.Status = false;
            }
            return returnResponse;
        }
        public async Task<ResponseViewModel<Picture>> GetbyId(long id)
        {
            var returnResponse = new ResponseViewModel<Picture>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("pictures/" + id.ToString());
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask = await responsetask.Content.ReadAsAsync<Picture>();
                    //returnResponse.Data = readTask;
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    Picture res = JsonConvert.DeserializeObject<Picture>(result, settings);
                    returnResponse.Data = res;
                }
                else
                {
                    returnResponse.Status = false;
                    returnResponse.Data = null;
                    returnResponse.Message = "There was a problem. Please try again ";
                }
            }
            catch (Exception ex)
            {
                returnResponse.Data = null;
                returnResponse.Message = "There was a problem. Please try again return. reason: " + ex.Message.ToString();
                returnResponse.Status = false;
            }
            return returnResponse;
        }
        public async Task<ResponseViewModel<Picture>> Add(Picture p)
        {
            var returnResponse = new ResponseViewModel<Picture>();
            try
            {
                var jsonContent = JsonConvert.SerializeObject(p);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await helper.httpClient.PostAsync("pictures", content);
                if (response.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                }
                else
                {
                    returnResponse.Status = false;
                    returnResponse.Message = "There was a problem. Please try again ";
                }
            }
            catch (Exception ex)
            {
                returnResponse.Data = null;
                returnResponse.Message = "There was a problem. Please try again return. reason: " + ex.Message.ToString();
                returnResponse.Status = false;
            }
            return returnResponse;
        }
        public async Task<ResponseViewModel<Picture>> Delete(long id)
        {
            var returnResponse = new ResponseViewModel<Picture>();
            try
            {
                if (id < 0)
                {
                    returnResponse.Status = false;
                    returnResponse.Message = "Please enter a valid id.";
                }
                else
                {
                    var response = await helper.httpClient.DeleteAsync("pictures/" + id.ToString());
                    if (response.IsSuccessStatusCode)
                        returnResponse.Status = true;
                    else
                    {
                        returnResponse.Status = false;
                        returnResponse.Message = "There was a problem. Please try again ";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResponse.Message = "There was a problem. Please try again return. reason: " + ex.Message.ToString();
                returnResponse.Status = false;
            }
            return returnResponse;
        }
        public async Task<ResponseViewModel<Picture>> Update(Picture p)
        {
            var returnResponse = new ResponseViewModel<Picture>();
            try
            {
                var jsonContent = JsonConvert.SerializeObject(p);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await helper.httpClient.PutAsync("pictures", content);
                if (response.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                }
                else
                {
                    returnResponse.Status = false;
                    returnResponse.Message = "There was a problem. Please try again ";
                }
            }
            catch (Exception ex)
            {
                returnResponse.Message = "There was a problem. Please try again return. reason: " + ex.Message.ToString();
                returnResponse.Status = false;
            }
            return returnResponse;
        }
    }
}
