using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Xunit;

namespace GalleryOfLuna.Philomena.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var client = new PhilomenaClient(new Uri("https://derpibooru.org"), "ApiKey");

            var images = await client.SearchImagesAsync("my:upvotes");
            var a = images.Images.First();
            var b = a with {Id = a.Id};
            a = a with {Tags = new ValueCollection<string>(a.Tags.Union(new[] {"abc"}).ToList())};
            b = b with {Tags = new ValueCollection<string>(b.Tags.Union(new[] {"abc"}).ToList())};
            var result = a == b;

            var tags = a.Tags.Equals(b.Tags);
            Assert.NotEmpty(images.Images);
        }

        [Fact]
        public async Task Test2()
        {
            var client = new PhilomenaClient(new Uri("https://derpibooru.org"));

            var image = await client.GetImageAsync(621150);
            
            Assert.NotNull(image);
        }
    }
}