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
    public class UnitService
    {
        Helper helper = new Helper();
        public async Task<ResponseViewModel<List<Unit>>> Gets()
        {
            var returnResponse = new ResponseViewModel<List<Unit>>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("units");
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask =await responsetask.Content.ReadAsAsync<List<Unit>>();
                    //returnResponse.Data = readTask;
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    List<Unit> res = JsonConvert.DeserializeObject<List<Unit>>(result, settings);
                    returnResponse.Data = res;
                }
                else
                {
                    returnResponse.Status = false;
                    returnResponse.Data = null;
                    returnResponse.Message = "There was a problem. Please try again ";
                }
            }
            catch(Exception ex)
            {
                returnResponse.Data = null;
                returnResponse.Message = "There was a problem. Please try again return. reason: " + ex.Message.ToString();
                returnResponse.Status = false;
            }
            return returnResponse;
        }
        public async Task<ResponseViewModel<Unit>> Getbyid(long id)
        {
            var returnResponse = new ResponseViewModel<Unit>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("units?id=" + id.ToString());
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask = await responsetask.Content.ReadAsAsync<Unit>();
                    //returnResponse.Data = readTask;
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    Unit res = JsonConvert.DeserializeObject<Unit>(result, settings);
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

        public async Task<ResponseViewModel<Unit>> Add(Unit u)
        {
            var returnResponse = new ResponseViewModel<Unit>();
            try
            {
                var jsonContent = JsonConvert.SerializeObject(u);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await helper.httpClient.PostAsync("units",content);
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
            catch(Exception ex)
            {
                returnResponse.Data = null;
                returnResponse.Message = "There was a problem. Please try again return. reason: " + ex.Message.ToString();
                returnResponse.Status = false;
            }
            return returnResponse;
        }

        public async Task<ResponseViewModel<Unit>> Update(Unit u)
        {
            var returnResponse = new ResponseViewModel<Unit>();
            try
            {
                var jsonContent = JsonConvert.SerializeObject(u);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await helper.httpClient.PutAsync("units", content);
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
        public async Task<ResponseViewModel<Unit>> Delete(long id)
        {
            var returnResponse = new ResponseViewModel<Unit>();
            try
            {
                if(id<0)
                {
                    returnResponse.Status = false;
                    returnResponse.Message = "Please enter a valid id.";
                }
                else
                {
                    var response = await helper.httpClient.DeleteAsync("units?id="+id.ToString());
                    if (response.IsSuccessStatusCode)
                        returnResponse.Status = true;
                    else
                    {
                        returnResponse.Status = false;
                        returnResponse.Message = "There was a problem. Please try again ";
                    }
                }
            }
            catch(Exception ex)
            {
                returnResponse.Message = "There was a problem. Please try again return. reason: " + ex.Message.ToString();
                returnResponse.Status = false;
            }
            return returnResponse;
        }
    }
}
