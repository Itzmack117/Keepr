using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal DTOVaultedKeep GetById(int id)
        {
            string sql = "SELECT * FROM vaultKeeps WHERE id = @id";
            return _db.QueryFirstOrDefault<DTOVaultedKeep>(sql, new { id });
        }
        internal IEnumerable<ViewModelVaultedKeep> GetByUser(string user)
        {
            string sql = @"
            SELECT
            k.*,
            vk.id as vaultKeepId
            FROM vaultKeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId
            WHERE userId = @userId;";

            return _db.Query<ViewModelVaultedKeep>(sql, new { user });
        }

        internal bool hasRelationship(DTOVaultedKeep vaultedKeep)
        {
            string sql = "SELECT * FROM vaultKeeps WHERE keepId = @keepId AND userId = @UserId";
            var found = _db.QueryFirstOrDefault<DTOVaultedKeep>(sql, vaultedKeep);
            return found != null;
        }

        internal DTOVaultedKeep Create(DTOVaultedKeep vaultedKeep)
        {
            string sql = @"
            INSERT INTO vaultKeeps
            (userId, KeepId)
            VALUES
            (@UserId, @keepId);
            SELECT LAST_INSERT_ID();
            ";
            vaultedKeep.UserId = _db.ExecuteScalar<string>(sql, vaultedKeep);
            return vaultedKeep;
        }
        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaultKeeps WHERE id = @id AND user = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}