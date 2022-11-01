using AutoMapper;

namespace TestePratico.Web.AutoMapper
{
    public class StandardTypeMappingProfile : Profile
    {
        public StandardTypeMappingProfile() : base(nameof(StandardTypeMappingProfile))
        {
            CreateMap<DateTime, DateOnly>().ConstructUsing(dt => DateOnly.FromDateTime(dt));
            CreateMap<DateOnly, DateTime>().ConstructUsing(d => d.ToDateTime(TimeOnly.MinValue));
        }
    }
}
