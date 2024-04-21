namespace LeafCast.API.Extensions;

public static class StringExtensions
{
    public static string ToZimMobileNumber(this string mobileNumber)
    {
        mobileNumber = mobileNumber.TrimStart('0');

        return $"263{mobileNumber}";
    }
}
