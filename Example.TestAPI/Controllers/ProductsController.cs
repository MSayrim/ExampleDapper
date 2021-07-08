using Example.CORE.Dapper.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Example.CORE.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Example.TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDapper _dapper;
        public ProductsController(IDapper dapper)
        {
            _dapper = dapper;
        }
        [HttpPost(nameof(Create))]
        public async Task<int> Create(Product data)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", data.ID, DbType.Int32);
            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Add_Article]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }
        [HttpGet(nameof(GetById))]
        public async Task<Product> GetById(Guid Id)
        {
            var result = await Task.FromResult(_dapper.Get<Product>($"Select * from products where ID = {Id}", null, commandType: CommandType.Text));
            return result;
        }

        [HttpGet(nameof(Get))]
        public async Task<Product> Get()
        {
            var result = await Task.FromResult(_dapper.Get<Product>($"Select * from products", null, commandType: CommandType.Text));
            return result;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<List<Product>> GetAll()
        {
            var result = await Task.FromResult(_dapper.GetAll<Product>($"Select * from products", null, commandType: CommandType.Text));
            return result;
        }
        [HttpGet(nameof(GetAllSP))]
        public async Task<List<Product>> GetAllSP()
        {
            var result = await Task.FromResult(_dapper.GetAllSP<Product>("GetAllProducts", null, commandType: CommandType.StoredProcedure));
            return result;
        }


        [HttpGet(nameof(GetList))]
        public async Task<IList<Product>> GetList()
        {
            var result = await Task.FromResult(_dapper.Get<IList<Product>>($"Select * from products", null, commandType: CommandType.Text).AsList());
            return result;
        }

        [HttpDelete(nameof(Delete))]
        public async Task<int> Delete(int Id)
        {
            var result = await Task.FromResult(_dapper.Execute($"Delete products Where Id = {Id}", null, commandType: CommandType.Text));
            return result;
        }
        [HttpGet(nameof(Count))]
        public Task<int> Count(int num)
        {
            var totalcount = Task.FromResult(_dapper.Get<int>($"select COUNT(*) from products", null,
                    commandType: CommandType.Text));
            return totalcount;
        }
        [HttpPatch(nameof(Update))]
        public Task<int> Update(Product data)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", data.ID);
            dbPara.Add("ProductName", data.ProductName, DbType.String);

            var updateArticle = Task.FromResult(_dapper.Update<int>("[dbo].[SP_Update_Article]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return updateArticle;
        }
    }
}
