using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using TestePratico.Application.Interfaces;

namespace TestePratico.Services;

public class UFsService : UFs.UFsBase
{
    private readonly ILogger<UFsService> _logger;

    private readonly IUFAppService ufAppService;

    private readonly IMapper Mapper;

    public UFsService(ILogger<UFsService> logger, IMapper mapper, IUFAppService ufAppService)
    {
        this.Mapper = mapper;
        this.ufAppService = ufAppService;
        _logger = logger;
    }

    public override Task<GetAllUFsResponse> GetAll(GetAllUFsRequest request, ServerCallContext context)
    {
        var ufs = ufAppService.GetAll();
        var response = new GetAllUFsResponse();

        Mapper.Map(ufs, response.Data);

        return Task.FromResult(response);
    }
}
