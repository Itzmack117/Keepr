using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;
        public VaultsController(VaultsService vs)
        {
            _vs = vs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Vault>> Get()
        {
            try
            {
                return Ok(_vs.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }
        [HttpGet("{id}")]
        public ActionResult<Vault> GetById(int id)
        {
            try
            {
                return Ok(_vs.GetById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult<Vault> Post([FromBody] Vault newVault)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newVault.UserId = userId;
                return Ok(_vs.Create(newVault));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Vault> Edit(int id, [FromBody] Vault keepUpdate)
        {
            try
            {
                keepUpdate.Id = id;
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vs.Edit(keepUpdate, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
         [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vs.Delete(id, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}