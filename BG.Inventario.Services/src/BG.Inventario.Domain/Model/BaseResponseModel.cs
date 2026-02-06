using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Domain.Model
{
    public class BaseResponseModel 
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
