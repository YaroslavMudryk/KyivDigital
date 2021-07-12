using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class Response<T>
    {
        [JsonPropertyName("body")]
        public T Body { get; set; }
    }
}