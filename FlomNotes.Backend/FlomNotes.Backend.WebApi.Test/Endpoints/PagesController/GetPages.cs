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
        public async Task Test1()
        {
            var client = _factory.CreateClient();

            using (var scope = _factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<NotesContext>();
                dbContext.Pages.Add(new Page());
                dbContext.SaveChanges();
            }

            var response = await client.GetAsync("/pages");

            var content = await DeserializeResponse<List<ViewModel.Page>>(response);

            response.EnsureSuccessStatusCode();
            Assert.Equal(1, content.Count);
        }
    }
}