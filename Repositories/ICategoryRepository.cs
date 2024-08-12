using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;

namespace api.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category?> GetCategoryById(int id);
        Task<Category> Create(CategoryCreateDTO categoryDTO);
        Task<Category?> Update(int id, CategoryUpdateDTO categoryDTO);
        Task<Category?> Delete(int id);
    }
}