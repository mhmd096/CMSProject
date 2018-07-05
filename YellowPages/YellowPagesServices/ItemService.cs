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
    public class ItemService
    {
        Helper helper = new Helper();
        public async Task<ResponseViewModel<List<Item>>> Gets(long id)
        {
            var returnResponse = new ResponseViewModel<List<Item>>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("Items/InCategory/" + id.ToString());
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask = await responsetask.Content.ReadAsAsync<List<Item>>();
                    //returnResponse.Data = readTask;
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    List<Item> res = JsonConvert.DeserializeObject<List<Item>>(result, settings);
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
        public async Task<ResponseViewModel<Item>> GetbyId(long id)
        {
            var returnResponse = new ResponseViewModel<Item>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("Items/" + id.ToString());
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask = await responsetask.Content.ReadAsAsync<Item>();
                    //returnResponse.Data = readTask;
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    Item res = JsonConvert.DeserializeObject<Item>(result, settings);
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
        public async Task<ResponseViewModel<Item>> Add(Item i)
        {
            var returnResponse = new ResponseViewModel<Item>();
            try
            {
                var jsonContent = JsonConvert.SerializeObject(i);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await helper.httpClient.PostAsync("items", content);
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
        public async Task<ResponseViewModel<Item>> Delete(long id)
        {
            var returnResponse = new ResponseViewModel<Item>();
            try
            {
                if (id < 0)
                {
                    returnResponse.Status = false;
                    returnResponse.Message = "Please enter a valid id.";
                }
                else
                {
                    var response = await helper.httpClient.DeleteAsync("items/" + id.ToString());
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
        public async Task<ResponseViewModel<Item>> Update(Item i)
        {
            var returnResponse = new ResponseViewModel<Item>();
            try
            {
                var jsonContent = JsonConvert.SerializeObject(i);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await helper.httpClient.PutAsync("items", content);
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