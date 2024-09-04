using IrisUtils.Core;

namespace IrisUtils.Tests
{
    public class Core
    {
        [Fact]
        public void DotNetTest()
        {
            Assert.Equal("C:\\Program Files\\dotnet\\dotnet.exe", DotNet.PathOrDefault());
        }
    }
}