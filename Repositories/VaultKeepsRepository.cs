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
    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"
      SELECT
        k.*,
        vk.id as vaultKeepId
        FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId 
        WHERE (vaultId = @vaultId AND vk.userId = @userId)";

      return _db.Query<Keep>(sql, new { vaultId, userId });
    }

    internal bool hasRelationship(DTOVaultedKeep vaultedKeep)
    {
      string sql = "SELECT* FROM vaultKeeps WHERE keepId = @keepId AND vaultId = @vaultId";
      var found = _db.QueryFirstOrDefault<DTOVaultedKeep>(sql, vaultedKeep);
      return found != null;
    }

    internal DTOVaultedKeep Create(DTOVaultedKeep vaultedKeep)
    {
      string sql = @"
            INSERT INTO vaultKeeps
            (vaultId, keepId, userId)
            VALUES
            (@VaultId, @keepId, @userId);
            SELECT LAST_INSERT_ID();
            ";
      vaultedKeep.KeepId = _db.ExecuteScalar<int>(sql, vaultedKeep);
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