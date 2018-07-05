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
    public class SearchService
    {
        Helper helper = new Helper();
        public async Task<ResponseViewModel<List<Item>>> SearchbyUnit(string cityID,string name)
        {
            var returnResponse = new ResponseViewModel<List<Item>>();
            try
            {
                var responsetask = await helper.httpClient.GetAsync("Search?cityID=" + cityID+"&name=" + name);
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
    }
}
