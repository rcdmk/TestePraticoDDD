using TestePratico.Domain.Entities;

namespace TestePratico.Domain.Tests.Fakes;

public class FakeEntity : EntityBase<FakeEntity>
{
    public FakeEntity(bool valid) : base(new FakeEntityValidator(valid))
    {
    }
}

