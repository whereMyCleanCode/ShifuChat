using System;
using ShifuChat.DAL.Models;
using ShifuChat.DAL.Helper;
using Dapper;
using Npgsql;
using Microsoft.Data.Sql;

namespace ShifuChat.DAL
{
    public class IdentityDbContext : IIdentityDbContext
    {
        public async Task<int> CreateUser(UserModel model)
        {
            using (var connection = new NpgsqlConnection(Helper.DbHelper.conectString))
            {
              await connection.OpenAsync();

                string sqlResponse =
                 @"insert into users (Email, Salt, Password, NickName) 
                 values (@Email, @Salt, @Password, @NickName);
                 SELECT currval(pg_get_serial_sequence('users','id'));";

                 return await connection.QuerySingleAsync<int>(sqlResponse, model);
            }
        }

        public async Task<UserModel> GetUser(int id)
        {
            using (var connection = new NpgsqlConnection(Helper.DbHelper.conectString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(
                @"Select Email, Password, Salt, Id, NickName
                From Users where Id = @id", new { id = id }) ?? new UserModel();
            }
        }

        public async Task<UserModel> GetUser(string email)
        {
            using (var connection = new NpgsqlConnection(Helper.DbHelper.conectString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(
                @"Select Email, Password, Salt, Id, NickName
                From Users where Email = @email", new { email = email }) ?? new UserModel();

            }
        }    
    }
}

