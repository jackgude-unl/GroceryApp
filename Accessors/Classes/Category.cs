using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Accessors.Interfaces;
using Microsoft.Data.SqlClient;

namespace Accessors.Classes
{
    public class Category : ICategory
    {
        public int CategoryId { get; }
        public string CategoryName { get; }

        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
    }

    public class CategoryAccessor : ICategoryAccessor
    {
        public IEnumerable<Category> GetAllCategories()
        {
            const string query = "SELECT * FROM Categories";
            var categoryData = DatabaseAccessor.ExecuteQuery(query);

            var categoryList = new List<Category>();
            foreach (DataRow category in categoryData.Rows)
            {
                var cat = new Category((int)category[0], (string)category[1]);
                categoryList.Add(cat);
            }

            return categoryList;
        }
    }
}
