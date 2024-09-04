using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Demo1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IsajkinContext isajkinContext;
        public ServiceController(IsajkinContext context)
        {
            isajkinContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetService()
        {
            var serv = await isajkinContext.Services.Select(s => s).ToListAsync();
            return serv;
        }
    }
}
