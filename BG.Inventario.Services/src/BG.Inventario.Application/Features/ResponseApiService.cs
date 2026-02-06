using BG.Inventario.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(int statusCode, object data = null, string message = null)
        {
            bool success = false;

            if (statusCode >= 200 && statusCode < 300)
            {
                success = true;
                message ??= "Ok";
            }
            else
            {
                message ??= "Err";
            }

                return new BaseResponseModel
            {
                StatusCode = statusCode,
                Success = success,
                Message = message,
                Data = data
            };
        }
    }
}
