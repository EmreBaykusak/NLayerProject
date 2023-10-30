using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services;

public class ProductServiceWithNoCaching : Service<Product>, IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    
    public ProductServiceWithNoCaching(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
    {
        var products = await _productRepository.GetProductsWithCategory();
        var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
        return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
    }
}