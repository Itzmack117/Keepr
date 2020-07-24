using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }
   
    [HttpPost]
    [Authorize]
    public ActionResult<DTOVaultedKeep> Post([FromBody] DTOVaultedKeep newDTOVK)
    {
      try
      {
        newDTOVK.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Create(newDTOVK));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}