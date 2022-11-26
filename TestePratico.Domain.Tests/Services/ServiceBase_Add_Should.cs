using TestePratico.Domain.Interfaces;
using TestePratico.Domain.Services;
using Moq;
using Moq.Protected;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Validation;
using TestePratico.Domain.Interfaces.Validation;

namespace TestePratico.Domain.Tests.Services;

public class ServiceBase_Add_Should
{
    FakeEntity validEntity = GetFakeEntity(valid: true);
    FakeEntity invalidEntity = GetFakeEntity(valid: false);

    public class FakeEntity : EntityBase<FakeEntity>
    {
        public FakeEntity(Validator<FakeEntity> validator) : base(validator)
        {
        }
    }

    public class FakeEntityValidator : Validator<FakeEntity>
    {
        private readonly bool valid;

        public FakeEntityValidator(bool valid)
        {
            this.valid = valid;
        }

        public override ValidationResult Validate(FakeEntity entity)
        {
            return GetValidationResult(valid);
        }
    }

    [Fact]
    public void Return_Valid_ValidationResult_When_Entity_Is_Valid()
    {
        var sbugRepo = new Mock<IRepositoryBase<FakeEntity>>();
        var service = new ServiceBase<FakeEntity>(sbugRepo.Object);

        var result = service.Add(validEntity);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Return_Invalid_ValidationResult_When_Entity_Is_Invalid()
    {
        var sbugRepo = new Mock<IRepositoryBase<FakeEntity>>();
        var service = new ServiceBase<FakeEntity>(sbugRepo.Object);

        var result = service.Add(invalidEntity);

        Assert.False(result.IsValid);
    }


    [Fact]
    public void Add_Entity_To_Repository_When_Entity_Is_Valid()
    {
        var mockRepo = new Mock<IRepositoryBase<FakeEntity>>();
        var service = new ServiceBase<FakeEntity>(mockRepo.Object);

        service.Add(validEntity);

        mockRepo.Verify(r => r.Add(validEntity), Times.Once);
    }



    [Fact]
    public void Not_Add_Entity_To_Repository_When_Entity_Is_Invalid()
    {
        var mockRepo = new Mock<IRepositoryBase<FakeEntity>>();
        var service = new ServiceBase<FakeEntity>(mockRepo.Object);

        service.Add(invalidEntity);

        mockRepo.Verify(r => r.Add(It.IsAny<FakeEntity>()), Times.Never);
    }


    static FakeEntity GetFakeEntity(bool valid)
    {
        var validator = new FakeEntityValidator(valid);
        return new FakeEntity(validator);
    }

    static ValidationResult GetValidationResult(bool valid)
    {
        var result = new ValidationResult();

        if (!valid) result.Add("foo", "some error");

        return result;
    }
}
