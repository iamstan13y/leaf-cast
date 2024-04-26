using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace LeafCast.Extensions;

public static class HttpclientExtensions
{
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
        var stringData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest ||
                response.StatusCode == HttpStatusCode.Unauthorized ||
                response.StatusCode == HttpStatusCode.Forbidden)
            {
                return JsonSerializer.Deserialize<T>(stringData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            }
        }

        return JsonSerializer.Deserialize<T>(stringData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }


    public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        var stringData = JsonSerializer.Serialize(data);
        var content = new StringContent(stringData);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return httpClient.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        var stringData = JsonSerializer.Serialize(data);
        var content = new StringContent(stringData);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return httpClient.PutAsync(url, content);
    }

    //public static Task<HttpResponseMessage> PostAsFormData<T>(this HttpClient httpClient, string url, T data) where T : class
    //{
    //    var multipartContent = new MultipartFormDataContent();

    //    foreach (var property in typeof(T).GetProperties())
    //    {
    //        var value = property.GetValue(data);
    //        if (value != null)
    //        {
    //            if (property.PropertyType == typeof(IFormFile))
    //            {
    //                var file = (IFormFile)value;
    //                multipartContent.Add(new StreamContent(file.OpenReadStream()), property.Name, file.FileName);
    //            }
    //            else
    //            {
    //                multipartContent.Add(new StringContent(value.ToString()), property.Name);
    //            }
    //        }
    //    }

    //    return httpClient.PostAsync(url, multipartContent);
    //}

}