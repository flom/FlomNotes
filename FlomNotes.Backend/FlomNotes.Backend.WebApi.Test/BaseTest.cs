using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace FlomNotes.Backend.WebApi.Test
{
    [Collection("Database collection")]
    public class BaseTest
    {
        protected readonly CustomWebApplicationFactory<Startup> _factory;
        protected readonly HttpClient _client;
        
        public BaseTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        protected async Task<TModel> DeserializeResponse<TModel>(HttpResponseMessage responseMessage)
        {
            return JsonSerializer.Deserialize<TModel>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}