using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace FlomNotes.Backend.WebApi.Test
{
    public class BaseTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly CustomWebApplicationFactory<Startup> _factory;

        public BaseTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        protected async Task<TModel> DeserializeResponse<TModel>(HttpResponseMessage responseMessage)
        {
            return JsonSerializer.Deserialize<TModel>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}