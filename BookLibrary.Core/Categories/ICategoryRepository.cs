namespace BookLibrary.Core.Categories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
}
