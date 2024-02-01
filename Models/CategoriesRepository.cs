namespace WebApp.Models
{
    // In-memory representation of the database
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category {CategoryId = 1, Name = "Category 1", Description = "Description 1"},
            new Category {CategoryId = 2, Name = "Category 2", Description = "Description 2"},
            new Category {CategoryId = 3, Name = "Category 3", Description = "Description 3"},
            new Category {CategoryId = 4, Name = "Category 4", Description = "Description 4"},
            new Category {CategoryId = 5, Name = "Category 5", Description = "Description 5"},
        };

        public static void AddCategory(Category category)
        {
            int maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }
        public static List<Category> GetCategories()
        {
            return _categories;
        }

        public static Category? GetCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };
            }
            return null;
        }
        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }

        }

        public static void DeleteCategory(int id)
        {
            var categoryToDelete = GetCategoryById(id);
            if (categoryToDelete != null)
            {
                _categories.Remove(categoryToDelete);
            }

        }

    }
}