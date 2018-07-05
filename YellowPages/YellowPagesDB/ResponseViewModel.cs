using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowPagesDB
{
    public class ResponseViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
    public class ResponseViewModel<T> : ResponseViewModel
    {
        public T Data { get; set; }
    }
}
