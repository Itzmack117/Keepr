using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Vault> Get(string userId)
        {
            string sql = "SELECT * FROM Vaults WHERE userId = @userId";
            return _db.Query<Vault>(sql, new { userId });
        }
         internal Vault GetById(int id, string userId)
         {
             string sql = "SELECT * FROM Vaults WHERE id = @id";   
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
            }
 
        internal Vault Create(Vault newVault)
        {
        string sql = @"
        INSERT INTO Vaults
        (name, description, userId)
        VALUES
        (@Name, @Description, @UserId);
        SELECT LAST_INSERT_ID();";
          newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
            return newVault;
        }

        internal bool Edit(Vault original, string userId)
        {
            original.UserId = userId;
            string sql = @"
            UPDATE Vaults
            SET
                name = @Name,
                description = @Description,
                WHERE id = @Id
                AND userId = @UserId";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }

            internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM Vaults WHERE id = @id AND userId = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}