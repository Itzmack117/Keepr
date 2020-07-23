using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Vault> Get(string userId)
        {
            return _repo.Get(userId);
        }
                public Vault GetById(int id)
        {
            Vault found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }
        public Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }


    
        internal Vault Edit(Vault VaultUpdate, string userId)
        {
            Vault found = GetById(VaultUpdate.Id);
            if (found.UserId != userId)
            {
                throw new Exception("You can only delete your own vaults");
            }
            if (_repo.Edit(VaultUpdate, userId))
            {
                return VaultUpdate;
            }
            throw new Exception("couldnt edit");
        }
        internal string Delete(int id, string userId)
        {
            Vault found = GetById(id);
            if (found.UserId != userId)
            {
                throw new Exception("You can only delete your own vaults");
            }
            if (_repo.Delete(id, userId))
            {
                return "Delete successful.";
            }
            throw new Exception("error in deletion");
        }
    }
}