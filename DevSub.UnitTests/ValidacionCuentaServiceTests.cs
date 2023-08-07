using Moq;
using DevSu.Core.Interfaces;
using DevSu.Services.ServiceHandlers;

namespace DevSub.UnitTests
{
    [TestFixture]
    public class ValidacionCuentaServiceTests
    {
        [Test]
        public async Task DoesAccountExist_ReturnsTrue_WhenAccountExists()
        {
            // Arrange
            var mockRepository = new Mock<IValidacionCuentaRepository>();
            int testAccountNumber = 123456;

            mockRepository.Setup(repo => repo.DoesAccountExist(testAccountNumber))
                          .ReturnsAsync(true);

            var service = new ValidacionCuentaService(mockRepository.Object);

            var result = await service.DoesAccountExist(testAccountNumber);

            Assert.IsTrue(result); 
        }

        [Test] 
        public async Task DoesClientNameExist_ReturnsTrue_WhenClientNameExists()
        {
            
            var mockRepository = new Mock<IValidacionCuentaRepository>();
            string testClientName = "John Doe";

            mockRepository.Setup(repo => repo.DoesClientNameExist(testClientName))
                          .ReturnsAsync(true);

            var service = new ValidacionCuentaService(mockRepository.Object);

            var result = await service.DoesClientNameExist(testClientName);

            Assert.IsTrue(result);  
        }
    }
}
