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

    public override Task<GetAllPessoasResponse> GetAll(GetAllPessoasRequest request, ServerCallContext context)
    {
        var pessoas = pessoaAppService.GetAll();
        var response = new GetAllPessoasResponse();

        Mapper.Map(pessoas, response.Data);

        return Task.FromResult(response);
    }


    public override Task<GetPessoaByIdResponse> GetById(GetPessoaByIdRequest request, ServerCallContext context)
    {
        var pessoa = pessoaAppService.GetById(request.Id);
        if (pessoa == null) throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));

        var response = new GetPessoaByIdResponse()
        {
            Pessoa = Mapper.Map<Pessoa>(pessoa)
        };

        return Task.FromResult(response);
    }

    public override Task<CreatePessoaResponse> Create(CreatePessoaRequest request, ServerCallContext context)
    {
        var pessoa = Mapper.Map<Domain.Entities.Pessoa>(request);

        if (!pessoa.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, pessoa.ValidationResult!.ToString()));

        var result = pessoaAppService.Add(pessoa);

        if (!result.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, result.ToString()));

        pessoaAppService.SaveChanges();

        var response = new CreatePessoaResponse()
        {
            Id = pessoa.PessoaId
        };

        return Task.FromResult(response);
    }

    public override Task<UpdatePessoaResponse> Update(UpdatePessoaRequest request, ServerCallContext context)
    {
        var existing = pessoaAppService.GetById(request.Id);
        if (existing == null) throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));

        var pessoa = Mapper.Map(request, existing);

        if (!pessoa.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, pessoa.ValidationResult!.ToString()));

        var result = pessoaAppService.Update(pessoa);

        if (!result.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, result.ToString()));

        pessoaAppService.SaveChanges();

        return Task.FromResult(new UpdatePessoaResponse());
    }

    public override Task<DeletePessoaResponse> Delete(DeletePessoaRequest request, ServerCallContext context)
    {
        var existing = pessoaAppService.GetById(request.Id);
        if (existing == null) throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));

        var result = pessoaAppService.Remove(existing);

        if (!result.IsValid) throw new RpcException(new Status(StatusCode.InvalidArgument, result.ToString()));

        pessoaAppService.SaveChanges();

        return Task.FromResult(new DeletePessoaResponse());
    }
}
