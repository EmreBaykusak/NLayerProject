namespace NLayer.Core.DTOs;

public class CategoryWithProducts : CategoryDto
{
    public List<ProductDto> Products { get; set; }
}