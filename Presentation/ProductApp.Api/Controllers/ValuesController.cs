using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Interfaces.UnitOfWorks;
using ProductApp.Domain.Entities;

namespace ProductApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await unitOfWork.GetReadRepository<Product>().GetAllAsync());
        }
    }
}