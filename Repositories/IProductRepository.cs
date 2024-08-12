using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;

namespace api.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetProductById(int id);
        Task<Product> Create(ProductDTO productDTO);
        Task<Product?> Update(int id, ProductDTO productDTO);
        Task<Product?> Delete(int id);
    }
}