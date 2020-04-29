using DigiDex.Data;
using DigiDex.Models.Category_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiDex.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;
        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                UserId = _userId,
                CategoryTitle = model.CategoryTitle,
                CreatedUtc = DateTimeOffset.UtcNow
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Categories.Where(e => e.UserId == _userId).Select(e => new CategoryListItem
                {
                    CategoryId = e.CategoryId,
                    CategoryTitle = e.CategoryTitle,
                    CreatedUtc = e.CreatedUtc
                });
                return query.ToArray();
            }
        }

        //Do we need GetCategoryById method? Don't have a CategoryDetail but if we did, would use the same properties as CategoryListItem, so will return that without the IEnumerable
        public CategoryListItem GetCategoryById(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == categoryId && e.UserId == _userId);
                return new CategoryListItem
                {
                    CategoryId = entity.CategoryId,
                    CategoryTitle = entity.CategoryTitle,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        public CategoryListItem GetCategoryByTitle(string categoryTitle)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryTitle == categoryTitle && e.UserId == _userId);
                return new CategoryListItem
                {
                    CategoryId = entity.CategoryId,
                    CategoryTitle = entity.CategoryTitle,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == model.CategoryId && e.UserId == _userId);
                entity.CategoryTitle = model.CategoryTitle;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == categoryId && e.UserId == _userId);
                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
