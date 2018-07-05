using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace YellowPagesServices
{
    public class Helper
    {
        public const string url = "http://localhost:50194/api/";
        public HttpClient httpClient;

        public Helper()
        {
            this.httpClient = new HttpClient() { BaseAddress = new Uri(url) };
        }
    }
}
