using LeafCast.API.Models.Local;

namespace LeafCast.API.Services;

public interface ISmsService
{
    Task<bool> SendAsync(SmsRequest smsRequest);
}