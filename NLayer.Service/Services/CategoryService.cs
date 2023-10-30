using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services;

public class CategoryService : Service<Category>, ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    
    public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<CategoryWithProducts>> GetSingleCategoryByIdWithProductsAsync(int categoryId)
    {
        var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(categoryId);
        var categoryDto = _mapper.Map<CategoryWithProducts>(category);
        return CustomResponseDto<CategoryWithProducts>.Success(200, categoryDto);
    }
}