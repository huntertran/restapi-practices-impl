using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Utils;
using sampleApi.Utils.PaginationForList;
using Microsoft.EntityFrameworkCore;

namespace sampleApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaginationController : ControllerBase
    {
        private MyDbContext _dbContext;

        public PaginationController(MyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Transaction> Transaction(int pageNumber, int itemPerPage)
        {
            var result = _dbContext.transaction
                                   .Skip(itemPerPage * pageNumber)
                                   .Take(itemPerPage);

            Console.WriteLine((result.ToQueryString()));

            return result;
        }
    }
}