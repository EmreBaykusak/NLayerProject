using NLayer.Core.DTOs;

namespace NLayer.Core.Services;

public interface ICategoryService : IService<Category>
{
    Task<CustomResponseDto<CategoryWithProducts>> GetSingleCategoryByIdWithProductsAsync(int categoryId);
}