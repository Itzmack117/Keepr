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

        internal IEnumerable<Vault> Get()
        {
            string sql = "SELECT * FROM Vaults WHERE isPrivate = 0;";
            return _db.Query<Vault>(sql);
        }
         internal Vault GetById(int id)
         {
             string sql = "SELECT * FROM Vaults WHERE id = @id";    
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
            }

        internal Vault Create(Vault newKeep)
        {
        string sql = @"
        INSERT INTO Vaults
        (name, description, isPrivate, userId)
        VALUES
        (@Name, @Description, @IsPrivate, @UserId);
        SELECT LAST_INSERT_ID();";
          newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
            return newKeep;
        }

         internal Vault Edit(Vault original)
    {
      string sql = @"
        UPDATE Vaults
        SET
            name = @Name,
            description = @Description,
            WHERE id = @Id;
            SELECT * FROM Keeps WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Vault>(sql, original);
    }
            internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM Vaults WHERE id = @id AND userId = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}