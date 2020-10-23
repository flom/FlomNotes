using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FlomNotes.Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            CleanUpDb().Wait();
        }

        protected async Task<TModel> DeserializeResponse<TModel>(HttpResponseMessage responseMessage)
        {
            return JsonSerializer.Deserialize<TModel>(await responseMessage.Content.ReadAsStringAsync());
        }

        protected async Task CleanUpDb()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<NotesContext>();
                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Pages");
                await dbContext.SaveChangesAsync();
            }
        }
    }
}