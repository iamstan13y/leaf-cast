﻿using LeafCast.Extensions;
using LeafCast.Models.Local;

namespace LeafCast.Services;

public class HttpService(HttpClient client) : IHttpService
{
    private readonly HttpClient _client = client;
	private const string BASE_URL = "https://leafcast-api.onrender.com";
	
    public async Task<Result<Dictionary<string, decimal>>> GetTopGradesAsync()
    {
		try
		{

        var response = await _client.GetAsync($"{BASE_URL}/api/v1/Predictions/top-grades");
        return await response.ReadContentAs<Result<Dictionary<string, decimal>>>();
		}
		catch (Exception ex)
		{

			throw;
		}
    }
}