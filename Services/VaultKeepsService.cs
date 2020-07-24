using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Keep> GetKeepsByVaultId(int id, string userId)
    {
      return _repo.GetKeepsByVaultId(id, userId);
    }
    public DTOVaultedKeep Get(int Id)
    {
      DTOVaultedKeep found = _repo.GetById(Id);
      if (found == null) { throw new Exception("Keep cannot be placed in vault"); }
      return found;
    }
    internal DTOVaultedKeep Create(DTOVaultedKeep DTOVK)
    {
      if (_repo.hasRelationship(DTOVK))
      {
        throw new Exception("you already have that keep in this vault");
      }
      return _repo.Create(DTOVK);
    }
  }
}