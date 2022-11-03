using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using TestePratico.Application.Interfaces;

namespace TestePratico.Services;

public class PessoasService : Pessoas.PessoasBase
{
    private readonly ILogger<PessoasService> _logger;
    private readonly IPessoaAppService pessoaAppService;
    private readonly IMapper Mapper;
    public PessoasService(ILogger<PessoasService> logger, IMapper mapper, IPessoaAppService pessoaAppService)
    {
        this.Mapper = mapper;
        this.pessoaAppService = pessoaAppService;
        _logger = logger;
    }

    public override Task<PessoaList> GetAll(Empty request, ServerCallContext context)
    {
        var pessoas = pessoaAppService.GetAll();
        var result = Mapper.Map<PessoaList>(pessoas);

        return Task.FromResult(result);
    }

}
