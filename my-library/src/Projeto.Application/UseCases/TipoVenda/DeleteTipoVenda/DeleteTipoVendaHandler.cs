using AutoMapper;
using MediatR;
using Projeto.Application.UseCases.Livros.DeleteLivro;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.TipoVenda.DeleteTipoVenda;

public sealed class DeleteTipoVendaHandler : IRequestHandler<DeleteTipoVendaRequest, TipoVendaResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITipoVendaRepository _TipoVendaRepository;
    private readonly IMapper _mapper;

    public DeleteTipoVendaHandler(IUnitOfWork unitOfWork, ITipoVendaRepository TipoVendaRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _TipoVendaRepository = TipoVendaRepository;
        _mapper = mapper;
    }

    public async Task<TipoVendaResponse?> Handle(DeleteTipoVendaRequest request, CancellationToken cancellationToken)
    {
        var entity = await _TipoVendaRepository.GetByIdAsynct(request.Codigo, cancellationToken);

        if (entity == null) return default;

        _TipoVendaRepository.Delete(request.Codigo, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<TipoVendaResponse>(entity);
    }
}
