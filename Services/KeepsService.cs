using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }
                public Keep GetById(int id)
        {
            Keep found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }
        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }


    
        internal Keep Edit(Keep keepUpdate, string userId)
        {
            Keep found = GetById(keepUpdate.Id);
            if (found.UserId == userId && _repo.Edit(keepUpdate, userId))
            {
                return keepUpdate;
            }
            throw new Exception("You cant edit that, it is not yo car!");
        }
        internal string Delete(int id, string userId)
        {
            Keep found = GetById(id);
            if (found.UserId != userId)
            {
                throw new Exception("You can only delete your own keeps");
            }
            if (_repo.Delete(id, userId))
            {
                return "Delete successful.";
            }
            throw new Exception("error in deletion");
        }
    }
}