using Moq;
using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Services;
using TestePratico.Domain.Tests.Fakes;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Tests.Services;

public class ServiceBase_Add_Should
{
    [Fact]
    public void Return_Valid_ValidationResult_When_Entity_Is_Valid()
    {
        var sbugRepo = new Mock<IRepositoryBase<FakeEntity>>();
        var service = new ServiceBase<FakeEntity>(sbugRepo.Object);
        var validEntity = new FakeEntity(valid: true);

        var result = service.Add(validEntity);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Return_Invalid_ValidationResult_When_Entity_Is_Invalid()
    {
        var sbugRepo = new Mock<IRepositoryBase<FakeEntity>>();
        var service = new ServiceBase<FakeEntity>(sbugRepo.Object);
        var invalidEntity = new FakeEntity(valid: false);

        var result = service.Add(invalidEntity);

        Assert.False(result.IsValid);
    }


    [Fact]
    public void Add_Entity_To_Repository_When_Entity_Is_Valid()
    {
        var mockRepo = new Mock<IRepositoryBase<FakeEntity>>();
        var service = new ServiceBase<FakeEntity>(mockRepo.Object);
        var validEntity = new FakeEntity(valid: true);

        service.Add(validEntity);

        mockRepo.Verify(r => r.Add(validEntity), Times.Once);
    }



    [Fact]
    public void Not_Add_Entity_To_Repository_When_Entity_Is_Invalid()
    {
        var mockRepo = new Mock<IRepositoryBase<FakeEntity>>();
        var service = new ServiceBase<FakeEntity>(mockRepo.Object);
        var invalidEntity = new FakeEntity(valid: false);

        service.Add(invalidEntity);

        mockRepo.Verify(r => r.Add(It.IsAny<FakeEntity>()), Times.Never);
    }
}
