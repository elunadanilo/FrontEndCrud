using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonaFrontEnd.Utils
{
    public class OperationResponse
    {
        public OperationResponse(int code = 0, object data = null)
        {
            Code = code;
            Data = data;
        }

        public int Code { get; set; }
        public Object Data { get; set; }
    }
}