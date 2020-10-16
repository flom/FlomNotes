using System.Threading.Tasks;
using Xunit;

namespace FlomNotes.Backend.WebApi.Test
{
    public class UnitTest1 : BaseTest
    {
        public UnitTest1(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Test1()
        {
        }
    }
}