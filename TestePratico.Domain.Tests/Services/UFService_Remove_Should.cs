using Moq;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Services;
using TestePratico.Domain.Tests.Fakes;

namespace TestePratico.Domain.Tests.Services
{
    public class UFService_Remove_Should
    {
        [Fact]
        public void Return_No_Validation_Error_If_UF_Is_Valid_And_Has_No_People_Assigned_To_It()
        {
            var mockRepo = new Mock<IUFRepository>();
            var service = new UFService(mockRepo.Object);
            var uf = createUF(valid: true);

            var result = service.Remove(uf);

            Assert.True(result.IsValid);
            mockRepo.Verify(r => r.Remove(uf), Times.Once);
        }

        [Fact]
        public void Return_A_Validation_Error_If_UF_Is_Valid_But_Has_People_Assigned_To_It()
        {
            var mockRepo = new Mock<IUFRepository>();
            var service = new UFService(mockRepo.Object);
            var uf = createUF(valid: true);
            uf.People.Add(new Person());

            var result = service.Remove(uf);

            Assert.False(result.IsValid);
            mockRepo.Verify(r => r.Remove(uf), Times.Never);
        }


        [Fact]
        public void Return_A_Validation_Error_If_UF_Is_Valid_But_Has_People_Count_Greater_Than_Zero()
        {
            var mockRepo = new Mock<IUFRepository>();
            var service = new UFService(mockRepo.Object);

            var uf = createUF(valid: true);
            uf.PeopleCount = 15;

            var result = service.Remove(uf);

            Assert.False(result.IsValid);
            mockRepo.Verify(r => r.Remove(uf), Times.Never);
        }

        static UF createUF(bool valid)
        {
            return new UF(1, "UF", new FakeValidator<UF>(valid));
        }
    }
}
