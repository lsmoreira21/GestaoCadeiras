using System.Text.Json.Serialization;

namespace GestaoCadeiras.Core.Responses
{
    public class Response<TData>
    {
        
        [JsonConstructor]
        public Response() { }
            

        public Response(
            TData? data,            
            string? message = null)
        {
            Data = data;
            Message = message;
        }

        public TData? Data { get; set; }
        public string? Message { get; set; }
    }
}
