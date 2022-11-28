using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using TestePratico.Application.Interfaces;

namespace TestePratico.Services;

public class PeopleService : People.PeopleBase
{
    private readonly ILogger<PeopleService> _logger;

    private readonly IPersonAppService personAppService;

    private readonly IMapper Mapper;

    public PeopleService(ILogger<PeopleService> logger, IMapper mapper, IPersonAppService personAppService)
    {
        this.Mapper = mapper;
        this.personAppService = personAppService;
        _logger = logger;
    }

    public override Task<GetAllPeopleResponse> GetAll(GetAllPeopleRequest request, ServerCallContext context)
    {
        var people = personAppService.GetAll();
        var response = new GetAllPeopleResponse();

        Mapper.Map(people, response.Data);

        return Task.FromResult(response);
    }


    public override Task<GetPersonByIdResponse> GetById(GetPersonByIdRequest request, ServerCallContext context)
    {
        var person = personAppService.GetById(request.Id);
        if (person == null) throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));

        var response = new GetPersonByIdResponse()
        {
            Person = Mapper.Map<Person>(person)
        };

        return Task.FromResult(response);
    }

    public override Task<CreatePersonResponse> Create(CreatePersonRequest request, ServerCallContext context)
    {
        var person = Mapper.Map<Domain.Entities.Person>(request);

        if (!person.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, person.ValidationResult!.ToString()));

        var result = personAppService.Add(person);

        if (!result.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, result.ToString()));

        personAppService.SaveChanges();

        var response = new CreatePersonResponse()
        {
            Id = person.PersonId
        };

        return Task.FromResult(response);
    }

    public override Task<UpdatePersonResponse> Update(UpdatePersonRequest request, ServerCallContext context)
    {
        var existing = personAppService.GetById(request.Id);
        if (existing == null) throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));

        var person = Mapper.Map(request, existing);

        if (!person.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, person.ValidationResult!.ToString()));

        var result = personAppService.Update(person);

        if (!result.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, result.ToString()));

        personAppService.SaveChanges();

        return Task.FromResult(new UpdatePersonResponse());
    }

    public override Task<DeletePersonResponse> Delete(DeletePersonRequest request, ServerCallContext context)
    {
        var existing = personAppService.GetById(request.Id);
        if (existing == null) throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));

        var result = personAppService.Remove(existing);

        if (!result.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, result.ToString()));

        personAppService.SaveChanges();

        return Task.FromResult(new DeletePersonResponse());
    }
}
