using TestePratico.Domain.Entities;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Tests.Fakes;

public class FakeEntity : EntityBase<FakeEntity>
{
    public FakeEntity(bool valid) : base(new FakeEntityValidator(valid))
    {
    }
}

