using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MerchantsGuideToTheGalaxy.Tests
{
    [TestClass]
    public class DocumentReaderTests
    {
        [TestMethod]
        public void EnsureInputCanBeRetreived()
        {
            Mock<IInputRetriever> mock = new Mock<IInputRetriever>();
            mock.Setup(foo => foo.GetData("myTestInput")).Returns("");

            Mock<FileReader> file = new Mock<FileReader>();
            mock.Setup(foo => foo.GetData("myTestInput")).Returns("");

        }
        
    }
}
