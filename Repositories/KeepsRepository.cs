using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }
         internal Keep GetById(int id)
         {
             string sql = "SELECT * FROM Keeps WHERE id = @id";    
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
            }

        internal Keep Create(Keep newKeep)
        {
        string sql = @"
        INSERT INTO Keeps
        (name, description, img, isPrivate, userId)
        VALUES
        (@Name, @Description, @Img, @IsPrivate, @UserId);
        SELECT LAST_INSERT_ID();";
          newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
            return newKeep;
        }

        internal bool Edit(Keep original, string userId)
        {
            original.UserId = userId;
            string sql = @"
            UPDATE Keeps
            SET
                name = @Name,
                description = @Description,
                isPrivate =@isPrivate
                WHERE id = @Id
                AND userId = @UserId";
            int affectedRows = _db.Execute(sql, original);
            return affectedRows == 1;
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM Keeps WHERE id = @id AND userId = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}