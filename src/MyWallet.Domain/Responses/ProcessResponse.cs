using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Domain.Responses
{
    public class ProcessResponse
    {
        public static Response Error(List<ErrorResponse> errors)
        {
            return new Response(errors);
        }

        public static Response Error(ErrorResponse error)
        {
            return new Response(new List<ErrorResponse>() { error });
        }
    }

    public class ProcessResponse<T> : ProcessResponse
    {
        public static Response<T> Success(T data)
        {
            return new Response<T>(data);
        }

        public static Response<T> Error(List<ErrorResponse> errors)
        {
            return new Response<T>(errors);
        }

        public static Response<T> Error(ErrorResponse error)
        {
            return new Response<T>(new List<ErrorResponse>() { error });
        }
    }
}
