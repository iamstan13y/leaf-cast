
using LeafCast.API.Models.Local;
using RestSharp;

namespace LeafCast.API.Services;

public class SmsService(IConfiguration configuration) : ISmsService
{
    private readonly IConfiguration _configuration = configuration;

    public async Task<bool> SendAsync(SmsRequest smsRequest)
    {
        var options = new RestClientOptions(_configuration["SmsService:BaseUrl"]!)
        {
            MaxTimeout = -1,
        };

        var client = new RestClient(options);
        var request = new RestRequest(_configuration["SmsService:Resource"]!, Method.Post);
        request.AddHeader("Authorization", _configuration["SmsService:ApiKey"]!);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Accept", "application/json");

        var body = string.Format(_configuration["SmsService:Message"]!, smsRequest.PhoneNumber, _configuration["SmsService:Sender"]!, smsRequest.Message);

        request.AddStringBody(body, DataFormat.Json);
        RestResponse response = await client.ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }
}