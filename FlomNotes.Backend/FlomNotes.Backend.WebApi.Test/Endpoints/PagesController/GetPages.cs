using System.Collections.Generic;
using System.Threading.Tasks;
using FlomNotes.Backend.Model;
using FlomNotes.Backend.Model.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FlomNotes.Backend.WebApi.Test.Endpoints.PagesController
{
    public class GetPages : BaseTest
    {
        public GetPages(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }
        
        [Fact]
        public async Task TestGetPages()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<NotesContext>();
                await dbContext.Pages.AddAsync(new Page());
                await dbContext.SaveChangesAsync();
            }

            var response = await _client.GetAsync("/pages");

            var content = await DeserializeResponse<List<ViewModel.Page>>(response);

            response.EnsureSuccessStatusCode();
            Assert.Single(content);
        }

        [Fact]
        public async Task TestGetNoAvailablePages()
        {
            var response = await _client.GetAsync("/pages");
            var content = await DeserializeResponse<List<ViewModel.Page>>(response);

            response.EnsureSuccessStatusCode();
            Assert.Empty(content);
        }
    }
}