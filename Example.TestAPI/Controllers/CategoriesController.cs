using Dapper;
using Example.CORE;
using Example.CORE.Entities.Concrete;
using Example.CORE.Repository.Concrete.EntityFrameWorkCore.EntityTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Example.TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        CategoryRepository _category;


        public CategoriesController(ApplicationDbContext context)
        {
            _category = new CategoryRepository(context);
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _category.GetAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategories(Guid id)
        {
            return await _category.GetByID(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategories(Category category)
        {
            await _category.Add(category);

            return CreatedAtAction("Get", new { id = category.ID }, category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(Guid id, Category category)
        {
            if (id != category.ID)
            {
                return BadRequest();
            }
            try
            {
                await _category.Update(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return NoContent();

        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategories(Guid id)
        {
            var category = await _category.FirstByDefault(e => e.ID == id);

            if (category == null)
            {
                return NotFound();
            }

            await _category.Delete(category);

            return category;

        }

        private bool CategoriesExists(Guid id)
        {
            return _category.Any(e => e.ID == id).Result;
        }


    }
}