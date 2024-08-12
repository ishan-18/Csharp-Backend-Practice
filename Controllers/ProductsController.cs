using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _prodRepo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository prodRepo, IMapper mapper)
        {
            _prodRepo = prodRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var product = await _prodRepo.GetAll();
                var prodModel = product.Select(p => _mapper.Map<ProductDTO>(p));
                return Ok(prodModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            try
            {
                var product = await _prodRepo.GetProductById(id);
                if(product == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<ProductDTO>(product));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO productDTO)
        {
            try
            {
                var product = await _prodRepo.Create(productDTO);
                return CreatedAtAction(nameof(GetProductById), new {id = product.Id}, _mapper.Map<ProductDTO>(product));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateDTO productDTO)
        {
            try
            {
                var product = await _prodRepo.Update(id, productDTO);
                if(product == null) 
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var product = await _prodRepo.Delete(id);
                if(product == null) 
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}