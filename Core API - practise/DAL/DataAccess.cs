using CategoryService.Database;
using CategoryService.Models;

namespace CategoryService.Dal
{
    public class DataAccess
    {
        CategoriesDB database =  new CategoriesDB();
        public IEnumerable<Category> GetAllCategories()
        {
            return database;
        }
        public Category GetCategory(int id)
        {
            return database.First(c => c.CategoryId == id);
        }
        public Category CreateCategory(Category category)
        {
            database.Add(category);   ///adss to the db
            return category;
        }
        public IEnumerable<Category> UpdateCategory(int id, Category category)
        {
            if(id == category.CategoryId)
            {
                //1. search category from database based in 'id'
                var cat = database.First(c => c.CategoryId == id);

                //2. Remove the search Cateory 
                database.Remove(cat);

                //3. Add the new updated category
                database.Add(category);
            }
            return database;
        }
        public IEnumerable<Category> DeleteCategory(int id)
        {
            //1. search category from database based in 'id'
            var cat = database.First(c => c.CategoryId == id);

            //2. Remove the search Cateory 
            database.Remove(cat);
            return database;
        }
    }
}
