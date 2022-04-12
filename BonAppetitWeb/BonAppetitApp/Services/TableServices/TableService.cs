using Models.ResponseModels;
using Models.TableModels;
using Newtonsoft.Json;

namespace Services.TableServices;

public class TableService : ITableService
{
    private readonly HttpClient _httpClient;

    public TableService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<Table>> GetSingleTableAsync(string tableId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"https://localhost:44310/api/Table/GetSingleRestaurantTable/{tableId}");
        var client = await _httpClient.SendAsync(request);

        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Table>>(responseString);
        return response!;
    }
}