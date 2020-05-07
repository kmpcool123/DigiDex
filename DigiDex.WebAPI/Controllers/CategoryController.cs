using DigiDex.Models.Category_Models;
using DigiDex.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigiDex.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService(userId);
            return categoryService;
        }

        /// <summary>
        /// Get all existing categories.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }

        /// <summary>
        /// Get a single category by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetCategoryById(int id)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryById(id);
            return Ok(category);
        }

        /// <summary>
        /// Get all existing categories of a particular title
        /// </summary>
        /// <param name="categoryTitle"></param>
        /// <returns></returns>
        public IHttpActionResult GetCategoryByTitle(string categoryTitle)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryByTitle(categoryTitle);
            return Ok(category);
        }

        /// <summary>
        /// Create a new category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCategoryService();
            if (!service.CreateCategory(category))
                return InternalServerError();
            return Ok();
        }

        /// <summary>
        /// Edit a category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCategoryService();
            if (!service.UpdateCategory(category))
                return InternalServerError();
            return Ok();
        }

        /// <summary>
        /// Remove a category.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();
            if (!service.DeleteCategory(id))
                return InternalServerError();
            return Ok();
        }
    }
}
