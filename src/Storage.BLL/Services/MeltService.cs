using AutoMapper;
using FluentValidation;
using Storage.BLL.Common;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;
using Storage.BLL.DTO.Requests.MeltRequests;
using Storage.BLL.Exceptions;

namespace Storage.BLL.Services;

/// <inheritdoc cref="IMeltService" />
public class MeltService : IMeltService
{
    /// <inheritdoc cref="IMeltRepository" />
    private readonly IMeltRepository  _meltRepository;
    
    private readonly IMapper _mapper;
    
    /// <inheritdoc cref="IProductRepository" />
    private readonly IProductRepository _productRepository;
    
    private readonly IValidator<CreateMeltRequest> _createValidator;
    
    private readonly IValidator<GetMeltsRequest> _getValidator;

    public MeltService(IMeltRepository meltRepository,
        IMapper mapper,
        IProductRepository productRepository,
        IValidator<CreateMeltRequest> validator,
        IValidator<GetMeltsRequest> getValidator)
    {
        _meltRepository = meltRepository;
        _mapper = mapper;
        _productRepository = productRepository;
        _createValidator = validator;
        _getValidator = getValidator;
    }

    public async Task<ICollection<MeltResponse>> ListMeltsAsync(CancellationToken cancellationToken = default)
    {
        var melts = await _meltRepository.GetAllAsync(cancellationToken);
        var meltResponses = _mapper.Map<List<MeltResponse>>(melts);
        return meltResponses;
    }
    
    public async Task<MeltResponse> GetMeltByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var melt = await _meltRepository.GetByIdAsync(id, cancellationToken);
        if (melt == null) throw new KeyNotFoundException("Melt not found");
        
        return _mapper.Map<MeltResponse>(melt);
    }

    public async Task DeleteMeltAsync(int meltId, CancellationToken cancellationToken = default)
    {
        var meltToUpdate = await _meltRepository.GetByIdAsync(meltId, cancellationToken);
        if (meltToUpdate == null) throw new KeyNotFoundException("Melt not found");
        
        await _meltRepository.UpdateAsync(meltToUpdate, cancellationToken);
    }

    public async Task<MeltResponse> CreateMeltAsync(CreateMeltRequest melt, CancellationToken cancellationToken = default)
    {
        await _createValidator.ValidateAndThrowAsync(melt, cancellationToken);
        
        var product = await _productRepository.GetByIdAsync(melt.ProductId, cancellationToken);
        if (product == null) throw new NotFoundException("Product not found");
        
        var newMelt = new Melt
        {
            ProductId = melt.ProductId,
            BrandId = melt.BrandId,
            CertificateId = melt.CertificateId,
            SpecificationId = melt.SpecificationId,
            ProductionDate = melt.ProductionDate,
            MeltStatusId = melt.MeltStatusId
        };
        
        var created = await _meltRepository.CreateAsync(newMelt, cancellationToken);
        
        return _mapper.Map<MeltResponse>(created);
    }

    public async Task<MeltResponse> UpdateMeltAsync(UpdateMeltRequest melt, CancellationToken cancellationToken = default)
    {
        var meltToUpdate = await _meltRepository.GetByIdAsync(melt.MeltId, cancellationToken);
        if(meltToUpdate == null) throw new NotFoundException("Melt not found");
        
        _mapper.Map(melt, meltToUpdate);
        await _meltRepository.UpdateAsync(meltToUpdate, cancellationToken);
        
        return _mapper.Map<MeltResponse>(meltToUpdate);
    }

    public async Task<PagedResponse<MeltResponse>> GetPagedMeltsAsync(GetMeltsRequest request, CancellationToken cancellationToken)
    {
        await _getValidator.ValidateAndThrowAsync(request, cancellationToken);
        
        var melts = await _meltRepository.GetPagedAsync(request.Page, request.PageSize, cancellationToken);
        var meltResponses = _mapper.Map<List<MeltResponse>>(melts);
        return new PagedResponse<MeltResponse>()
        {
            Items = meltResponses,
            Page = request.Page,
            PageSize = request.PageSize,
            TotalCount = melts.Count
        };
    }
}