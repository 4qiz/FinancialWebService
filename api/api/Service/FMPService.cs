using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Newtonsoft.Json;

namespace api.Service
{
    public class FMPService : IFMPService
    {
        private HttpClient _client;
        private IConfiguration _config;

        public FMPService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                var result = await _client.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={_config["FMPKey"]}");
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = tasks[0];
                    if (stock != null)
                    {
                        return stock.ToStockFromFMP();
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return null;
            }
        }
    }
}
