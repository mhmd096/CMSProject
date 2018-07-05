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
    public class CategoryService
    {
        public Helper helper = new Helper();
        public async Task<ResponseViewModel<List<Category>>> GetAll()
        {
            var returnResponse = new ResponseViewModel<List<Category>>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("categories");
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask = await responsetask.Content.ReadAsAsync<List<Category>>();
                    //returnResponse.Data = readTask;
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    List<Category> res = JsonConvert.DeserializeObject<List<Category>>(result, settings);
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
        public async Task<ResponseViewModel<List<Category>>> Get6()
        {
            var returnResponse = new ResponseViewModel<List<Category>>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("categories/Top6");
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask = await responsetask.Content.ReadAsAsync<List<Category>>();
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    List<Category> res = JsonConvert.DeserializeObject<List<Category>>(result,settings);
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
        public async Task<ResponseViewModel<List<Category>>> Gets(long id)
        {
            var returnResponse = new ResponseViewModel<List<Category>>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("categories/InUnit/" + id.ToString());
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask = await responsetask.Content.ReadAsAsync<List<Category>>();
                    //returnResponse.Data = readTask;
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    List<Category> res = JsonConvert.DeserializeObject<List<Category>>(result, settings);
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

        public async Task<ResponseViewModel<Category>> GetbyId(long id)
        {
            var returnResponse = new ResponseViewModel<Category>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("categories/" + id.ToString());
                if (responsetask.IsSuccessStatusCode)
                {
                    returnResponse.Status = true;
                    //var readTask = await responsetask.Content.ReadAsAsync<Category>();
                    //returnResponse.Data = readTask;
                    var result = await responsetask.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                    };
                    Category res = JsonConvert.DeserializeObject<Category>(result, settings);
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
        public async Task<ResponseViewModel<Category>> Add(Category c)
        {
            var returnResponse = new ResponseViewModel<Category>();
            try
            {
                var jsonContent = JsonConvert.SerializeObject(c);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await helper.httpClient.PostAsync("categories", content);
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
        public async Task<ResponseViewModel<Category>> Delete(long id)
        {
            var returnResponse = new ResponseViewModel<Category>();
            try
            {
                if (id < 0)
                {
                    returnResponse.Status = false;
                    returnResponse.Message = "Please enter a valid id.";
                }
                else
                {
                    var response = await helper.httpClient.DeleteAsync("categories/" + id.ToString());
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
        public async Task<ResponseViewModel<Category>> Update(Category c)
        {
            var returnResponse = new ResponseViewModel<Category>();
            try
            {
                var jsonContent = JsonConvert.SerializeObject(c);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await helper.httpClient.PutAsync("categories", content);
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
